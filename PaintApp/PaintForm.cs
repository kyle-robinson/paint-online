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
        private Graphics gfx;
        private Pen pen;

        public PaintForm()
        {
            InitializeComponent();
            pen = new Pen( Color.Black, 5 );
        }
    }
}