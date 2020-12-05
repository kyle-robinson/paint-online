using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintApp
{
    public partial class PaintForm : Form
    {
        private Client client;
        private Graphics gfx;
        private Pen pen;
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
        }

        public void UpdateCanvas( int xPos, int yPos, Point mouseLocation )
        {
            if ( Canvas.InvokeRequired )
            {
                Invoke( new Action( () => { UpdateCanvas( xPos, yPos, mouseLocation ); } ) );
            }
            else
            {
                //Color penColorTemp = pen.Color;
                //pen.Color = penColor;
                gfx.DrawLine( pen, new Point( xPos, yPos ), mouseLocation );
                //pen.Color = penColorTemp;
            }
        }

        public void UpdatePen( Color penColor )
        {
            pen.Color = penColor;
        }

        private void ColourBox_Click( object sender, EventArgs e )
        {
            PictureBox pictureBox = (PictureBox)sender;
            pen.Color = pictureBox.BackColor;
            client.UdpSendMessage( new PenPacket( pen.Color ) );
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
    }
}