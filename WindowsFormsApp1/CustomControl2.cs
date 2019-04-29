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
using Newtonsoft.Json;
/*using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;
using OxyPlot.WindowsForms;*/
using System.Diagnostics;
using System.Threading;
using EEGSoftWare;
using System.Drawing.Printing;
using Control = System.Windows.Forms.Control;

namespace WindowsFormsApp1
{

    public partial class CustomControl2 : Panel//System.Windows.Forms.Control
    {
        SerialPort aserialPort;
        public Boolean isCreated = false;
        public CustomControl2(bool isPatientData)
        {
            InitializeComponent();
        }
        public CustomControl2()
        {
            InitializeComponent();
            timer1.Interval = time_interval;
            timer1.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            timer1.Start();

        }
        Panel time_panel = new Panel();
        int _left = 10;
        public void createChartPanel(int samplerate,int chart_min)
        {
           
            refreshChart();
            time_panel.BackColor = Color.Transparent;
            time_panel.Size = new Size(this.Width, 20);
            time_panel.Location = new Point(0, this.Height-15);
            
           /* for (int i = 0; i < 11; i++)
            {
                Label lab = new Label();
                lab.Text = getTime(i);
                lab.Location = new Point(_left, 0);
                lab.Name = "" + i;
                _left += 100;
                time_panel.Controls.Add(lab);
            }*/
            this.Controls.Add(time_panel);
            chart1.BackColor = Color.Transparent;
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();


            legend1.Name = "Legend1";
            chart1.Legends.Add(legend1);
            /*   for (int i = 0; i < 10; i++)
               {
                   chart1.Series["n1"].Points.AddXY(i, i * 20);
               }*/
            //add series
            graph_data.Clear();
            y_scale = (chart_min / series_count);
            for (int i = 0; i < series_count; i++)
            {
                Series newSeries1 = new Series();
                newSeries1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                newSeries1.Name = "n" + (i + 1);
                newSeries1.BorderWidth = 1;
                chart1.Series.Add(newSeries1);
                chart1.Series[i].IsVisibleInLegend = false;
                chart1.Series[i].Color = Color.Red;
                CustomControl3Panel cc = new CustomControl3Panel();
                graph_data.Add(cc);
                chart1.Series[i].Points.AddXY(0,-(y_scale/2+(y_scale*i)));

            }

            ChartArea NewChartArea1 = new ChartArea();
            NewChartArea1.Name = "NewChartArea";

            //NewChartArea1.BackColor = Color.AliceBlue;
            chart1.ChartAreas.Add("NewChartArea");
            chart1.ChartAreas[0].Position = new ElementPosition(0, 0, 100, 100);
            chart1.Width = this.Width - 200;
           // chart1.Height = 40 * 20;
            chart1.Height = this.Height ;
            //chart1.MaximumSize = new Size(this.Width,800);

              chart1.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
            chart1.ChartAreas[0].BackColor = Color.Transparent;
            chart1.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
            chart1.ChartAreas[0].AxisY.LabelStyle.Enabled = false;

            chart1.ChartAreas[0].AxisX.LineColor = Color.Transparent;
            chart1.ChartAreas[0].AxisY.LineColor = Color.Transparent;
            chart1.ChartAreas[0].AxisX.MajorTickMark.Enabled = false;
            chart1.ChartAreas[0].AxisY.MajorTickMark.Enabled = false;
            chart1.ChartAreas[0].AxisX.MinorTickMark.Enabled = false;
            chart1.ChartAreas[0].AxisY.MinorTickMark.Enabled = false;
            chart1.ChartAreas[0].AxisY.Maximum = 0;
            //chart1.ChartAreas[0].AxisY.MaximumAutoSize = 5;
            chart1.ChartAreas[0].AxisY.Minimum = -chart_min;//(series_count * 6);
           
            // chart1.ChartAreas[0].AxisY.Minimum = 0;
            // chart1.Scale(new SizeF(1.0f, 5f));
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Maximum = samplerate * 10;
            // chart1.ChartAreas[0].AxisX.Interval = 1;




            chart1.Location = new Point(0, 0);


            // p.Width = this.Width;
            // p.Height = this.Height;
            chart1.Invalidate();

            this.Controls.Add(chart1);
           
           
          
            dpi = chart1.RenderingDpiX;
          
        }
        double y_scale;
        Double pixelValue;
        Double dpi;
        double y_chart_min=200;
        public String getTime(int seconds)
        {
            TimeSpan time = TimeSpan.FromSeconds(seconds);


            string str = time.ToString(@"mm\:ss");
            return str;
        }
        public Panel panel = new Panel();
        public Panel panel1;
        public Panel pan_print = new Panel();





