using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class MontageComp : PictureBox
    {
        public MontageComp()
        {
            InitializeComponent();
        }
        PictureBox pic = new PictureBox();
        public Label lab = new Label();
        public int id = 0;

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            Panel p = new Panel();
            p.Width = 30;
            p.Height = 40;
            
           // Bitmap image = new Bitmap("..\\Resources\\bix.png");



           // pic.Image = (Image)image;//Properties.Resources.start;
            //pic.Load();
           // pic.Invalidate();
           // pic.Height = 16;
           // pic.Width = 16;
            
            p.Controls.Add(pic);
            this.Controls.Add(lab);
            lab.Left = 20;
            
        }
        public void changeText(string channel_name,int id1)
        {
            lab.Text = channel_name;
            id = id1;
        }
    }
}
