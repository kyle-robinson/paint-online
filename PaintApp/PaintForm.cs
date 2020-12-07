using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace PaintApp
{
    public partial class PaintForm : Form
    {
        private List<string> noPaintPlayers;
        private List<string> playerNames;
        private Client client;
        private Graphics gfx;
        private Pen networkPen;
        private Pen pen;
        int x = -1;
        int y = -1;
        private bool moving = false;
        private bool isAdmin = false;
        public bool penEnabled = true;
        private bool connected = false;
        private bool disconnected = true;
        public bool adminConnected = false;
        private bool nicknameEntered = false;

        public PaintForm( Client client )
        {
            InitializeComponent();
            this.client = client;
            playerNames = new List<string>();
            noPaintPlayers = new List<string>();
            
            gfx = Canvas.CreateGraphics();
            gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            
            pen = new Pen( Color.Black, 5 );
            pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            
            networkPen = new Pen( Color.Black, 5 );
            networkPen.StartCap = networkPen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }

        public void UpdateCanvas( int xPos, int yPos, Point mouseLocation )
        {
            if ( Canvas.InvokeRequired )
                Invoke( new Action( () => { UpdateCanvas( xPos, yPos, mouseLocation ); } ) );
            else
            {
                if ( connected )
                    gfx.DrawLine( networkPen, new Point( xPos, yPos ), mouseLocation );
            }
        }

        public void UpdatePen( Color penColor )
        {
            networkPen.Color = penColor;
        }

        public void ClearCanvas()
        {
            Canvas.Invalidate();
        }

        public void UpdatePlayerList( string message, bool removeText )
        {
            if ( PlayerList.InvokeRequired )
            {
                Invoke( new Action( () => { UpdatePlayerList( message, removeText ); } ) );
            }
            else
            {
                if ( message != null )
                {
                    if ( removeText )
                    {
                        playerNames.Clear();
                        PlayerList.Items.Clear();
                    }
                    else
                    {
                        playerNames.Add( message );
                        PlayerList.Items.Add( message );
                    }
                }

                if ( playerNames.Count != playerNames.Distinct().Count() )
                {
                    playerNames.Remove( message );
                    PlayerList.Items.Remove( message );
                }
            }
        }

        public void UpdateServerWindow( string message, Color foreColor, Color backColor )
        {
            if ( ServerWindow.InvokeRequired )
            {
                Invoke( new Action( () => { UpdateServerWindow( message, foreColor, backColor ); } ) );
            }
            else
            {
                ServerWindow.SelectionStart = ServerWindow.TextLength;
                ServerWindow.SelectionLength = 0;

                ServerWindow.SelectionColor = foreColor;
                ServerWindow.SelectionBackColor = backColor;
                ServerWindow.AppendText( message + "\n" );
                ServerWindow.SelectionColor = ServerWindow.ForeColor;

                ServerWindow.SelectionStart = ServerWindow.Text.Length;
                ServerWindow.ScrollToCaret();
            }
        }

        private void Connect()
        {
            UsernameButton.Enabled = false;
            UsernameTextBox.Enabled = false;

            Canvas.Enabled = true;
            Canvas.BackColor = Color.White;

            connected = true;
            ConnectButton.Enabled = false;

            disconnected = false;
            DisconnectButton.Enabled = true;

            ClearLocalButton.Enabled = true;
            ClearGlobalButton.Enabled = true;
        }

        private void Disconnect()
        {
            UsernameButton.Enabled = true;
            UsernameTextBox.Enabled = true;

            Canvas.Enabled = false;
            Canvas.BackColor = Color.Gainsboro;

            connected = false;
            ConnectButton.Enabled = true;

            disconnected = true;
            DisconnectButton.Enabled = false;

            ClearLocalButton.Enabled = false;
            ClearGlobalButton.Enabled = false;
        }

        private void ConnectButton_Click( object sender, EventArgs e )
        {
            if ( disconnected && nicknameEntered )
            {
                if ( UsernameTextBox.Text.Equals( "admin", StringComparison.InvariantCultureIgnoreCase ) && adminConnected )
                {
                    UpdateServerWindow( "Admin already connected!", Color.Black, Color.IndianRed );
                }
                else if ( UsernameTextBox.Text.Equals( "admin", StringComparison.InvariantCultureIgnoreCase ) && !adminConnected )
                {
                    Connect();
                    isAdmin = true;
                    ClearGlobalButton.Visible = true;
                    ClearLocalButton.Text = "Clear Canvas (Local)";
                    client.TcpSendMessage( new AdminPacket( true ) );
                    UpdateServerWindow( "Connected as Admin", Color.Black, Color.MediumPurple );
                    client.TcpSendMessage( new ClientListPacket( UsernameTextBox.Text, false ) );
                }
                else
                {
                    Connect();
                    isAdmin = false;
                    ClearGlobalButton.Visible = false;
                    ClearLocalButton.Text = "Clear Canvas";
                    UpdateServerWindow( "Connected", Color.Black, Color.LightGreen );
                    client.TcpSendMessage( new ClientListPacket( UsernameTextBox.Text, false ) );
                }
            }

            if ( disconnected && !nicknameEntered )
                UpdateServerWindow( "Failed to connect.", Color.Black, Color.IndianRed );
        }

        private void DisconnectButton_Click( object sender, EventArgs e )
        {
            if ( connected )
            {
                Disconnect();
                UpdateServerWindow( "Disconnected", Color.Black, Color.IndianRed );
                client.TcpSendMessage( new ClientListPacket( UsernameTextBox.Text, true ) );

                if ( UsernameTextBox.Text.Equals( "admin", StringComparison.InvariantCultureIgnoreCase ) && adminConnected )
                    client.TcpSendMessage( new AdminPacket( false ) );
            }
        }

        private void UsernameButton_Click( object sender, EventArgs e )
        {
            if ( UsernameTextBox.Text != "" && UsernameTextBox.Text != "Enter username..." && disconnected )
            { 
                UpdateServerWindow( "Username set.", Color.Black, Color.SkyBlue );
                client.clientName = UsernameTextBox.Text;
                nicknameEntered = true;
            }
            else
            {
                UpdateServerWindow( "Invalid username.", Color.Black, Color.IndianRed );
                nicknameEntered = false;
            }
        }

        private void ColourBox_Click( object sender, EventArgs e )
        {
            PictureBox pictureBox = (PictureBox)sender;
            pen.Color = pictureBox.BackColor;
            client.TcpSendMessage( new PenPacket( pen.Color ) );
        }

        private void ColourBox_MouseEnter( object sender, EventArgs e )
        {
            Canvas.Cursor = Cursors.Hand;
        }

        private void ColourBox_MouseLeave( object sender, EventArgs e )
        {
            Canvas.Cursor = Cursors.Default;
        }

        private void Canvas_MouseDown( object sender, MouseEventArgs e )
        {
            client.TcpSendMessage( new PenPacket( pen.Color ) );
            moving = true;
            x = e.X;
            y = e.Y;
        }

        private void Canvas_MouseMove( object sender, MouseEventArgs e )
        {
            if ( moving && x != -1 && y != -1 && penEnabled )
            {
                client.UdpSendMessage( new PaintPacket( x, y, e.Location ) );
                gfx.DrawLine( pen, new Point( x, y ), e.Location );
                Canvas.Cursor = Cursors.Cross;
                x = e.X;
                y = e.Y;
            }
        }

        private void Canvas_MouseUp( object sender, MouseEventArgs e )
        {
            Canvas.Cursor = Cursors.Default;
            moving = false;
            x = -1;
            y = -1;
        }

        private void ClearLocalButton_Click( object sender, EventArgs e )
        {
            ClearCanvas();
        }

        private void ClearGlobalButton_Click( object sender, EventArgs e )
        {
            ClearCanvas();
            client.TcpSendMessage( new ClearPacket() );
        }

        private void RemovePlayerItem_Click( object sender, EventArgs e )
        {
            
        }

        private void DisablePaintingItem_Click( object sender, EventArgs e )
        {
            if ( !noPaintPlayers.Contains( PlayerList.SelectedItem.ToString() ) )
            {
                DisablePaintingItem.Text = "Enable Painting";
                noPaintPlayers.Add( PlayerList.SelectedItem.ToString() );
                client.TcpSendMessage( new EnablePaintingPacket( PlayerList.SelectedItem.ToString(), false ) );
            }
            else
            {
                DisablePaintingItem.Text = "Disable Painting";
                noPaintPlayers.Remove( PlayerList.SelectedItem.ToString() );
                client.TcpSendMessage( new EnablePaintingPacket( PlayerList.SelectedItem.ToString(), true ) );
            }
        }

        private void ClearCanvasItem_Click( object sender, EventArgs e )
        {
            
        }

        private void AdminMenu_Opening( object sender, System.ComponentModel.CancelEventArgs e )
        {
            if ( isAdmin )
                for ( int i = 0; i < AdminMenu.Items.Count; i++ )
                    AdminMenu.Items[i].Enabled = true;
            else
                for ( int i = 0; i < AdminMenu.Items.Count; i++ )
                    AdminMenu.Items[i].Enabled = false;
        }
    }
}