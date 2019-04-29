namespace EEGSoftWare
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.filterList = new System.Windows.Forms.ComboBox();
            this.filterlist2 = new System.Windows.Forms.ComboBox();
            this.notch = new System.Windows.Forms.ComboBox();
            this.x_range_track = new System.Windows.Forms.TrackBar();
            this.y_range_track = new System.Windows.Forms.TrackBar();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.Channellist = new System.Windows.Forms.ComboBox();
            this.montage_list = new System.Windows.Forms.ComboBox();
            this.sensitivity_list = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.sweep_combo = new System.Windows.Forms.ComboBox();
            this.sppedbar = new System.Windows.Forms.TrackBar();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.portsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.canvas = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.closeBtn = new System.Windows.Forms.RichTextBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.button3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Duration = new System.Windows.Forms.Label();
            this.x_duration = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.gain_y = new System.Windows.Forms.Label();
            this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.portsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.baudeRateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.montageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.baudeRateToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.montageToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.montageToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.reportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.montageToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.paitentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leftPanel = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.x_range_track)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.y_range_track)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sppedbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 15;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 174F));
            this.tableLayoutPanel1.Controls.Add(this.pictureBox2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.filterList, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.filterlist2, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.notch, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.x_range_track, 11, 0);
            this.tableLayoutPanel1.Controls.Add(this.y_range_track, 12, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox4, 10, 0);
            this.tableLayoutPanel1.Controls.Add(this.Channellist, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.montage_list, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.sensitivity_list, 8, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboBox1, 14, 0);
            this.tableLayoutPanel1.Controls.Add(this.sweep_combo, 9, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 40);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1285, 49);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::WindowsFormsApp1.Properties.Resources.record;
            this.pictureBox2.Location = new System.Drawing.Point(58, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 30);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::WindowsFormsApp1.Properties.Resources.pause;
            this.pictureBox3.Location = new System.Drawing.Point(96, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(39, 39);
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.start_pause_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WindowsFormsApp1.Properties.Resources.start;
            this.pictureBox1.Location = new System.Drawing.Point(13, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(39, 39);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // filterList
            // 
            this.filterList.FormattingEnabled = true;
            this.filterList.Items.AddRange(new object[] {
            "0 Hz",
            "1 Hz",
            "2 Hz",
            "3 Hz",
            "10 Hz",
            "20 Hz"});
            this.filterList.Location = new System.Drawing.Point(341, 3);
            this.filterList.Name = "filterList";
            this.filterList.Size = new System.Drawing.Size(94, 21);
            this.filterList.TabIndex = 9;
            this.filterList.SelectedIndexChanged += new System.EventHandler(this.filterList_SelectedIndexChanged);
            // 
            // filterlist2
            // 
            this.filterlist2.FormattingEnabled = true;
            this.filterlist2.Items.AddRange(new object[] {
            "15 Hz",
            "35 Hz",
            "60 Hz",
            "70 Hz",
            "100 Hz",
            "120 Hz",
            "180 Hz",
            "240 Hz"});
            this.filterlist2.Location = new System.Drawing.Point(441, 3);
            this.filterlist2.Name = "filterlist2";
            this.filterlist2.Size = new System.Drawing.Size(94, 21);
            this.filterlist2.TabIndex = 0;
            this.filterlist2.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // notch
            // 
            this.notch.FormattingEnabled = true;
            this.notch.Items.AddRange(new object[] {
            "ON",
            "OFF"});
            this.notch.Location = new System.Drawing.Point(541, 3);
            this.notch.Name = "notch";
            this.notch.Size = new System.Drawing.Size(94, 21);
            this.notch.TabIndex = 0;
            this.notch.SelectedIndexChanged += new System.EventHandler(this.notch_SelectedIndexChanged);
            // 
            // x_range_track
            // 
            this.x_range_track.BackColor = System.Drawing.Color.WhiteSmoke;
            this.x_range_track.Location = new System.Drawing.Point(941, 3);
            this.x_range_track.Minimum = 1;
            this.x_range_track.Name = "x_range_track";
            this.x_range_track.Size = new System.Drawing.Size(94, 43);
            this.x_range_track.TabIndex = 13;
            this.x_range_track.Value = 8;
            this.x_range_track.Visible = false;
            this.x_range_track.Scroll += new System.EventHandler(this.x_range_Scroll);
            // 
            // y_range_track
            // 
            this.y_range_track.Location = new System.Drawing.Point(1041, 3);
            this.y_range_track.Maximum = 200;
            this.y_range_track.Minimum = 120;
            this.y_range_track.Name = "y_range_track";
            this.y_range_track.Size = new System.Drawing.Size(59, 43);
            this.y_range_track.TabIndex = 14;
            this.y_range_track.TickFrequency = 10;
            this.y_range_track.Value = 120;
            this.y_range_track.Visible = false;
            this.y_range_track.Scroll += new System.EventHandler(this.y_range_track_Scroll);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::WindowsFormsApp1.Properties.Resources.print;
            this.pictureBox4.Location = new System.Drawing.Point(841, 3);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(59, 39);
            this.pictureBox4.TabIndex = 17;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // Channellist
            // 
            this.Channellist.FormattingEnabled = true;
            this.Channellist.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.Channellist.Location = new System.Drawing.Point(241, 3);
            this.Channellist.Name = "Channellist";
            this.Channellist.Size = new System.Drawing.Size(89, 21);
            this.Channellist.TabIndex = 7;
            this.Channellist.SelectedIndexChanged += new System.EventHandler(this.Channellist_SelectedIndexChanged);
            // 
            // montage_list
            // 
            this.montage_list.FormattingEnabled = true;
            this.montage_list.Location = new System.Drawing.Point(141, 3);
            this.montage_list.Name = "montage_list";
            this.montage_list.Size = new System.Drawing.Size(89, 21);
            this.montage_list.TabIndex = 16;
            this.montage_list.SelectedValueChanged += new System.EventHandler(this.changeChannel);
            this.montage_list.Click += new System.EventHandler(this.montage_list_Click);
            // 
            // sensitivity_list
            // 
            this.sensitivity_list.FormattingEnabled = true;
            this.sensitivity_list.Items.AddRange(new object[] {
            "200",
            "1000",
            "500",
            "300",
            "10"});
            this.sensitivity_list.Location = new System.Drawing.Point(641, 3);
            this.sensitivity_list.Name = "sensitivity_list";
            this.sensitivity_list.Size = new System.Drawing.Size(94, 21);
            this.sensitivity_list.TabIndex = 11;
            this.sensitivity_list.SelectedIndexChanged += new System.EventHandler(this.sensitivity_list_SelectedIndexChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.comboBox1.Location = new System.Drawing.Point(1114, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 12;
            this.comboBox1.Visible = false;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_1);
            // 
            // sweep_combo
            // 
            this.sweep_combo.FormattingEnabled = true;
            this.sweep_combo.Items.AddRange(new object[] {
            "7.5",
            "15",
            "30",
            "60"});
            this.sweep_combo.Location = new System.Drawing.Point(741, 3);
            this.sweep_combo.Name = "sweep_combo";
            this.sweep_combo.Size = new System.Drawing.Size(94, 21);
            this.sweep_combo.TabIndex = 18;
            this.sweep_combo.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // sppedbar
            // 
            this.sppedbar.Location = new System.Drawing.Point(1027, 118);
            this.sppedbar.Maximum = 200;
            this.sppedbar.Minimum = 10;
            this.sppedbar.Name = "sppedbar";
            this.sppedbar.Size = new System.Drawing.Size(94, 45);
            this.sppedbar.TabIndex = 13;
            this.sppedbar.TickFrequency = 10;
            this.sppedbar.Value = 10;
            this.sppedbar.Visible = false;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.portsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // portsToolStripMenuItem
            // 
            this.portsToolStripMenuItem.Name = "portsToolStripMenuItem";
            this.portsToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.portsToolStripMenuItem.Text = "Ports";
            // 
            // configurationToolStripMenuItem
            // 
            this.configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            this.configurationToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.configurationToolStripMenuItem.Text = "Configuration";
            // 
            // chart2
            // 
            this.chart2.BackColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart2.Legends.Add(legend1);
            this.chart2.Location = new System.Drawing.Point(447, 109);
            this.chart2.Name = "chart2";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart2.Series.Add(series1);
            this.chart2.Size = new System.Drawing.Size(300, 300);
            this.chart2.TabIndex = 5;
            this.chart2.Text = "chart2";
            this.chart2.Visible = false;
            // 
            // canvas
            // 
            this.canvas.AutoScroll = true;
            this.canvas.AutoSize = true;
            this.canvas.BackColor = System.Drawing.Color.Red;
            this.canvas.Location = new System.Drawing.Point(107, 67);
            this.canvas.MaximumSize = new System.Drawing.Size(800, 0);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(800, 0);
            this.canvas.TabIndex = 8;
            this.canvas.Scroll += new System.Windows.Forms.ScrollEventHandler(this.onScroll);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Location = new System.Drawing.Point(0, 109);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(843, 410);
            this.panel1.TabIndex = 10;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(876, 109);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(138, 561);
            this.closeBtn.TabIndex = 11;
            this.closeBtn.Text = "";
            this.closeBtn.Visible = false;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(1112, 35);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 13;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(190)))), ((int)(((byte)(226)))));
            this.label2.Location = new System.Drawing.Point(638, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Sensitivity";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(190)))), ((int)(((byte)(226)))));
            this.label3.Location = new System.Drawing.Point(338, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Low pass";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(190)))), ((int)(((byte)(226)))));
            this.label4.Location = new System.Drawing.Point(438, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "High pass";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(190)))), ((int)(((byte)(226)))));
            this.label5.Location = new System.Drawing.Point(544, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Notch";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(190)))), ((int)(((byte)(226)))));
            this.label7.Location = new System.Drawing.Point(1109, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Notch Range";
            this.label7.Visible = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // Duration
            // 
            this.Duration.AutoSize = true;
            this.Duration.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(190)))), ((int)(((byte)(226)))));
            this.Duration.Location = new System.Drawing.Point(781, 35);
            this.Duration.Name = "Duration";
            this.Duration.Size = new System.Drawing.Size(47, 13);
            this.Duration.TabIndex = 21;
            this.Duration.Text = "Duration";
            this.Duration.Visible = false;
            // 
            // x_duration
            // 
            this.x_duration.AutoSize = true;
            this.x_duration.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(190)))), ((int)(((byte)(226)))));
            this.x_duration.Location = new System.Drawing.Point(829, 35);
            this.x_duration.Name = "x_duration";
            this.x_duration.Size = new System.Drawing.Size(35, 13);
            this.x_duration.TabIndex = 22;
            this.x_duration.Text = "label6";
            this.x_duration.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(190)))), ((int)(((byte)(226)))));
            this.label6.Location = new System.Drawing.Point(877, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Gain";
            this.label6.Visible = false;
            // 
            // gain_y
            // 
            this.gain_y.AutoSize = true;
            this.gain_y.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(190)))), ((int)(((byte)(226)))));
            this.gain_y.Location = new System.Drawing.Point(907, 26);
            this.gain_y.Name = "gain_y";
            this.gain_y.Size = new System.Drawing.Size(35, 13);
            this.gain_y.TabIndex = 24;
            this.gain_y.Text = "label8";
            this.gain_y.Visible = false;
            // 
            // fileToolStripMenuItem1
            // 
            this.fileToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.portsToolStripMenuItem1,
            this.baudeRateToolStripMenuItem});
            this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            this.fileToolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem1.Text = "File";
            // 
            // portsToolStripMenuItem1
            // 
            this.portsToolStripMenuItem1.Name = "portsToolStripMenuItem1";
            this.portsToolStripMenuItem1.Size = new System.Drawing.Size(130, 22);
            this.portsToolStripMenuItem1.Text = "Ports";
            // 
            // baudeRateToolStripMenuItem
            // 
            this.baudeRateToolStripMenuItem.Name = "baudeRateToolStripMenuItem";
            this.baudeRateToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.baudeRateToolStripMenuItem.Text = "Baude rate";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.montageToolStripMenuItem,
            this.baudeRateToolStripMenuItem1});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // montageToolStripMenuItem
            // 
            this.montageToolStripMenuItem.Name = "montageToolStripMenuItem";
            this.montageToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.montageToolStripMenuItem.Text = "Montage Setting";
            this.montageToolStripMenuItem.Click += new System.EventHandler(this.montageToolStripMenuItem_Click);
            // 
            // baudeRateToolStripMenuItem1
            // 
            this.baudeRateToolStripMenuItem1.Name = "baudeRateToolStripMenuItem1";
            this.baudeRateToolStripMenuItem1.Size = new System.Drawing.Size(162, 22);
            this.baudeRateToolStripMenuItem1.Text = "Baude Rate";
            this.baudeRateToolStripMenuItem1.Click += new System.EventHandler(this.baudeRateToolStripMenuItem1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem1,
            this.settingsToolStripMenuItem,
            this.montageToolStripMenuItem1,
            this.montageToolStripMenuItem2,
            this.reportToolStripMenuItem,
            this.montageToolStripMenuItem3,
            this.paitentToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1362, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // montageToolStripMenuItem1
            // 
            this.montageToolStripMenuItem1.Name = "montageToolStripMenuItem1";
            this.montageToolStripMenuItem1.Size = new System.Drawing.Size(56, 20);
            this.montageToolStripMenuItem1.Text = "Record";
            this.montageToolStripMenuItem1.Click += new System.EventHandler(this.montageToolStripMenuItem1_Click);
            // 
            // montageToolStripMenuItem2
            // 
            this.montageToolStripMenuItem2.Name = "montageToolStripMenuItem2";
            this.montageToolStripMenuItem2.Size = new System.Drawing.Size(60, 20);
            this.montageToolStripMenuItem2.Text = "Preview";
            // 
            // reportToolStripMenuItem
            // 
            this.reportToolStripMenuItem.Name = "reportToolStripMenuItem";
            this.reportToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.reportToolStripMenuItem.Text = "Report";
            // 
            // montageToolStripMenuItem3
            // 
            this.montageToolStripMenuItem3.Name = "montageToolStripMenuItem3";
            this.montageToolStripMenuItem3.Size = new System.Drawing.Size(67, 20);
            this.montageToolStripMenuItem3.Text = "Montage";
            // 
            // paitentToolStripMenuItem
            // 
            this.paitentToolStripMenuItem.Name = "paitentToolStripMenuItem";
            this.paitentToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.paitentToolStripMenuItem.Text = "Paitent";
            // 
            // leftPanel
            // 
            this.leftPanel.Location = new System.Drawing.Point(0, 0);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(135, 100);
            this.leftPanel.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(190)))), ((int)(((byte)(226)))));
            this.label9.Location = new System.Drawing.Point(142, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 13);
            this.label9.TabIndex = 31;
            this.label9.Text = "Montage Profile";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(741, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "Sweep (mm/s)";
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox6.Image = global::WindowsFormsApp1.Properties.Resources.minimize;
            this.pictureBox6.Location = new System.Drawing.Point(1134, 1);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(24, 24);
            this.pictureBox6.TabIndex = 30;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.Click += new System.EventHandler(this.pictureBox6_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox5.Image = global::WindowsFormsApp1.Properties.Resources.close2;
            this.pictureBox5.Location = new System.Drawing.Point(1158, 1);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(24, 24);
            this.pictureBox5.TabIndex = 29;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.eeg_grid;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel2.Location = new System.Drawing.Point(4, 98);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(839, 393);
            this.panel2.TabIndex = 26;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.gard;
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel4.Controls.Add(this.label8);
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(200, 100);
            this.panel4.TabIndex = 28;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(190)))), ((int)(((byte)(226)))));
            this.label8.Location = new System.Drawing.Point(242, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "Channel";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1362, 682);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gain_y);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.x_duration);
            this.Controls.Add(this.Duration);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.sppedbar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.canvas);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.leftPanel);
            this.Controls.Add(this.panel4);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "EEG Software";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.x_range_track)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.y_range_track)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sppedbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox Channellist;
        private System.Windows.Forms.ComboBox filterList;
        private System.Windows.Forms.ComboBox sensitivity_list;
        private System.Windows.Forms.TrackBar sppedbar;
        private System.IO.Ports.SerialPort serialPort1;
        //private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem portsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configurationToolStripMenuItem;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.Panel canvas;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.RichTextBox closeBtn;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox notch;
        private System.Windows.Forms.ComboBox filterlist2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TrackBar x_range_track;
        private System.Windows.Forms.TrackBar y_range_track;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label Duration;
        private System.Windows.Forms.Label x_duration;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label gain_y;
        private System.Windows.Forms.ComboBox montage_list;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem portsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem baudeRateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem montageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem baudeRateToolStripMenuItem1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem montageToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem montageToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem reportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem montageToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem paitentToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox sweep_combo;
        private System.Windows.Forms.Label label1;
    }
}

