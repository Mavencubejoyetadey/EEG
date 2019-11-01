using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO.Ports;
using System.Numerics;
using WindowsFormsApp1;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Drawing.Imaging;

namespace EEGSoftWare
{
    public partial class Form1 : Form
    {
        PatientReg pg = new PatientReg();
        public SerialPort aserialPort;
        public Settings settings = new Settings();
        Stopwatch stopW = new Stopwatch();
        public int h_filter = 15;
        public int l_filter = 1;
        public bool isNotch = true;
        public int notch_range = 5;
        public int gain = 3*10;
        public Form3 fm3 = new Form3();
        public int x_range = 8;
        public double y_range = 1.2;
        public string patient_id;
        int height_screen;
        int width_screen;
        public Form1(bool data)
        {
            InitializeComponent();
          //  this.TransparencyKey = (BackColor);
            // this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            isPatientData = data;
            height_screen = Screen.PrimaryScreen.Bounds.Height;
            width_screen = Screen.PrimaryScreen.Bounds.Width;
            x_duration.Text = "" + (x_range);
            gain_y.Text = "" + (y_range);
            string[] ports = SerialPort.GetPortNames();
            settings.PortList.Items.AddRange(ports);
            settings.bauderate.Text = "1000000";
           settings.PortList.SelectedIndex = 0;


            // panel3.Width = Convert.ToInt32(this.Width);
            //  panel3.Height = 40;
            panel4.Width = width_screen;//Convert.ToInt32(this.Width);
            panel4.Height = 80;
            panel1.Height = height_screen;//Convert.ToInt32(this.Height);
            panel1.Width = width_screen;//Convert.ToInt32(this.Width);
            panel2.Height =  height_screen-70;// Convert.ToInt32(this.Height);
            panel2.Width = width_screen-200;//Convert.ToInt32(this.Width)-200;
            panel1.Location = new Point(0, 0);
            panel2.Location = new Point(100, 80);
            //panel3.Location = new Point(0, 32);
            tableLayoutPanel1.Location = new Point(0, 38);
            tableLayoutPanel1.Width = Convert.ToInt32(this.Width);
           
            menuStrip1.Width = Convert.ToInt32(this.Width);
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.ForeColor = Color.White;
            panel1.Parent = panel2;
           // Debug.WriteLine("width: "+panel2.Width);
            panel1.BackColor = Color.Transparent;
            
            l_filter = 0;
            h_filter = 120;
            notch.SelectedIndex = 0;
            filterList.SelectedIndex = 0;
            filterlist2.SelectedIndex = 4;
            comboBox1.SelectedIndex = 0;
            Channellist.SelectedIndex =0;


            label1.Parent = label9.Parent=label2.Parent = label3.Parent = label4.Parent = gain_y.Parent= label5.Parent = label6.Parent = label7.Parent = label8.Parent = gain_y.Parent = Duration.Parent = x_duration.Parent = panel4;
            label1.BackColor =  label9.BackColor= label2.BackColor = label3.BackColor = gain_y.BackColor =  label4.BackColor = label5.BackColor = label6.BackColor = label7.BackColor = label8.BackColor = gain_y.BackColor = Duration.BackColor = Color.Transparent;

              tableLayoutPanel1.Parent = panel4;
              tableLayoutPanel1.BackColor = Color.Transparent;
            pictureBox5.Location=new Point(width_screen-35,0);
            pictureBox6.Location = new Point(width_screen - 70, 0);
            leftPanel.Location = new Point(0, 80);
            leftPanel.Width = 100;
            leftPanel.Height = Screen.PrimaryScreen.Bounds.Height-80;
            leftPanel.BackColor = Color.DarkSalmon;
            createBasicMontage();

            sweep_combo.SelectedIndex = 2;
            sweep_rate = Convert.ToInt32(sweep_combo.SelectedItem);
        }
        private void createBasicMontage()
        {
            String[] list = new String[] {"F19","F2","F2","F10", "F4", "F6", "F7", "F8",
            "F9","F12","F11","F19","F13","F14","F15","F16","F17","F18","F19","F20"};
            montage1.Montage_channels.Add(new Montage("B-Map", list));
            if (isPatientData)
            {
                montage_list_Click(null, null);
                montage_list.SelectedIndex = 0;
            }
        }

