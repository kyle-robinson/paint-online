using System;
using System.Drawing;
using System.Windows.Forms;

namespace PaintApp
{
    public partial class PaintForm : Form
    {
        private Client client;
        private Graphics gfx;
        public Pen networkPen;
        public Pen pen;
        int x = -1;
        int y = -1;
        bool moving = false;

        public PaintForm( Client client )
        {
            InitializeComponent();
            this.client = client;
            
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
                gfx.DrawLine( networkPen, new Point( xPos, yPos ), mouseLocation );
        }

        public void UpdatePen( Color penColor )
        {
            networkPen.Color = penColor;
        }

        public void ClearCanvas()
        {
            Canvas.Invalidate();
        }

        private void ColourBox_Click( object sender, EventArgs e )
        {
            PictureBox pictureBox = (PictureBox)sender;
            pen.Color = pictureBox.BackColor;
            client.UdpSendMessage( new PenPacket( pen.Color ) );
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
            moving = true;
            x = e.X;
            y = e.Y;
        }

        private void Canvas_MouseMove( object sender, MouseEventArgs e )
        {
            if ( moving && x != -1 && y != -1 )
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
            client.UdpSendMessage( new ClearPacket() );
        }
    }
}