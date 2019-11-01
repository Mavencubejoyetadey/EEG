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
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace WindowsFormsApp1
{

    public partial class CustomControl2 : Panel//System.Windows.Forms.Control
    {
       
        public Boolean isCreated = false;
        public Boolean isRecordStarted = false;
        public int duration_count = 0;
        public int y_axis_scale = 30000;
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
        Panel time_panel_print = new Panel();
        int _left = 10;
        public void createChartPanel(int samplerate,int chart_min)
        {
            chart_max = series_count * y_axis_scale; // 300 value suggested by ijaz
            chartPrint_min = chart_min;
            sampleRate = samplerate;
            refreshChart();
            time_panel.BackColor = Color.Transparent;
            time_panel.Parent = chart1;
            time_panel.Size = new Size(this.Width, 12);
            time_panel.Location = new Point(0, Screen.PrimaryScreen.Bounds.Height-80-13);
           
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
            
            //chart2.BackColor = Color.Red;
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
                newSeries1.ChartType = SeriesChartType.FastLine;
                newSeries1.Name = "n" + (i + 1);
                newSeries1.BorderWidth = 1;
                chart1.Series.Add(newSeries1);
              
                chart1.Series[i].IsVisibleInLegend = false;
                chart1.Series[i].Color = Color.Red;
                CustomControl3Panel cc = new CustomControl3Panel();
                graph_data.Add(cc);
                chart1.Series[i].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;

                chart1.Series[i].Points.AddXY(0, chart_max - (y_axis_scale / 2 * ((i + 1) * 2 - 1)));
                chart1.AntiAliasing = AntiAliasingStyles.None ;
            }


            ChartArea NewChartArea1 = new ChartArea();
            NewChartArea1.Name = "NewChartArea";

            //NewChartArea1.BackColor = Color.AliceBlue;
            chart1.ChartAreas.Add("NewChartArea");


            chart1.ChartAreas[0].Position = new ElementPosition(0, 0, 100, 100);
          
            chart1.Width  = this.Width - 200;
            // chart1.Height = 40 * 20;
            chart1.Height = Screen.PrimaryScreen.Bounds.Height-80;
            chart1.MaximumSize = new Size(this.Width,800);

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
            chart1.ChartAreas[0].AxisY.Maximum = series_count* y_axis_scale;
            


            chart1.ChartAreas[0].AxisY.Minimum = 0;// -30000;//(series_count * 6);
           
           
            // chart1.Scale(new SizeF(1.0f, 0.5f));
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Maximum = samplerate * 10;
            chart_X_max = chart1.ChartAreas[0].AxisX.Maximum;
          




            chart1.Location = new Point(0, 0);


            // p.Width = this.Width;
            // p.Height = this.Height;
           // chart1.Invalidate();
          //  chart2.Invalidate();
            this.Controls.Add(chart1);
           
            debug_lab.Text = "hello";
            // debug_lab.Location = new Point(100,200);
            debug_lab.Size = new Size(300,10);
            debug_lab.Location = new Point(10, 0);
          
            time_panel.Controls.Add(debug_lab);
            dpi = chart1.RenderingDpiX;
            loadDataFromChart();
        }
        Label debug_lab = new Label();
        public void createPrintChartPanel(int samplerate, int chart_min)
        {

            refreshPrintChart();
           

            chart2.BackColor = Color.Transparent;
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();


            legend2.Name = "Legend2";
            chart2.Legends.Add(legend2);
           
          
        
           

            for (int j = 0; j < series_count; j++)
            {
                Series newSeries2 = new Series();
                newSeries2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                newSeries2.Name = "m" + (j + 1);
                newSeries2.BorderWidth = 1;
                chart2.Series.Add(newSeries2);

                 chart2.Series[j].IsVisibleInLegend = false;
                  chart2.Series[j].Color = Color.Red;

            }

            ChartArea NewChartArea2 = new ChartArea();
            NewChartArea2.Name = "NewChartArea2";

         
            chart2.ChartAreas.Add("NewChartArea2");

          

          
            chart2.ChartAreas[0].Position = new ElementPosition(0, 0, 100, 100);
           chart2.Width = this.Width - 200;
           
          chart2.Height = Screen.PrimaryScreen.Bounds.Height - 80;
            //chart1.MaximumSize = new Size(this.Width,800);

            chart2.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            chart2.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
            chart2.ChartAreas[0].BackColor = Color.Transparent;
            chart2.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
            chart2.ChartAreas[0].AxisY.LabelStyle.Enabled = false;

            chart2.ChartAreas[0].AxisX.LineColor = Color.Transparent;
            chart2.ChartAreas[0].AxisY.LineColor = Color.Transparent;
            chart2.ChartAreas[0].AxisX.MajorTickMark.Enabled = false;
            chart2.ChartAreas[0].AxisY.MajorTickMark.Enabled = false;
            chart2.ChartAreas[0].AxisX.MinorTickMark.Enabled = false;
            chart2.ChartAreas[0].AxisY.MinorTickMark.Enabled = false;
            chart2.ChartAreas[0].AxisY.Maximum = series_count * y_axis_scale;
            //chart1.ChartAreas[0].AxisY.MaximumAutoSize = 5;
            chart2.ChartAreas[0].AxisY.Minimum = 0;// -chart_min;//(series_count * 6);

            // chart1.ChartAreas[0].AxisY.Minimum = 0;
            // chart1.Scale(new SizeF(1.0f, 5f));
            chart2.ChartAreas[0].AxisX.Minimum = 0;
            chart2.ChartAreas[0].AxisX.Maximum = samplerate * 10;
            // chart1.ChartAreas[0].AxisX.Interval = 1;




            chart2.Location = new Point(0, 0);


            this.chart2.BackgroundImage = (System.Drawing.Image)WindowsFormsApp1.Properties.Resources.eeg_grid ;

            this.chart2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            chart2.Invalidate();
        

        }
        double y_scale;
        Double pixelValue;
        Double dpi;
        double y_chart_min=200;
        int chartPrint_min;
        double chart_X_max;
        public String getTime(int seconds)
        {
            TimeSpan time = TimeSpan.FromSeconds(seconds);


            string str = time.ToString(@"hh\:mm\:ss");
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
        int buffer_size = 1200;
        int l_pass = 0;
        int h_pass = 0;
        int notch_f = 50;
        int range;
        double realPart;
        public void loadData(List<CustomControl3Panel> list2, int l_filter, int h_filter, bool isNotch, int notch_range, 
            int x_r, double y_r, int sample_rate,int top,double sweep_rate,double sweep_index,int gain)
        {
            value_gain = gain;
            isCreated = true;
          /*  if (sweep_rate == 30)
            {
                chart_time = 10;
            }
            else if (sweep_rate == 60)
            {
                chart_time = 5;
            }
            else if (sweep_rate == 15)
            {
                chart_time = 15;
            }
            else
            {
                chart_time = 20;
            }*/
            sweep_multiplier = sweep_index;
            sweep = (sweep_rate * dpi) / (40 * 25.4);
            chart_top = top;
         //   Debug.WriteLine(chart_top);
          /*  chart1.Invoke((MethodInvoker)delegate
            {
                chart1.Location = new Point(0, 0);// + top-20
            });*/
            
            //series_index = index;
            sampleRate = sample_rate;
            x_range = x_r * 5;
            y_range = y_r * 5;
           
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
               
              /*  for (int j = cc.controlList.Count; j < 512; j ++)
                {
                    cc.controlList.Add(new Complex(0, 0));
                }*/
                input = cc.controlList.ToArray();

             

               Fourier.Forward(input, FourierOptions.Default);
                // System.Diagnostics.Debug.WriteLine("after fft " + DateTime.Now.ToString("HH:mm:ss:ff"));


           //     var sb_fft = new StringBuilder();
            //    var sb_fft_i = new StringBuilder();


                /*     for (int j = 0; j < input.Length; j++)
                     {
                         double realPart = input[j].Real;
                         sb_fft.Append("" + realPart);
                         sb_fft.AppendLine();
                         sb_fft_i.Append("" + input[j].Imaginary);
                         sb_fft_i.AppendLine();
                     }*/

                
                l_pass = l_filter;
                 h_pass = h_filter;
                 notch_f = 50;
               
                      for (int i = 0; i < input.Length; i++) // high - low pass filter
                      {
                          if (i >= h_pass || i <= l_pass)
                          {
                              input[i] = new Complex(0, 0);
                             // input[(sample_rate - 1) - i] = new Complex(0, 0);


                          }
                      }
                 
                  notch_range = 10; 
                    if (isNotch)
                         {

                            for (int i = notch_f - notch_range; i < notch_f + (notch_range + 1); i++)
                             {
                                 input[i] = new Complex(0, 0);
                                 input[(sample_rate-1)- i] = new Complex(0, 0);

                               }
                         }



            /*    if (isNotch)
                {
                    for (int i = sampleRate / 2; i < input.Length; i++)
                    {
                        input[i] = new Complex(0, 0);
                    }
                }*/

                //   double[] freq = Fourier.FrequencyScale(400, 400);
                /*      var sb = new StringBuilder();


                      for (int j = 0; j < input.Length; j++)
                      {
                          double realPart = input[j].Real;
                          sb.Append(""+ realPart);
                          sb.AppendLine();
                      }
                      */

                Fourier.Inverse(input, FourierOptions.Default);

              /*  DSPLib.FFT fft = new DSPLib.FFT();
                fft.Initialize(400);
                Complex[] cSpectrum = fft.Execute(outMag);
                */
                //  int in1Length = in1.Count;
                //  Debug.WriteLine(" buffer len in1: " + in1Length);

                for (int j = 0; j < input.Length; j++)
                {
                     realPart = input[j].Real;
                    // in1.Add(realPart * y_range);
                    graph_data[g].in_buffer.Add(realPart );//* y_range
                   // cc.in_buffer.Add(realPart);
                }
               // stopW.Start();
                // when buffer full , buffer max size 4000


                //previous code  
                /*  if (cc.in_buffer.Count > 4000)
                  {
                      range = cc.in_buffer.Count - 4000;
                      cc.in_buffer.RemoveRange(0, range - 1);

                      // Debug.WriteLine("12000 data : " + in1.Count + " i_c: " + i_c + " range: " + range);
                      cc.i_c = (cc.i_c - range > 0 ? cc.i_c - range : cc.i_c);
                      graph_data[g].in_buffer = cc.in_buffer;
                      graph_data[g].i_c = cc.i_c;
                  }*/

                //revision
                if (graph_data[g].in_buffer.Count > buffer_size)
                {
                    range = graph_data[g].in_buffer.Count - buffer_size;
                    graph_data[g].in_buffer.RemoveRange(0, range - 1);

                  
                    graph_data[g].i_c = graph_data[g].i_c - range > 0 ? graph_data[g].i_c - range : graph_data[g].i_c;
                   
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
        int chart_max=0;
        double lastChartX = 0;
        int loopCount = 0;
        CustomControl3Panel cc1;
        double x_part;
        int remove_count;


        int drop_rate = 5;
        int point_per_sec = 400;
        int chart_time =10;
        int value_gain = 30;
        public List<PatientDataClass> p_data_list = new List<PatientDataClass>();
        public PatientDataSeries patientDataseies = new PatientDataSeries();
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
         

            chart1.Invoke((MethodInvoker)delegate
            {

            x_part = chart_X_max / ((point_per_sec / drop_rate) * chart_time);
                remove_count = (point_per_sec * chart_time) / drop_rate;
                pixelValue = 0.290;
                if (graph_data.Count > 0)
                {

                    for (int d = 0; d < series_count; d++)
                    {
                    
                        lastChartX = 0;
                         loopCount = 0;
                         cc1 = graph_data[d] as CustomControl3Panel;
                        
                        if (cc1.i_c < cc1.in_buffer.Count)
                        {

                            loopCount = (graph_data[d].in_buffer.Count - graph_data[d].i_c) > chart_point ? chart_point : (graph_data[d].in_buffer.Count - graph_data[d].i_c);
                            /* debug_lab.Invoke((MethodInvoker)delegate
                               {
                                   debug_lab.Text = ""+(graph_data[d].in_buffer.Count- graph_data[d].i_c + loopCount);//- (graph_data[d].i_c + loopCount)
                               });*/
                            for (int i = graph_data[d].i_c; i < graph_data[d].i_c + loopCount; i++)
                            {
                                lastChartX = 0;


                              
                                if (chart1.Series[d].Points.Count > 0)
                                {

                                    if (Math.Round(chart1.Series[d].Points.Last().XValue, 2)== Math.Round(chart_X_max,2))//* sweep_multiplier * sweep / pixelValue
                                            // if (chart1.Series[d].Points.Last().XValue == 400*sweep/pixelValue)
                                    {
                                       // Debug.WriteLine("after page one: " + chart1.Series[d].Points.Count);
                                        lastChartX = 0;
                                      //  timeline_flag = true;
                                        chart1.Series[d].Points[(chart1.Series[d]).Points.Count - 1].IsEmpty = true;
                                        
                                    }
                                    else
                                    {
                                       
                                        lastChartX = chart1.Series[d].Points.Last().XValue;
                                        count = 0;
                                     //   Debug.WriteLine("lastChartX " + lastChartX+"  "+ sweep);
                                    }
                                   

                                    
                                }


                                 valueSum = graph_data[d].in_buffer[i]*value_gain;

                                if (i % drop_rate == 0)
                                {
                                    //lastChartX + (sweep / pixelValue/2)
                                    //chart1.Series[d].Points.AddXY(lastChartX + 12.8, (valueSum + (chart_max - (y_axis_scale / 2 * ((d + 1) * 2 - 1)))));

                                    chart1.Series[d].Points.AddXY(lastChartX+ x_part, (valueSum + (chart_max - (y_axis_scale/2 * ((d + 1) * 2 - 1)))));//(chart_max-(150*((d+1)*2-1))//- (y_scale / 2) - (y_scale * d)// (d * 40));//- (0.29 * chart_top)
                                                                                                                               //   p.y_val = valueSum - (y_scale / 2) - (y_scale * d);
                                    if (isRecordStarted)
                                    {
                                        patientDataseies.Pseries[d].x_val.Add(lastChartX + x_part );//sweep / pixelValue / 2
                                        patientDataseies.Pseries[d].y_val.Add(valueSum + (chart_max - (y_axis_scale / 2 * ((d + 1) * 2 - 1))));
                                        if (patientDataseies.Pseries[d].x_val.Count>((point_per_sec/drop_rate) * duration_count)+ (point_per_sec / drop_rate))
                                        {
                                            duration_count++;
                                        }
                                    }
                                    if (Math.Round(chart1.Series[d].Points.Last().XValue, 2) == Math.Round(chart_X_max, 2))//* sweep_multiplier * sweep / pixelValue
                                                                                                                           // if (chart1.Series[d].Points.Last().XValue == 400*sweep/pixelValue)
                                    {

                                        timeline_flag = true;


                                    }
                                    valueSum = 0;
                                   
                                    if (chart1.Series[d].Points.Count> remove_count)//400
                                    {
                                        //Debug.WriteLine("time with real data "+d+"  " + stopW.Elapsed);
                                        while (chart1.Series[d].Points.Count > (remove_count - 5))//* sweep_multiplier
                                        {

                                            chart1.Series[d].Points.RemoveAt(0);

                                        }
                                    }
                                   
                                    // Debug.WriteLine("Micro volt "+(valueSum - (y_scale / 2) - (y_scale * d) * pixelValue*5)+" pixel"+(valueSum - (y_scale / 2) - (y_scale * d)));


                                    // p_data_list.Add(p);





                                    //Add(p_data_list);

                                }                                                                                                   //  }
                                                                                                                                    // Debug.WriteLine("value : " + (graph_data[d].in_buffer[i] - (d * 5)) + " value to pixel :" + chart1.ChartAreas[0].AxisX.ValueToPixelPosition(1));

                            }
                            
                            graph_data[d].i_c += loopCount;
                          //  Debug.WriteLine(graph_data[d].i_c+"  "+ loopCount);
                            // cc1.i_c += loopCount;

                        }
                       

                        // chart1.ChartAreas[0].RecalculateAxesScale();

                        //chart1.Series["n1"].Points.RemoveAt(i, i * 20);


                    }
                  /*  if ((s_count * 4 + 4) < series_count)
                    {
                        s_count++;
                    }
                    else
                    {
                        s_count = 0;
                    }

                    */

                }
                /* if ((chart1.Series[0]).Points.Count > (sampleRate * 10) / 10)
                 {


                     chart1.ChartAreas[0].AxisX.Minimum = chart1.ChartAreas[0].AxisX.Minimum + chart_point;
                     chart1.ChartAreas[0].AxisX.Maximum = chart1.ChartAreas[0].AxisX.Maximum + chart_point;

                 }*/
               
            /*    if ((chart1.Series[0]).Points.Count > sampleRate*2 * sweep_multiplier)
                 {
                   
                     for (int m = 0; m < series_count; m++)
                     {

                         while (chart1.Series[m].Points.Count > ((sampleRate * 2)-5) * sweep_multiplier)
                         {

                             chart1.Series[m].Points.RemoveAt(0);
                          
                        }
                        // chart1.ResetAutoValues();
                        //chart1.Invalidate();
                        
                    }
                 }*/
                
                if (timeline_flag)
                {
                    timeline_flag = false;
                    loadTimeline(sweep_multiplier, _start);
                    
                    
                    count++;

                }
            });
         }
        Boolean timeline_flag = false;
        public void clearRecord()
        {
            isRecordStarted = false;
            duration_count = 0;
            
            while (patientDataseies.Pseries.Count > 0)
            {
                patientDataseies.Pseries.RemoveAt(0);
            }
        }
     public void loadDataFromChart()
        {
            while (patientDataseies.Pseries.Count>0)
            {
                patientDataseies.Pseries.RemoveAt(0);
            }
            for (int i=0; i<chart1.Series.Count;i++)
            {
                PatientDataClass p = new PatientDataClass();
               /* for (int j=0;j< chart1.Series[i].Points.Count; j++)
                {
                    p.x_val.Add(chart1.Series[i].Points[j].XValue);
                    p.y_val.Add( chart1.Series[i].Points[j].YValues[0]);
                  

                }*/

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
        int current_page = 1;
        public void viewDataOnChartFromDB(string j_data, int chart_min, int smaplerate,int duration,int pg_c)
        {
            recorded_data = j_data;
            record_duration = duration;
            List<PatientDataClass> records = JsonConvert.DeserializeObject<List<PatientDataClass>>(j_data);
            series_count = records.Count;
            createChartPanel(smaplerate, chart_min);
            int pagecount = pg_c;
            int totalDataCount = records[0].x_val.Count;
            int dataplot_count_persec = 80;//totalDataCount / duration;
            int data_count = (pagecount-1)* dataplot_count_persec * 10;
            int data_count_to=0;
          
            if (duration >= 10*pagecount)
            {
                data_count_to = data_count + dataplot_count_persec * 10;

            }
            else
            {
                data_count_to = totalDataCount - 1;//data_count + dataplot_count_persec * (10-(10*pagecount-duration));
            }
            if (pagecount > 1)
            {
                for (int t = 0; t < records.Count; t++)
                {
                    chart1.Series[t].Points.RemoveAt(chart1.Series[t].Points.Count - 1);
                   
                    chart1.Invalidate();
                }
               
            }
            x_part = (chart_X_max / ((point_per_sec / drop_rate) * chart_time));
            double last = 0.0;
            for (int d = 0; d < records.Count; d++)
            {

                last = 0.0;//last + 2.83464566929134 / 0.290 / 2;
                for (int i = data_count; i < data_count_to; i++)
                {
                    chart1.Series[d].Points.AddXY(last+ x_part, records[d].y_val[i]);

                    last  = chart1.Series[d].Points.Last().XValue;
                }
                chart1.Invalidate();
            }

            if (pagecount > 1 && pagecount> current_page)
            {
               // _start++;
                loadTimelineFromDB();
            }
            else if (pagecount >= 1 && pagecount < current_page)
            {
                _start = _start-20;
                loadTimelineFromDB();
            }
            else
            {

            }
            current_page = pagecount;
        }

        String recorded_data;
        int record_duration;
        int page_count=1;
        public void viewDataOnPrintFromDB(string j_data, int duration, int pg_c)
        {
            List<PatientDataClass> records = JsonConvert.DeserializeObject<List<PatientDataClass>>(j_data);
            series_count = records.Count;
            createPrintChartPanel(sampleRate, chartPrint_min);
            int pagecount = pg_c;
            int totalDataCount = records[0].x_val.Count;
            int dataplot_count_persec = totalDataCount / duration;
            int data_count = (pagecount - 1) * dataplot_count_persec*10;
            int data_count_to = 0;

            if (duration >= 10 * pagecount)
            {
                data_count_to = data_count + dataplot_count_persec * 10;

            }
            else
            {
                data_count_to = data_count + dataplot_count_persec * (10 - (10 * pagecount - duration));
            }


            x_part = (chart_X_max / ((point_per_sec / drop_rate) * chart_time));
            double last = 0.0;
            for (int d = 0; d < records.Count; d++)
            {
                last = 0.0;
                for (int i = data_count; i < data_count_to; i++)
                {
                    chart2.Series[d].Points.AddXY(last+x_part, records[d].y_val[i]);
                    last = chart2.Series[d].Points.Last().XValue;
                }
                chart2.Invalidate();
            }

            loadTimelinePrintFromDB();
        }


        public void refreshChart()
         {
             i_c = 0;
             in1.RemoveRange(0,in1.Count);
             while (chart1.Series.Count > 0) { chart1.Series.RemoveAt(0); }
          
            while (chart1.Legends.Count > 0) { chart1.Legends.RemoveAt(0); }
            while (chart1.ChartAreas.Count > 0) { chart1.ChartAreas.RemoveAt(0); }
           
        }
        public void refreshPrintChart()
        {
          
            while (chart2.Series.Count > 0) { chart2.Series.RemoveAt(0); }
            while (chart2.Legends.Count > 0) { chart2.Legends.RemoveAt(0); }
            while (chart2.ChartAreas.Count > 0) { chart2.ChartAreas.RemoveAt(0); }
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
            if (sweep_multiplier == 1)//30
            {
                for (int i = 0; i <= 10; i++)
                {
                    Label lab = new Label();
                    lab.Text = getTime(_start+Convert.ToInt32(sweep_multiplier) * i);
                    lab.Location = new Point(_left, 0);
                    lab.Name = "" + i;
                    _left += ((Screen.PrimaryScreen.Bounds.Width - 100) / 10)-20;//100;//Screen.PrimaryScreen.Bounds.Width-100/10
                    time_panel.Controls.Add(lab);
                  
                }
                _start = _start + Convert.ToInt32(sweep_multiplier) * 10;
            }
            else if(sweep_multiplier == 0.5)//60
            {
                for (int i = 0; i <= 5; i++)
                {
                    Label lab = new Label();
                    lab.Text = getTime(_start+i);
                    lab.Location = new Point(_left, 0);
                    lab.Name = "" + i;
                    _left += ((Screen.PrimaryScreen.Bounds.Width - 100) / 5) - 40; ;
                    time_panel.Controls.Add(lab);
                   
                }
                _start = _start + 5;
                Debug.WriteLine(_start);
                // _start = _start + Convert.ToInt32(sweep_multiplier) * 5;
            }
            else if (sweep_multiplier == 2)//15
            {
                for (int i = 0; i < 5; i++)
                {
                    Label lab = new Label();
                    lab.Text = getTime(_start + i*5);
                   
                    lab.Location = new Point(_left, 0);
                    lab.Name = "" + (i*5);
                    _left += ((Screen.PrimaryScreen.Bounds.Width - 100) / 5) - 20;
                    time_panel.Controls.Add(lab);
                   
                }
                _start = _start + (4 * 5);
                // _start = _start + Convert.ToInt32(sweep_multiplier) * 5;
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    Label lab = new Label();
                    lab.Text = getTime(_start + i*10);
                    lab.Location = new Point(_left, 0);
                    lab.Name = "" + i*10;
                    _left += ((Screen.PrimaryScreen.Bounds.Width - 100) / 5) - 20; ;
                    time_panel.Controls.Add(lab);

                }
                _start = _start + (4 * 10);
            }
        }

        public void loadTimelineFromDB()
        {
            _left = 10;
          
            while (time_panel.Controls.Count > 0)
            {
                time_panel.Controls.RemoveAt(0);
            }
           
                for (int i = 0; i <= 10; i++)
                {
                    Label lab = new Label();
                    lab.Text = getTime(_start + Convert.ToInt32(sweep_multiplier) * i);
                    lab.Location = new Point(_left, 0);
                    lab.Name = "" + i;
                    _left += ((Screen.PrimaryScreen.Bounds.Width - 100) / 10) - 20;//100;//Screen.PrimaryScreen.Bounds.Width-100/10
                    time_panel.Controls.Add(lab);

                }
                _start = _start + Convert.ToInt32(sweep_multiplier) * 10;
          
        }
        public void loadTimelinePrintFromDB()
        {
            _left = 10;

            while (time_panel_print.Controls.Count > 0)
            {
                time_panel_print.Controls.RemoveAt(0);
            }

            for (int i = 0; i <= 10; i++)
            {
                Label lab = new Label();
                lab.Text = getTime(_start_print + Convert.ToInt32(sweep_multiplier) * i);
                lab.Location = new Point(_left, 0);
                lab.Name = "" + i;
                _left += ((Screen.PrimaryScreen.Bounds.Width - 100) / 10) - 20;//100;//Screen.PrimaryScreen.Bounds.Width-100/10
                time_panel_print.Controls.Add(lab);

            }
            _start_print = _start_print + Convert.ToInt32(sweep_multiplier) * 10;
            time_panel_print.Scale(new SizeF(0.85f, 1.0f));
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
        Chart chart2 = new Chart();
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
        int r = 1;
        int totalnumber = 0;//this is for total number of items of the list or array
        int itemperpage = 0;
       /*  private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            float currentY = 10;// declare  one variable for height measurement
            e.Graphics.DrawString("Print in Multiple Pages", DefaultFont, Brushes.Black, 10, currentY);//this will print one heading/title in every page of the document
            currentY += 15;

            while (totalnumber <= 50) // check the number of items
            {
                e.Graphics.DrawString(totalnumber.ToString(), DefaultFont, Brushes.Black, 50, currentY);//print each item
                currentY += 20; // set a gap between every item
                totalnumber += 1; //increment count by 1
                if (itemperpage < 20) // check whether  the number of item(per page) is more than 20 or not
                {
                    itemperpage += 1; // increment itemperpage by 1
                    e.HasMorePages = false; // set the HasMorePages property to false , so that no other page will not be added

                }

                else // if the number of item(per page) is more than 20 then add one page
                {
                    itemperpage = 0; //initiate itemperpage to 0 .
                    e.HasMorePages = true; //e.HasMorePages raised the PrintPage event once per page .
                    return;//It will call PrintPage event again

                }
            }
        }*/

    
    private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            this.img = new Bitmap(this.pan_print.Width, this.pan_print.Height);
                pan_print.DrawToBitmap(this.img, new Rectangle(0, 0, this.pan_print.Width, this.pan_print.Height));

            e.Graphics.DrawImage(img,0,0);
           
            if (record_duration > 10 * page_count)
            {

                page_count++;

                viewDataOnPrintFromDB(recorded_data, record_duration, page_count);
               
                e.HasMorePages = true;
                return;
            }
            else
            {
                e.HasMorePages = false;
            }
            
           
           
        }
        Bitmap img;
        Image target_image;
        PaperSize paperSize = new PaperSize("papersize",1300, 800);
        int _start_print;
        public void onClickPrint(Panel panell,Panel leftpnl,String pid,String pname, String page,String date1,String montage,String hpass,String lpass)
        {

            Panel topP = new Panel();
            topP.Size = new Size(900, 90);
            topP.Location = new Point(90,0);
            Panel dp = new Panel();
            dp.Size = new Size(this.Width, 1);
            dp.BackColor = Color.Black;
            dp.Location = new Point(0, 90);
            Panel dp2 = new Panel();
            dp2.Size = new Size(1, this.Height);
            dp2.BackColor = Color.Black;
            dp2.Location = new Point(100, 90);


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
            leftP.Location = new Point(0, 80);
            foreach (CustomControl3Panel c in leftpnl.Controls)
            {
                Label c2 = new Label();



                c2.Location = new Point(10,c.Location.Y);
                c2.Size = c.Size;
                c2.Text = c.label.Text;
                leftP.Controls.Add(c2);
                c2.BringToFront();
            }

           


            Panel p = new Panel();
           
            p.Size = new Size(Screen.PrimaryScreen.Bounds.Width-100, this.Height+100);

            Panel p1 = new Panel();

            p1.Size = new Size(Screen.PrimaryScreen.Bounds.Width - 100, this.Height + 100);

            Graphics g = p.CreateGraphics();
            Bitmap bimg = new Bitmap(Screen.PrimaryScreen.Bounds.Width, this.Size.Height, g);
            
            Graphics mg = Graphics.FromImage(bimg);
             mg.CopyFromScreen(0, 80,0,0,new Size(Screen.PrimaryScreen.Bounds.Width, panell.Height));
           // mg.ScaleTransform(0.6f,1.0f);
            PictureBox imageControl = new PictureBox();
            imageControl.Size = new Size(Screen.PrimaryScreen.Bounds.Width, panell.Height+80);
            imageControl.Image = bimg;
            target_image = imageControl.Image;
            imageControl.Image = ResizeNow(Screen.PrimaryScreen.Bounds.Width-200, panell.Height);

            //  imageControl.Location = new Point(0, 0);
            p.Location = new Point(0, 100);
          //  imageControl.SizeMode = PictureBoxSizeMode.StretchImage;
           // imageControl.Scale(new SizeF(0.8f, 1.0f));
          //  p.Controls.Add(imageControl);
            pan_print.BackColor = Color.White;
            pan_print.Size = new Size(this.Width,this.Height);
            // p.BackColor = Color.Aqua;
            // p.Scale(new SizeF(0.5f, 1.0f));
            // chart2.Parent = panell;
           
           // p1.Controls.Add(imageControl1);
          
           // chart2.Parent = p1;
            //chart2.Invalidate();

            chart2.Location = new Point(0, 0);
            p1.Location = new Point(0, 100);//p
          
            time_panel_print.BackColor = Color.Transparent;
            //time_panel_print.Parent = chart2;
            //  time_panel_print.Size = new Size(900, 12);
            //  time_panel_print.Location = new Point(100, 300);
            time_panel_print.Size = new Size(this.Width, 12);
            time_panel_print.Location = new Point(90, Screen.PrimaryScreen.Bounds.Height  - 13);

             p1.Controls.Add(chart2);
            chart2.Parent = p1;
           
            // chart2.ChartAreas[0].BackImage = WindowsFormsApp1.Properties.Resources.eeg_grid;
            pan_print.Controls.Add(p1);
            _start_print = 0;
            p1.Scale(new SizeF(0.85f, 1.0f));
           
            viewDataOnPrintFromDB(recorded_data, record_duration, page_count);
           
            
            pan_print.Controls.Add(leftP);
            pan_print.Controls.Add(topP);
            pan_print.Controls.Add(dp);
            pan_print.Controls.Add(dp2);
            pan_print.Controls.Add(time_panel_print);
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
          //      printDocument1.DefaultPageSettings.PaperSize = paperSize;
               printPreviewDialog1.Show();
          //  printDocument1.Print();

            /*  PaperSize ps = new PaperSize();
              ps.RawKind = (int)PaperKind.;*/
            // printDocument1.Print();

            /*    itemperpage = totalnumber = 0;
                printPreviewDialog1.Document = printDocument1;

                ((ToolStripButton)((ToolStrip)printPreviewDialog1.Controls[1]).Items[0]).Enabled
                = false;//disable the direct print from printpreview.as when we click that Print button PrintPage event fires again.


                printDocument1.DefaultPageSettings.PaperSize = paperSize;
                printPreviewDialog1.ShowDialog();*/
        }
        private Bitmap ResizeNow(int target_width, int target_height)
        {
            Rectangle dest_rect = new Rectangle(0, 0, target_width, target_height);
            Bitmap destImage = new Bitmap(target_width, target_height);
            destImage.SetResolution(target_image.HorizontalResolution, target_image.VerticalResolution);
            using (var g = Graphics.FromImage(destImage))
            {
                g.CompositingMode = CompositingMode.SourceCopy;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                using (var wrapmode = new ImageAttributes())
                {
                    wrapmode.SetWrapMode(WrapMode.TileFlipXY);
                    g.DrawImage(target_image, dest_rect, 0, 0, target_image.Width, target_image.Height, GraphicsUnit.Pixel, wrapmode);
                }
            }
            return destImage;
        }
    
    public void CreateReceipt(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {



            Graphics graphic = chart1.CreateGraphics();//e.Graphics;
        }
        }
    }