        private void DisplayImage()

        {



            PictureBox imageControl = new PictureBox();

            imageControl.Width = 400;

            imageControl.Height = 800;



            Bitmap image = new Bitmap("C:\\Users\\JOYETA DEY\\Desktop\\works\\grid16.png");
            //  image.MakeTransparent(image.GetPixel(0, 0));
            // imageControl.Dock = DockStyle.Fill;

            imageControl.Image = (Image)image;

            imageControl.Top = 0;
            imageControl.Left = 100;
            // imageControl.BackColor = Color.Transparent;
            // customPanel1.BackColor = Color.Transparent;
            panel1.Controls.Add(imageControl);



            //imageControl.BringToFront();
            // panel1.();


        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public int _top = 0;
        public int chart_top = 0;
        public int _height_chart = 40;
        List<CustomControl2> lineList = new List<CustomControl2>();
        List<CustomControl3Panel> labLleist = new List<CustomControl3Panel>();

        List<Complex> list = new List<Complex>();
        List<Complex> list1 = new List<Complex>();
        Graphics gObject;
        public float x1 = 100;
        float y1 = 0;
        double count = 10;
        int c_count = 0;
        float c = 0;
        Pen pen = new Pen(Color.Red, 1);
        int count_first = 1;
        double divider = 0.2;
        double lower_limit = 230;
        double upper_limit;
        int multiplier = 1;
        //Timer timer;
        Form2 fm = new Form2();
        bool isPaused = false;
        bool isPortOpen = false;
        public int sample_rate = 512;

        int i = 0;
        List<double> TimeList = new List<double>();
        delegate void SetChartCallback(double[] in1, List<double> timelist);



        private void onTextChange(object sender, EventArgs e)
        {
            closeBtn.SelectionStart = closeBtn.Text.Length;
            closeBtn.ScrollToCaret();
        }
        public string start_time;
        public string end_time;
        public int count_record_data;
        private void start_pause_Click(object sender, EventArgs e)
        {
            
            closed = true;
            
        }
        public String secToTimeformatString(int time)
        {
            TimeSpan times = TimeSpan.FromSeconds(time);
            return times.ToString(@"hh\:mm\:ss");
        }
        private void onScroll(object sender, ScrollEventArgs e)
        {
            canvas.Invalidate();
        }



        private void button3_Click(object sender, EventArgs e)
        {
            Form2 fm = new Form2();

            fm.loadData(list);
            fm.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void filterList_SelectedIndexChanged(object sender, EventArgs e)
        {
            l_filter = Convert.ToInt32(filterList.SelectedItem.ToString().Split(' ')[0]);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            h_filter = Convert.ToInt32(filterlist2.SelectedItem.ToString().Split(' ')[0]);
        }

        private Thread t;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            if (!isPortOpen)
            {

                //stopW.Start();
                // fm.ShowDialog();
                backgroundProc();// thread running
                closed = false;


            }
            else if (isPortOpen && closed == true)
            {
                backgroundProc();
                closed = false;
            }
            else
            {
                closed = false;
            }



        }




        private bool closed = true;
        private bool isThreadRunning = false;
        void backgroundProc()

        {

            t = new Thread(new ThreadStart(ReadBuffer));
            t.IsBackground = true;
            t.Start();
            isThreadRunning = true;
            // readBuffer1();

        }



        public bool flag = true;
        public List<String> get24Channel(List<String> str)
        {
            List<String> data = new List<String>();
            for (int i=0;i<str.Count;i++)
            {
              /*  int analogVal = 0;
                byte secondPart = (byte)(analogVal >> 8);
                int tempVal = analogVal << 8;
                byte firstPart = (byte)(tempVal >> 8);
                */
              
                int intValue = Convert.ToInt32(str[i+1]);//firstPart value
                int intvalue2 = Convert.ToInt32(str[i]);//second value

                int realVal = intvalue2 << 8;
                realVal |= intValue;
                i++;
                data.Add("" + realVal);
                   // data += realVal + " ";
            }
           
            
            return data;
        }

       
      
        void readBuffer1()
        {
            readDataFromText();
              Channellist.Invoke((MethodInvoker)delegate
               {
               if (list_20_str.Count == sample_rate)
                       {

                           list_20_str.Clear();


                           CustomControl2 cc = lineList[0] as CustomControl2;

                           cc.loadData(labLleist, l_filter, h_filter, isNotch, notch_range,
                               x_range, y_range, sample_rate, chart_top, sweep_rate, sweep_multiplier,gain);


                           for (int t = 0; t < labLleist.Count; t++)
                           {
                               CustomControl3Panel cc1 = labLleist[t] as CustomControl3Panel;
                               cc1.controlList.Clear();
                           }

                       }
                   /*  for (int i = 0; i < Channellist.SelectedIndex + 1; i++)
                     {

                         CustomControl2 cc = lineList[i] as CustomControl2;

                        // cc.loadData(list, l_filter, h_filter, isNotch, notch_range, x_range, y_range,sample_rate);
                         // System.Diagnostics.Debug.WriteLine("in1 count before " + cc.in1.Count);
                     }*/
               });
        }

        List<Complex> channel_list_20 = new List<Complex>();
        List<String> list_20_str = new List<string>();
        int b_count = 0;
        int flag1 = 0;
        Boolean first_data_flag = true;
        int zero_counter = 0;
        List<String> data_list = new List<string>();
        int sample_fill_count = 0;
        byte[] Concat1(byte[] a, byte[] b)
        {
            byte[] output = new byte[a.Length + b.Length];
            for (int i = 0; i < a.Length; i++)
                output[i] = a[i];
            for (int j = 0; j < b.Length; j++)
                output[a.Length + j] = b[j];
            return output;
        }
       
        int recvData;
        List<String> str = new List<String>();
        void ReadBuffer()

        {
            if (closed == false && isPortOpen == false)
            {
                aserialPort = new SerialPort(settings.PortList.Text);
                aserialPort.BaudRate = Convert.ToInt32(settings.bauderate.Text);

                aserialPort.Parity = Parity.None;
                aserialPort.StopBits = StopBits.One;
                aserialPort.DataBits = 8;
                aserialPort.ReadTimeout = -1;
                aserialPort.WriteTimeout = -1;
                aserialPort.Handshake = Handshake.None;
                if (!aserialPort.IsOpen)
                {
                    aserialPort.Open();
                    isPortOpen = true;


                }
            }

          
            while (!closed)
            {
               
                
               
               

                    if (aserialPort.BytesToRead > 0)
                    {


                         recvData = aserialPort.ReadByte();


                        data_list.Add(""+recvData);
                      //  Debug.WriteLine(""+ recvData);
                        if(recvData == 0)
                        {
                            zero_counter++;
                            if (zero_counter>=3) // to check end of line 
                            {
                               
                                if (first_data_flag) //for garbadge data drop first list 
                                {
                                    data_list.RemoveRange(0, data_list.Count-1);
                                    zero_counter = 0;
                                    first_data_flag = false;
                                }
                                else // valid end of data
                                {
                                    
                                    data_list.RemoveRange(data_list.Count - 3, 3);
                                 //  Debug.WriteLine("len:"+ data_list.Count);
                                    if (checkForLength(data_list))
                                    {
                                         loadMontage( get24Channel(data_list));
                                        data_list.RemoveRange(0, data_list.Count);
                                        zero_counter = 0;
                                        sample_fill_count++;

                                        if(sample_fill_count>=sample_rate) // when sample fill
                                        {

                                           // closed = true;
                                            sample_fill_count = 0;

                                            count_record_data++;
                                            CustomControl2 cc = lineList[0] as CustomControl2;

                                            cc.loadData(labLleist, l_filter, h_filter, isNotch, notch_range,
                                                x_range, y_range, sample_rate, chart_top, sweep_rate, sweep_multiplier, gain);


                                            for (int t = 0; t < labLleist.Count; t++)
                                            {
                                                CustomControl3Panel cc1 = labLleist[t] as CustomControl3Panel;
                                                cc1.controlList.Clear();
                                            }
                                        }
                                    }
                                    else
                                    {
                                        data_list.RemoveRange(0, data_list.Count);
                                        zero_counter = 0;
                                    }
                                }
                            }
                        }
                        else
                        {
                            zero_counter = 0;
                        }


               /*         if (list_20_str.Count == sample_rate)
                        {
                            count_record_data++;
                            Debug.WriteLine("time with real data " + stopW.Elapsed);
                            stopW.Restart();
                            // closed = true;

                            //System.Diagnostics.Debug.WriteLine("after ifft " + DateTime.Now.ToString("HH:mm:ss:ff"));


                            // Channellist.Invoke((MethodInvoker)delegate
                            // {
                            list_20_str.Clear();


                            CustomControl2 cc = lineList[0] as CustomControl2;

                            cc.loadData(labLleist, l_filter, h_filter, isNotch, notch_range,
                                x_range, y_range, sample_rate, chart_top, sweep_rate, sweep_multiplier);


                            for (int t = 0; t < labLleist.Count; t++)
                            {
                                CustomControl3Panel cc1 = labLleist[t] as CustomControl3Panel;
                                cc1.controlList.Clear();
                            }

                        }*/
                    }

                    else
                    {
                        closeBtn.Invoke((MethodInvoker)delegate
                        {
                            closeBtn.AppendText("incorrect data \n");
                        });
                    }




                    // System.Diagnostics.Debug.WriteLine("data1: " + line.ToString());
                }

           

        }
        public Boolean checkForLength(List<String> str)
        {
            if (str.Count == 48)
                return true;
            else
                return false;
        }
        
        int no1;
        int no2;
        double doubleValue1;
        double doubleValue2;
        CustomControl3Panel cc;
        Complex c1;


        public void loadMontage(List<String>str)
        {
            for (int i=0;i< channelIndex;i++)
            {
                String[] ch_list = montage_channel_list[i].Split('-');
                if (ch_list.Length>1)
                {
                     no1 = Int32.Parse(ch_list[0].ElementAt(1).ToString());
                     no2 = Int32.Parse(ch_list[1].ElementAt(1).ToString());


                    doubleValue1 = double.Parse(str[no1-1]);
                    doubleValue2 = double.Parse(str[no2-1]);

                   c1 = doubleValue1- doubleValue2;
                     cc = labLleist[i] as CustomControl3Panel;

                    cc.controlList.Add(c1);
                    
                    
                }
                else
                {
                     no1 = Int32.Parse(ch_list[0].Substring(1).ToString());
                    doubleValue1 = double.Parse(str[no1-1]);
                     c1 = doubleValue1;
                     cc = labLleist[i] as CustomControl3Panel;

                    cc.controlList.Add(c1);
                }
            }

            
            
        }
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //settings.ShowDialog();
        }

