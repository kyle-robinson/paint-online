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

            ConnectButton.Location = new Point( 274, 13 );
            DisconnectButton.Location = new Point( 371, 13 );
        }

        /*   COLOURBOX UPDATING   */
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

        /*   CANVAS UPDATING   */
        private void Canvas_MouseMove( object sender, MouseEventArgs e )
        {
            // allow painting if mouse is moving and pen is enabled
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

        private void Canvas_MouseDown( object sender, MouseEventArgs e )
        {
            client.TcpSendMessage( new PenPacket( pen.Color ) );
            moving = true;
            x = e.X;
            y = e.Y;
        }

        public void UpdatePen( Color penColor )
        {
            networkPen.Color = penColor;
        }

        public void ClearCanvas()
        {
            Canvas.Invalidate();
        }

        private void ClearLocalButton_Click( object sender, EventArgs e )
        {
            ClearCanvas();
        }

        private void ClearGlobalButton_Click( object sender, EventArgs e )
        {
            ClearCanvas();
            client.TcpSendMessage( new ClearGlobalPacket() );
        }

        /*   CONNECTION / DISCONNECTING CLIENTS   */
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

        private void ConnectButton_Click( object sender, EventArgs e )
        {
            // connect if not already connected and username is valid
            if ( disconnected && nicknameEntered )
            {
                // determine if admin is already connected / otherwise make user admin or player
                if ( UsernameTextBox.Text.Equals( "admin", StringComparison.InvariantCultureIgnoreCase ) && adminConnected )
                {
                    UpdateServerWindow( "Admin already connected!", Color.Black, Color.IndianRed );
                }
                else if ( UsernameTextBox.Text.Equals( "admin", StringComparison.InvariantCultureIgnoreCase ) && !adminConnected )
                {
                    Connect();
                    isAdmin = true;
                    SpawnClientButton.Visible = true;
                    ClearGlobalButton.Visible = true;

                    ConnectButton.Location = new Point( 226, 13 );
                    DisconnectButton.Location = new Point( 323, 13 );

                    ClearLocalButton.Text = "Clear Canvas (Local)";
                    client.TcpSendMessage( new EncryptedAdminPacket( BitConverter.GetBytes( true ) ) );
                    UpdateServerWindow( "Connected as Admin", Color.Black, Color.MediumPurple );
                    client.TcpSendMessage( new EncryptedClientListPacket( client.EncryptString( UsernameTextBox.Text ),
                        BitConverter.GetBytes( false ) ) );
                }
                else
                {
                    Connect();
                    isAdmin = false;
                    SpawnClientButton.Visible = false;
                    ClearGlobalButton.Visible = false;

                    ConnectButton.Location = new Point( 274, 13 );
                    DisconnectButton.Location = new Point( 371, 13 );

                    ClearLocalButton.Text = "Clear Canvas";
                    UpdateServerWindow( "Connected", Color.Black, Color.LightGreen );
                    client.TcpSendMessage( new EncryptedClientListPacket( client.EncryptString( UsernameTextBox.Text ),
                        BitConverter.GetBytes( false ) ) );
                }
            }

            if ( disconnected && !nicknameEntered )
                UpdateServerWindow( "Failed to connect.", Color.Black, Color.IndianRed );
        }

        private void DisconnectButton_Click( object sender, EventArgs e )
        {
            if ( connected )
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

                UpdateServerWindow( "Disconnected", Color.Black, Color.IndianRed );
                client.TcpSendMessage( new EncryptedClientListPacket( client.EncryptString( UsernameTextBox.Text ),
                    BitConverter.GetBytes( true ) ) );

                if ( UsernameTextBox.Text.Equals( "admin", StringComparison.InvariantCultureIgnoreCase ) && adminConnected )
                    client.TcpSendMessage( new EncryptedAdminPacket( BitConverter.GetBytes( false ) ) );
            }
        }

        /*   SET CLIENT USERNAME   */
        private void SetUsername()
        {
            if ( UsernameTextBox.Text != "" && UsernameTextBox.Text != "Username..." && disconnected )
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

        private void UsernameButton_Click( object sender, EventArgs e )
        {
            SetUsername();
        }

        private void UsernameTextBox_KeyDown( object sender, KeyEventArgs e )
        {
            if ( e.KeyCode == Keys.Enter )
            {
                e.SuppressKeyPress = true;
                SetUsername();
                ConnectButton.Focus();
            }
        }

        /*   NETWORK UPDATE FUNCTIONS   */
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

        public void UpdatePlayerList( string message, bool removeText )
        {
            if ( PlayerList.InvokeRequired )
            {
                Invoke( new Action( () => { UpdatePlayerList( message, removeText ); } ) );
            }
            else
            {
                // add or remove players from the list as they connect/disconnect
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

        /*   ADMIN CONTEXT MENU   */
        private void DisablePaintingItem_Click( object sender, EventArgs e )
        {
            // disable painting on the canvas for selected player
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
            client.TcpSendMessage( new ClearSinglePacket( PlayerList.SelectedItem.ToString() ) );
        }

        private void AdminMenu_Opening( object sender, System.ComponentModel.CancelEventArgs e )
        {
            if ( isAdmin && PlayerList.SelectedItem != null )
            {
                if ( PlayerList.SelectedItem.ToString().Equals( "admin", StringComparison.InvariantCultureIgnoreCase ) )
                {
                    for ( int i = 0; i < AdminMenu.Items.Count; i++ )
                        AdminMenu.Items[i].Visible = false;
                }
                else
                {
                    for ( int i = 0; i < AdminMenu.Items.Count; i++ )
                        AdminMenu.Items[i].Visible = true;
                }
            }
            else
            {
                for ( int i = 0; i < AdminMenu.Items.Count; i++ )
                    AdminMenu.Items[i].Visible = false;
            }
        }

        /*   SPAWN NEW CLIENTS   */
        private void SpawnClientButton_Click( object sender, EventArgs e )
        {
            System.Diagnostics.Process.Start( Application.ExecutablePath );
        }
    }
}