        Boolean flag = false;
        public List<double> in1 = new List<double>();

        public double[] out1;
        public System.Timers.Timer timer1 = new System.Timers.Timer();


        List<Double> raw_data = new List<Double>();
        public int x_range;
        public double y_range;
        public List<Complex> controlList = new List<Complex>();
        int sampleRate;
        Complex[] input = new Complex[] { };
        Complex[] input_clear = new Complex[] { };
        public int chart_top = 0;
        public int series_index;
        List<CustomControl3Panel> graph_data = new List<CustomControl3Panel>();
        Double sweep;
        double sweep_multiplier=1;
        public void loadData(List<CustomControl3Panel> list2, int l_filter, int h_filter, bool isNotch, int notch_range, 
            int x_r, double y_r, int sample_rate,int top,double sweep_rate,double sweep_index)
        {
            
            isCreated = true;
            sweep_multiplier = sweep_index;
            sweep = (sweep_rate * dpi) / (chart_point * 25.4);
            chart_top = top;
            Debug.WriteLine(chart_top);
            chart1.Invoke((MethodInvoker)delegate
            {
                chart1.Location = new Point(0, 0);// + top-20
            });
            
            //series_index = index;
            sampleRate = sample_rate;
            x_range = x_r * 5;
            y_range = y_r * 5;
            stopW.Start();
            //  graph_data.Clear();
            /*   if (in1.Count > 6000)
                {
                    int range = in1.Count - 6000;
                    in1.RemoveRange(0,range-1 );

                    Debug.WriteLine("12000 data : " + in1.Count + " i_c: " + i_c+" range: "+ range);
                    i_c = (i_c - range>0?i_c - range:i_c);
                }*/
           
            for (int g = 0; g < list2.Count; g++)
            {
                CustomControl3Panel cc = list2[g] as CustomControl3Panel;

                input = input_clear.ToArray();
                input = cc.controlList.ToArray();
                Fourier.Forward(input, FourierOptions.NoScaling);
                // System.Diagnostics.Debug.WriteLine("after fft " + DateTime.Now.ToString("HH:mm:ss:ff"));

                double[] outMag = new double[input.Length];
                int l_pass = l_filter;
                int h_pass = h_filter;
                int notch_f = 50;

                for (int i = 0; i < input.Length; i++) // high - low pass filter
                {
                    if (i >= h_pass || i <= l_pass)
                    {
                        input[i] = new Complex(0, 0);
                    }
                }


                if (isNotch)
                {

                    for (int i = notch_f - notch_range; i < notch_f + (notch_range + 1); i++)
                    {
                        input[i] = new Complex(0, 0);
                    }
                }



                for (int i = sampleRate / 2; i < input.Length; i++)
                {
                    input[i] = new Complex(0, 0);
                }
                // double[] freq = Fourier.FrequencyScale(512, 512);

                Fourier.Inverse(input, FourierOptions.Matlab);



                //  int in1Length = in1.Count;
                //  Debug.WriteLine(" buffer len in1: " + in1Length);

                for (int j = 0; j < input.Length; j++)
                {
                    double realPart = input[j].Real;
                    // in1.Add(realPart * y_range);
                    graph_data[g].in_buffer.Add(realPart * y_range);
                }
                if (cc.in_buffer.Count > 6000)
                {
                    int range = cc.in_buffer.Count - 6000;
                    cc.in_buffer.RemoveRange(0, range - 1);

                    // Debug.WriteLine("12000 data : " + in1.Count + " i_c: " + i_c + " range: " + range);
                    cc.i_c = (cc.i_c - range > 0 ? cc.i_c - range : cc.i_c);
                    graph_data[g].in_buffer = cc.in_buffer;
                    graph_data[g].i_c = cc.i_c;
                }
            }
        }