        private void notch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(notch.SelectedIndex == 0)
            {
                isNotch = true;
            }
            else
            {
                isNotch = false;
            }
        }
        private Random rnd = new Random();
        public int channelIndex;
        public void clearChart()
        {
            list_20_str.Clear();
            if (isThreadRunning)
            {
                closed = true;
            }
            
        }
        private void Channellist_SelectedIndexChanged(object sender, EventArgs e)
        {

            channelIndex = (Channellist.SelectedIndex + 1);
            clearChart();
            _top = 0;
            while (panel1.Controls.Count > 0)
            {
                panel1.Controls.RemoveAt(0);
                
            }
            while (lineList.Count > 0)
                lineList.RemoveAt(0);
            while (labLleist.Count > 0)
            {
                labLleist.RemoveAt(0);
                leftPanel.Controls.RemoveAt(0);
            }
                

            for (int i = 0; i <  1; i++)
            {

                if(isPatientData)
                    lineGraph = new CustomControl2(true);
                else lineGraph = new CustomControl2();
                
                lineGraph.Parent = panel1;
                lineGraph.Left = 0;
                lineGraph.series_count = channelIndex;
                lineGraph.BackColor = Color.Transparent;//Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256)); 
                lineGraph.Width = panel1.Width;
                lineGraph.Height = panel1.Height;//00;//_height_chart;
                lineGraph.createChartPanel(sample_rate,y_chart_min);
                panel1.Controls.Add(lineGraph);


                
                lineGraph.Top = _top;
                _top = _top + _height_chart;
                lineList.Add(lineGraph);
                lineGraph.label.Text = "F" + (i + 1);
                lineGraph.BringToFront();
                lineGraph.loadTimeline(sweep_multiplier);
            }
            chart_top = ((panel2.Height - 100) / 2) - (channelIndex * 28)/2;
           _top = ((panel2.Height-100)/ 2)-(channelIndex*28)/2 +30;
            /*    for (int g = 0; g < channelIndex; g++)
                {
                    CustomControl3Panel cp = new CustomControl3Panel();
                    cp.createChartPanel();
                    cp.label.Text = "F" + (g + 1);

                    cp.Width = 100;
                    cp.Top = _top;
                    _top = _top +32;
                    labLleist.Add(cp);
                    leftPanel.Controls.Add(cp);
                    cp.BringToFront();
                }*/
            montage_channel_list = ch_clear.ToArray();
            for (int y = 0; y < montage1.Montage_channels.Count; y++)
            {
                if (montage1.Montage_channels[y].montage_name == montage_list.Text)
                {
                    montage_channel_list = montage1.Montage_channels[y].channelList;
                    break;
                }
            }
            panel_y = (leftPanel.Height / channelIndex);
            if (montage_channel_list.Length>0)
            {
                for (int i = 0; i < channelIndex; i++)
                {

                    CustomControl3Panel cp = new CustomControl3Panel();
                    cp.createChartPanel();
                    cp.label.Text = montage_channel_list[i];

                    cp.Width = 100;
                    cp.Top = Convert.ToInt32((panel_y / 2) + (panel_y * i));
                    _top = _top + 32;
                    labLleist.Add(cp);
                    leftPanel.Controls.Add(cp);
                    cp.BringToFront();


                }
            }
            
            }
       public int y_chart_min = 200;//
        double y_scale;
        public bool isPatientData = false;
        public String patientName = "";
        public String patientID = "";
        public String patientAge = "";
        public String dateTime = "";
        public String p_montage = "";
        public String p_low = "";
        public String p_high = "";
        public String p_json_data = "";
        public int record_duration = 0;
        public int pagecount = 1;
        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            notch_range = Convert.ToInt32(comboBox1.SelectedItem);
        }

        public void readDataFromText()
        {
            StreamReader inp_stm = new StreamReader("C://data6.txt");
            
            while (!inp_stm.EndOfStream)
            {
                string line = inp_stm.ReadLine();
               // double doubleValue = double.Parse(line);
                //   System.Diagnostics.Debug.WriteLine(""+ doubleValue);
              //  System.Numerics.Complex c1 = doubleValue;

               // list.Add(c1);
                // Do Something with the input.
                List<String> str = new List<String>();
                String[] str1 = line.Split(' ');
                double data;
                if (str1.Length == 25)
                {
                    list_20_str.Add(line);
                    if (list_20_str.Count > 1) stopW.Start();

                    for (int j = 0; j < 24; j++)
                    {
                        bool result1 = double.TryParse(line.Split(' ')[j], out data);
                        if (result1)
                            str.Add(line.Split(' ')[j]);
                        else
                            str.Add("0");
                    }
                    loadMontage(str);

                    
                }
                }

            inp_stm.Close();
        }

        private void x_range_Scroll(object sender, EventArgs e)
        {
            x_range = x_range_track.Value;
            x_duration.Text = "" + (x_range);
        }
        private float f1;
        private void y_range_track_Scroll(object sender, EventArgs e)
        {

            y_range = (((float)y_range_track.Value / (float)100));

            gain_y.Text = "" + (y_range);
        }
        MontageSetting montage1 = new MontageSetting();
        private void montageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            montage1.loadChannel();
            montage1.ShowDialog();
           
          //  montage.BringToFront();
        }

        private void baudeRateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            settings.ShowDialog();
            settings.BringToFront();
        }
         List<Montage> montage_channel = new List<Montage>();

       
        private void montage_list_Click(object sender, EventArgs e)
        {
            while(montage_list.Items.Count>0)
            montage_list.Items.RemoveAt(0);
            for (int i =0;i<montage1.Montage_channels.Count;i++)
            {
               
                    montage_list.Items.Add(montage1.Montage_channels[i].montage_name);
                
               
            }
            //montage_list.DataSource = montage.montage_channels;
            montage_list.Invalidate();
            
        }

        String[] montage_channel_list = { };
        String[] ch_clear = new String[] { };
        private void changeChannel(object sender, EventArgs e)
        {
            clearChart();
            _top = 0;
            while (panel1.Controls.Count > 0)
            {
                panel1.Controls.RemoveAt(0);

            }
            while (lineList.Count > 0)
                lineList.RemoveAt(0);
            while (labLleist.Count > 0)
            {
                labLleist.RemoveAt(0);
                leftPanel.Controls.RemoveAt(0);
            }


           if(isPatientData)
               lineGraph = new CustomControl2(true);
            else lineGraph = new CustomControl2();
            lineGraph.Parent = panel1;
                lineGraph.Left = 0;
                lineGraph.series_count = channelIndex;
                lineGraph.BackColor = Color.Transparent;//Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256)); 
                lineGraph.Width = panel1.Width;
                lineGraph.Height = panel1.Height;//_height_chart;
                lineGraph.createChartPanel(sample_rate, y_chart_min);
                panel1.Controls.Add(lineGraph);

                lineGraph.Top = _top;
                _top = _top + _height_chart;
                lineList.Add(lineGraph);
                lineGraph.label.Text = "F" + (i + 1);
                lineGraph.BringToFront();
                lineGraph.loadTimeline(sweep_multiplier);

            chart_top = ((panel2.Height - 100) / 2) - (channelIndex * 28) / 2;
            _top = ((panel2.Height - 100) / 2) - (channelIndex * 28) / 2 + 30;
           // chart_top = _top = ((panel2.Height - 100) / 2) - (channelIndex * 28) / 2;
            montage_channel_list = ch_clear.ToArray();
            for (int y=0;y< montage1.Montage_channels.Count;y++)
            {
                if (montage1.Montage_channels[y].montage_name == montage_list.Text)
                {
                    montage_channel_list = montage1.Montage_channels[y].channelList;
                    break;
                }
            }
            panel_y = (leftPanel.Height / channelIndex);
            for (int i = 0; i < channelIndex; i++)
            {
               
                    CustomControl3Panel cp = new CustomControl3Panel();
                    cp.createChartPanel();
                    cp.label.Text = montage_channel_list[i];

                    cp.Width = 100;
                cp.Top = Convert.ToInt32((panel_y / 2) + (panel_y * i));
                _top = _top + 32;
                    labLleist.Add(cp);
                    leftPanel.Controls.Add(cp);
                    cp.BringToFront();


            }
        }


        public void calculatenValue_MontageChannel()
        {

        }
        private void montageToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public CustomControl2 lineGraph;
        private void pictureBox5_Click(object sender, EventArgs e)
        {

            
            lineGraph.timer1.Stop();
            if (isThreadRunning)
            {
                t.Abort();
                aserialPort.Close();
            }
            this.Close();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.Invalidate();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            this.Invalidate();
            this.Update();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
        public double sweep_rate;
        public double sweep_multiplier=1;
        public double timeline_index = 0;
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            sweep_rate = Convert.ToDouble(sweep_combo.SelectedItem);
            if (sweep_rate == 30)
            {
                sweep_multiplier = 1;
               
            }
            else if (sweep_rate == 15)
            {
                sweep_multiplier = 2;
               
            }
            else if (sweep_rate == 7.5)
            {
                sweep_multiplier = 4;
            }
            else
            {
                sweep_multiplier = 0.5;
               
            }

           
            CustomControl2 cc = lineList[0] as CustomControl2;
            if (cc.isCreated)
                cc.clearChart();
            cc.loadTimeline(sweep_multiplier);
        }
        public int panel_y;
        private void sensitivity_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            y_chart_min = Convert.ToInt32(sensitivity_list.SelectedItem);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            lineGraph.onClickPrint(panel2, leftPanel,patientID,patientName, patientAge, dateTime,p_montage,p_high,p_low);
        }
        public void viewMontage(string montage)
        {
            String[] arr = montage.Split('|');
            p_montage = arr[0];
            channelIndex = arr.Length - 1;
            _top = 0;
           // montage_list.Text = p_montage;
           // Channellist.Text = "" + channelIndex;
           // filterList.Text = lpass;
           // filterlist2.Text = hpass;

            while (labLleist.Count > 0)
            {
                labLleist.RemoveAt(0);
                leftPanel.Controls.RemoveAt(0);
            }
           
            panel_y = (leftPanel.Height / channelIndex);
            
            for (int i = 0; i < channelIndex; i++)
            {

                CustomControl3Panel cp = new CustomControl3Panel();
                cp.createChartPanel();
                cp.label.Text = montage_channel_list[i];

                cp.Width = 100;
                cp.Top = Convert.ToInt32((panel_y / 2) + (panel_y * i));
                _top = _top + 32;
                labLleist.Add(cp);
                leftPanel.Controls.Add(cp);
                cp.BringToFront();


            }
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
            if (lineGraph.isRecordStarted == false)
            {
                start_time = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
                lineGraph.isRecordStarted = true;
                record.Image = WindowsFormsApp1.Properties.Resources.rec_on;
            }
            else
            {
                string str = JsonConvert.SerializeObject(lineGraph.patientDataseies.Pseries);
                lineGraph.p_data_list.Clear();
                
                string montage2 = montage_list.Text;
                for (int i = 0; i < labLleist.Count; i++)
                {
                    CustomControl3Panel cp = labLleist[i] as CustomControl3Panel;
                    montage2 = montage2 + "|" + cp.label.Text;
                }

                pg.insertPatientRecord(patient_id, start_time, end_time, secToTimeformatString(lineGraph.duration_count), str, montage2, filterlist2.Text, filterList.Text);

                lineGraph.clearRecord();
                record.Image = WindowsFormsApp1.Properties.Resources.rec_off;
            }
        }

        private void prev_Click(object sender, EventArgs e)
        {
            pagecount--;
            lineGraph.viewDataOnChartFromDB(p_json_data, y_chart_min, sample_rate, record_duration, pagecount);

            checkNextPageAvailable();
            checkPrevPageAvailable();
        }
        public Boolean checkNextPageAvailable()
        {
            Boolean flag = false;
            if (record_duration>10*(pagecount))
            {
                next.Enabled = true;
                next.Image = WindowsFormsApp1.Properties.Resources.next1;
            }
            else
            {
                next.Image = WindowsFormsApp1.Properties.Resources.next_d;
                next.Enabled = false;
              
            }
            return flag;
        }
        public Boolean checkPrevPageAvailable()
        {
            Boolean flag = false;
            if (pagecount>1)
            {
                prev.Enabled = true;
                prev.Image = WindowsFormsApp1.Properties.Resources.prev1;
            }
            else
            {
                prev.Image = WindowsFormsApp1.Properties.Resources.prev_d;
                prev.Enabled = false;

            }
            return flag;
        }

        public void disableNextPrev()
        {
            prev.Image = WindowsFormsApp1.Properties.Resources.prev_d;
            prev.Enabled = false;
            next.Image = WindowsFormsApp1.Properties.Resources.next_d;
            next.Enabled = false;
        }
       

      
        private void next_click(object sender, EventArgs e)
        {
            pagecount++;
                lineGraph.viewDataOnChartFromDB(p_json_data, y_chart_min, sample_rate, record_duration, pagecount);
          
            checkNextPageAvailable();
            checkPrevPageAvailable();

        }
        
        private void comboBox_gain_SelectedIndexChanged(object sender, EventArgs e)
        {
            gain = Convert.ToInt32(comboBox_gain.SelectedItem) *10;
        }
    }
}
