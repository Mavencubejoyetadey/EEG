namespace WindowsFormsApp1
{
    partial class Settings
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PortList = new System.Windows.Forms.ComboBox();
            this.bauderate = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ports";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Bauderate";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // PortList
            // 
            this.PortList.FormattingEnabled = true;
            this.PortList.Location = new System.Drawing.Point(90, 31);
            this.PortList.Name = "PortList";
            this.PortList.Size = new System.Drawing.Size(121, 21);
            this.PortList.TabIndex = 2;
            // 
            // bauderate
            // 
            this.bauderate.Location = new System.Drawing.Point(90, 84);
            this.bauderate.Name = "bauderate";
            this.bauderate.Size = new System.Drawing.Size(121, 20);
            this.bauderate.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(356, 316);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 362);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bauderate);
            this.Controls.Add(this.PortList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Settings";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox PortList;
        public System.Windows.Forms.TextBox bauderate;
        private System.Windows.Forms.Button button1;
    }
}