        public Label label = new Label();
        /*  public PlotView myPlot = new PlotView();
          public PlotView myPlot_raw = new PlotView();
          public PlotModel myModel = new PlotModel();
          public PlotModel myModel_raw = new PlotModel();
          LineSeries s1 = new LineSeries();
          LineSeries s1_raw = new LineSeries();*/

        int i_c = 0;
        public int series_count = 20;
        public int chart_point = 40;
        public int time_interval = 100;
        Stopwatch stopW = new Stopwatch();
        int count = 0;
        double valueSum;
        public List<PatientDataClass> p_data_list = new List<PatientDataClass>();
        public PatientDataSeries patientDataseies = new PatientDataSeries();
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            
            chart1.Invoke((MethodInvoker)delegate
            {
            // System.Diagnostics.Debug.WriteLine("in1 count before " + i_c);
            int loopCount = 0;
                if (graph_data.Count > 0)
                {
                   
                    for (int d = 0; d < series_count; d++)
                    {
                        CustomControl3Panel cc1 = graph_data[d] as CustomControl3Panel;
                        if (cc1.i_c < cc1.in_buffer.Count)
                        {
                            loopCount = (graph_data[d].in_buffer.Count - graph_data[d].i_c) > chart_point ? chart_point : (graph_data[d].in_buffer.Count - graph_data[d].i_c);
                           
                            for (int i = graph_data[d].i_c; i < graph_data[d].i_c + loopCount; i++)
                            {
                                // for (int k = 0; k < series_count; k++)
                                // {
                               
                                double lastChartX = 0;
                                if (i == 0)
                                    pixelValue = 0.290;//chart1.ChartAreas[0].AxisX.ValueToPixelPosition(1);

                                if (chart1.Series[d].Points.Count > 0)
                                {
                                    if(Math.Round(chart1.Series[d].Points.Last().XValue, 2)==Math.Round(400 * sweep_multiplier * sweep / pixelValue,2))
                                   // if (chart1.Series[d].Points.Last().XValue == 400*sweep/pixelValue)
                                    {
                                        //  Debug.WriteLine("i: " + i + "  " + (chart1.Series[d].Points.Last().XValue * sweep_multiplier) + " lastChartX " + lastChartX);
                                        lastChartX = 0;
                                        chart1.Series[d].Points[(chart1.Series[d]).Points.Count - 1].IsEmpty = true;
                                        
                                    }
                                    else
                                    {
                                        lastChartX = chart1.Series[d].Points.Last().XValue;
                                        count = 0;
                                    }
                                   

                                    
                                }


                                 valueSum += graph_data[d].in_buffer[i];

                                if (i % 5 == 0)
                                {

                                    chart1.Series[d].Points.AddXY(lastChartX + sweep / pixelValue/2 , valueSum - (y_scale / 2) - (y_scale * d));// (d * 40));//- (0.29 * chart_top)
                                  //  PatientDataClass p = new PatientDataClass();
                                 //   p.x_val = lastChartX + sweep / pixelValue / 2;
                                 //   p.y_val = valueSum - (y_scale / 2) - (y_scale * d);
                                    valueSum = 0;
                                   // Debug.WriteLine("Micro volt "+(valueSum - (y_scale / 2) - (y_scale * d) * pixelValue*5)+" pixel"+(valueSum - (y_scale / 2) - (y_scale * d)));
                                   
                                   
                                   // p_data_list.Add(p);
                                    
                                }                                                                                                   //  }
                                                                                                                                         // Debug.WriteLine("value : " + (graph_data[d].in_buffer[i] - (d * 5)) + " value to pixel :" + chart1.ChartAreas[0].AxisX.ValueToPixelPosition(1));

                            }
                            
                            graph_data[d].i_c += loopCount;
                          
                            chart1.Invalidate();
                        }


                       // chart1.ChartAreas[0].RecalculateAxesScale();
                       
                        //chart1.Series["n1"].Points.RemoveAt(i, i * 20);


                    }

                   

                }
                /* if ((chart1.Series[0]).Points.Count > (sampleRate * 10) / 10)
                 {


                     chart1.ChartAreas[0].AxisX.Minimum = chart1.ChartAreas[0].AxisX.Minimum + chart_point;
                     chart1.ChartAreas[0].AxisX.Maximum = chart1.ChartAreas[0].AxisX.Maximum + chart_point;

                 }*/
                
                if ((chart1.Series[0]).Points.Count > 800 * sweep_multiplier)
                 {
                   
                     for (int m = 0; m < series_count; m++)
                     {

                         while (chart1.Series[m].Points.Count > 795* sweep_multiplier)
                         {

                             chart1.Series[m].Points.RemoveAt(0);
                          
                        }
                        // chart1.ResetAutoValues();
                        chart1.Invalidate();
                        
                    }
                 }
                if (count == 0 && chart1.Series[0].Points.Count > 0 && Math.Round(chart1.Series[0].Points.Last().XValue, 2) == Math.Round(400 * sweep_multiplier * sweep / pixelValue, 2))
                {

                    loadTimeline(sweep_multiplier, _start);
                    count++;

                }
            });
         }
     public void loadDataFromChart()
        {
            for (int i=0; i<chart1.Series.Count;i++)
            {
                PatientDataClass p = new PatientDataClass();
                for (int j=0;j< chart1.Series[i].Points.Count; j++)
                {
                    p.x_val.Add(chart1.Series[i].Points[j].XValue);
                    p.y_val.Add( chart1.Series[i].Points[j].YValues[0]);
                  

                }

                patientDataseies.Pseries.Add(p);//Add(p_data_list);

            }
        }

        
        public void viewDataOnChart(string j_data, int chart_min,int smaplerate )
        {
            List<PatientDataClass> records = JsonConvert.DeserializeObject<List<PatientDataClass>>(j_data);
            series_count = records.Count;
            createChartPanel(smaplerate, chart_min);
           

           

            for (int d = 0; d < records.Count; d++)
            {
                for(int i=0;i<records[d].x_val.Count;i++){
                    chart1.Series[d].Points.AddXY(records[d].x_val[i],records[d].y_val[i]);
                }
                chart1.Invalidate();
            }
        }
         public void refreshChart()
         {
             i_c = 0;
             in1.RemoveRange(0,in1.Count);
             while (chart1.Series.Count > 0) { chart1.Series.RemoveAt(0); }
             while (chart1.Legends.Count > 0) { chart1.Legends.RemoveAt(0); }
            while (chart1.ChartAreas.Count > 0) { chart1.ChartAreas.RemoveAt(0); }
         }
        public void clearChart()
        {
            
            for (int m = 0; m < series_count; m++)
            {

                while (chart1.Series[m].Points.Count >0)
                {

                    chart1.Series[m].Points.RemoveAt(0);

                }
                // chart1.ResetAutoValues();
                chart1.Invalidate();

            }
           
            
        }
        int _start = 0;
        public void loadTimeline(double sweep_multiplier,int start=0)
        {
            _left = 10;
            _start = start;
            while (time_panel.Controls.Count > 0)
            {
                time_panel.Controls.RemoveAt(0);
            }
            if (sweep_multiplier >= 1)
            {
                for (int i = 0; i <= 10; i++)
                {
                    Label lab = new Label();
                    lab.Text = getTime(_start+Convert.ToInt32(sweep_multiplier) * i);
                    lab.Location = new Point(_left, 0);
                    lab.Name = "" + i;
                    _left += 100;
                    time_panel.Controls.Add(lab);
                  
                }
                _start = _start + Convert.ToInt32(sweep_multiplier) * 10;
            }
            else
            {
                for (int i = 0; i <= 5; i++)
                {
                    Label lab = new Label();
                    lab.Text = getTime(_start+i);
                    lab.Location = new Point(_left, 0);
                    lab.Name = "" + i;
                    _left += 200;
                    time_panel.Controls.Add(lab);
                  
                }
                _start = _start + Convert.ToInt32(sweep_multiplier) * 5;
            }
        }
        public void refreshTimeLine()
        {
            if (sweep_multiplier >= 1)
            {
                for (int g = 0; g < 11; g++)
                {
                    Label lab = time_panel.Controls[g] as Label;
                    lab.Text = getTime((Convert.ToInt32(lab.Name) + Convert.ToInt32(sweep_multiplier)));
                    lab.Name = "" + (Convert.ToInt32(lab.Name) + sweep_multiplier);
                    lab.Refresh();
                }
            }
            else
            {
                for (int g = 0; g < 11; g++)
                {
                    Label lab = time_panel.Controls[g] as Label;
                    lab.Text = getTime((Convert.ToInt32(lab.Name) + 1));
                    lab.Name = "" + (Convert.ToInt32(lab.Name) + 1);
                    lab.Refresh();
                }
            }
               
        }
         RichTextBox rc1 = new RichTextBox();
         RichTextBox rc2 = new RichTextBox();
         Panel p = new Panel();
         Chart chart1 = new Chart();
         protected override void OnPaint(PaintEventArgs pe)
         {


             rc1.Width = 200;
             rc1.Height = 300;
             rc2.Width = 200;
             rc2.Height = 300;


             base.OnPaint(pe);


             //createChartPanel();

             //  DisplayImage();
             /*   myModel = new PlotModel()
                {
                    PlotAreaBorderThickness = new OxyThickness(0.0),
                    Background = OxyColors.Transparent,
                   PlotAreaBackground=OxyColors.Transparent
                };

                s1 = new LineSeries()

                {
                    Color = OxyColors.Blue,
                    MarkerType = MarkerType.Circle,
                    MarkerSize = 0,
                    MarkerStroke = OxyColors.White,
                    MarkerFill = OxyColors.SkyBlue,
                    Smooth = false,
                    MarkerStrokeThickness = 1.5,
                    Background =OxyColors.Transparent

                };



                //Assign PlotModel to PlotView
                myModel.Series.Add(s1);

                myPlot.Model = myModel;


                //myPlot.Dock = System.Windows.Forms.DockStyle.Fill;
                myPlot.Location = new System.Drawing.Point(200, 0);
                myPlot.Size = new System.Drawing.Size(p.Width, 200);

                myModel.Axes.Add(new LinearAxis()
                {
                    Position = AxisPosition.Bottom,
                    IsAxisVisible = false
                });

                myModel.Axes.Add(new LinearAxis()
                {
                    Position = AxisPosition.Left,
                    IsAxisVisible = false,
                    // Minimum = -200,
                    // Maximum = 200
                });
                myPlot.Scale(new SizeF(1.0f, 0.25f));
                myPlot.TabIndex = 0;
                myPlot.Top = 0;
                // myPlot.Parent = this.Parent;
                // myPlot.BackColor = Color.Transparent;

                this.Controls.Add(myPlot);
                */
                //chart1.BackColor = Color.Transparent;



                rc1.Left = 800;
            // p.Controls.Add(rc1);
            rc2.Left = 600;
            //  p.Controls.Add(rc2);

            /*
                        myModel_raw = new PlotModel()
                        {
                            PlotAreaBorderThickness = new OxyThickness(0.0)

                        };

                        s1_raw = new LineSeries()

                        {
                            Color = OxyColors.Blue,
                            MarkerType = MarkerType.Circle,
                            MarkerSize = 0,
                            MarkerStroke = OxyColors.White,
                            MarkerFill = OxyColors.IndianRed,
                            Smooth = false,
                            MarkerStrokeThickness = 1.5
                        };


                        //Assign PlotModel to PlotView
                        myModel_raw.Series.Add(s1_raw);

                        myPlot_raw.Model = myModel_raw;


                        //myPlot.Dock = System.Windows.Forms.DockStyle.Fill;
                        myPlot_raw.Location = new System.Drawing.Point(0, 0);
                        myPlot_raw.Size = new System.Drawing.Size(p.Width, 200);

                        myModel_raw.Axes.Add(new LinearAxis()
                        {
                            Position = AxisPosition.Bottom,
                            IsAxisVisible = true

                        });

                        myModel_raw.Axes.Add(new LinearAxis()
                        {
                            Position = AxisPosition.Left,
                            IsAxisVisible = true,

                        });

                        myPlot_raw.TabIndex = 0;
                        myPlot_raw.Top = 00;
                        //  p.Controls.Add(myPlot_raw);

                */

                        //this.Controls.Add(p);


        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            this.img = new Bitmap(this.pan_print.Width, this.pan_print.Height);
                pan_print.DrawToBitmap(this.img, new Rectangle(0, 0, this.pan_print.Width, this.pan_print.Height));

            e.Graphics.DrawImage(img,0,0);
           
        }
        Bitmap img;
        public void onClickPrint(Panel panell,Panel leftpnl,String pid,String pname, String page,String date1,String montage,String hpass,String lpass)
        {

            /*    Graphics g = panell.CreateGraphics();
               bmp = new Bitmap(this.Size.Width,this.Size.Height,g);
               Graphics mg = Graphics.FromImage(bmp);
              // mg.CopyFromScreen(0, 0,0,0,this.Size);
               Point panelLocation = PointToScreen(panel.Location);
               mg.CopyFromScreen(100, 100, 0, 0, this.Size);

               //Show the Print Preview Dialog.

               printPreviewDialog1.Document = printDocument1;
              // PaperSize ps = new PaperSize();
              // ps.RawKind = (int)PaperKind.A4;
              // printDocument1.DefaultPageSettings.PaperSize = ps;
               printDocument1.DefaultPageSettings.Landscape = true;


               //printPreviewDialog1.PrintPreviewControl.Zoom = 1;

              printPreviewDialog1.ShowDialog();
               //printDocument1.Print();
              /* printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(CreateReceipt);

               DialogResult result = printPreviewDialog1.ShowDialog();

               if (result == DialogResult.OK)
               {
                   printDocument1.Print();

               }*/

            Panel topP = new Panel();
            topP.Size = new Size(900, 90);
            topP.Location = new Point(100,0);
            Panel dp = new Panel();
            dp.Size = new Size(this.Width, 1);
            dp.BackColor = Color.Black;
            dp.Location = new Point(0, 90);
            Panel dp2 = new Panel();
            dp2.Size = new Size(1, this.Height);
            dp2.BackColor = Color.Black;
            dp2.Location = new Point(90, 90);


            Label lab = new Label();
            lab.Text = "Scan Center";
            lab.Width = 200;
            lab.Location = new Point(topP.Width/2 - lab.Width/2, 65);
            lab.Font = new Font("Arial", 12, FontStyle.Bold);

            Label dt = new Label();
            dt.Text = "Date & Time: " + date1;
            dt.Width = 300;
            dt.Location = new Point(topP.Width -200, 5);


            Label id = new Label();
            id.Text ="Patient ID: "+ pid;
            id.Location = new Point(topP.Width - 100, 25);

            Label name = new Label();
            name.Text = pname;
            name.Location = new Point(topP.Width - 100, 45);

            Label age = new Label();
            age.Text = page;
            age.Location = new Point(topP.Width - 100, 65);



            Label cname = new Label();
            cname.Text = "Company name";
            cname.Location = new Point( 100, 5);


            Label sv = new Label();
            sv.Text = "Software version 2.0.0";
            sv.Location = new Point(100, 25);

            Label mont = new Label();
            mont.Text = montage;
            mont.Location = new Point(100, 45);


            Label lp = new Label();
            lp.Text = "LF: "+lpass;
            lp.Location = new Point(300, 5);


            Label hp = new Label();
            hp.Text = "HF: "+hpass;
            hp.Location = new Point(300, 25);

            Label notch = new Label();
            notch.Text = "Notch: 50Hz";
            notch.Location = new Point(300, 45);




            topP.Controls.Add(lp);
            topP.Controls.Add(hp);
            topP.Controls.Add(notch);

            topP.Controls.Add(cname);
            topP.Controls.Add(sv);
            topP.Controls.Add(mont);


            topP.Controls.Add(lab);
            topP.Controls.Add(dt);
            topP.Controls.Add(id);
            topP.Controls.Add(name);
            topP.Controls.Add(age);

            
            Panel leftP = new Panel();
            leftP.Size = leftpnl.Size;
            foreach (CustomControl3Panel c in leftpnl.Controls)
            {
                Label c2 = new Label();
               
                  
                
                c2.Location = c.Location;
                c2.Size = c.Size;
                c2.Text = c.label.Text;
                leftP.Controls.Add(c2);
            }

            leftP.Location = new Point(0, 100);


            Panel p = new Panel();
           
            p.Size = new Size(this.Width - 100, this.Height+100);
            Graphics g = p.CreateGraphics();
            Bitmap bimg = new Bitmap(this.Size.Width, this.Size.Height, g);
            Graphics mg = Graphics.FromImage(bimg);
             mg.CopyFromScreen(0, 80,0,0,panell.Size);
            PictureBox imageControl = new PictureBox();
            imageControl.Size = this.Size;
            imageControl.Image = bimg;
            p.Location = new Point(0, 100);
          
            p.Controls.Add(imageControl);
            pan_print.BackColor = Color.White;
            pan_print.Size = new Size(this.Width,this.Height+100);
           
            pan_print.Controls.Add(p);
            pan_print.Controls.Add(leftP);
            pan_print.Controls.Add(topP);
            pan_print.Controls.Add(dp);
            pan_print.Controls.Add(dp2);
            pan_print.Invalidate();
            //  time_panel.Size = new Size(pan_print.Width, 20);
            // tmP.Location = new Point(0, panell.Height-60);
            //  pan_print.Controls.Add(tmP);
            //     this.img = new Bitmap(this.pan_print.Width, this.pan_print.Height);
            //    pan_print.DrawToBitmap(this.img, new Rectangle(0, 0, this.pan_print.Width, this.pan_print.Height));
            /* time_panel = new Panel();
             this.Controls.Add(time_panel);
             loadTimeline(sweep_multiplier, _start);*/
            /*  Panel p = new Panel();
              p.Size = new Size(pan_print.Width, 20);
              p.Location = new Point(0, panell.Height - 60);
              pan_print.Controls.Add(p);*/

            printPreviewDialog1.Document = printDocument1;
            printDocument1.DefaultPageSettings.Landscape = true;
            printPreviewDialog1.Show();

            printDocument1.Print();
        }

        public void CreateReceipt(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {



            Graphics graphic = chart1.CreateGraphics();//e.Graphics;
        }
        }
    }
