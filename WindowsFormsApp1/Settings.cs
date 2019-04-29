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
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }
        public string[] ports_list = new string[] { };
        public string bauderate_s = "";
        private void label2_Click(object sender, EventArgs e)
        {

        }
        public void init()
        {
            PortList.Items.AddRange(ports_list);
            bauderate.Text = bauderate_s;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
