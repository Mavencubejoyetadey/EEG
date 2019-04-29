using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Timers;
using WindowsFormsApp1;

using MathNet.Numerics;
using MathNet.Numerics.IntegralTransforms;
using System.Numerics;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
/*using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;
using OxyPlot.WindowsForms;*/
using System.Diagnostics;
using System.Threading;
using EEGSoftWare;

namespace WindowsFormsApp1
{

    public partial class CustomControl3Panel : Panel//System.Windows.Forms.Control
    {
        public List<Complex> controlList = new List<Complex>();
        public List<double> in_buffer = new List<double>();
        public int i_c = 0;

        public CustomControl3Panel()
        {
            InitializeComponent();
           
            
        }
        public Label label = new Label();
        public void createChartPanel()
        {
            

            Label la = label;
            la.Text = label.Text;




            // p = panel;
            // p.BackColor = Color.Transparent;//Color.FromArgb(0, 255, 232, 232);

            // Panel pan1 = new Panel();
            //  pan1.BackColor = Color.DarkSalmon;
            // pan1.Width = 100;
            // pan1.Height = 28;
            // p.Width = this.Width;
            // p.Height = this.Height;

            la.BackColor = Color.Transparent;
            la.ForeColor = Color.Black;
            la.Width = 100;
            la.Height = 15;
            la.TextAlign = ContentAlignment.MiddleCenter;
            la.Location = new Point(0,0);
            la.BorderStyle = BorderStyle.FixedSingle;
           // pan1.Controls.Add(la);

            this.Controls.Add(la);
           
        }

        protected override void OnPaint(PaintEventArgs pe)
        {


            

            base.OnPaint(pe);
        }






        }
    }
