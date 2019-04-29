using EEGSoftWare;
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
    public partial class MontageSetting : Form
    {
       
        public MontageSetting()
        {
            InitializeComponent();
            montageComp1.changeText("FP1",1);
            montageComp2.changeText("FP2",2);
            montageComp3.changeText("F7",3);
            montageComp4.changeText("F3",4);
            montageComp5.changeText("FZ",5);
            montageComp6.changeText("F4",6);
            montageComp7.changeText("F8",7);
            montageComp8.changeText("T3",8);
            montageComp9.changeText("C3",9);
            montageComp10.changeText("CZ",10);
            montageComp11.changeText("C4",11);
            montageComp12.changeText("T4",12);
            montageComp13.changeText("A1",13);
            montageComp14.changeText("A2",14);
            montageComp15.changeText("T5",15);
            montageComp16.changeText("P3",16);
            montageComp17.changeText("PZ",17);
            montageComp18.changeText("P4",18);
            montageComp19.changeText("T6",19);
           
            montageComp20.changeText("O1",20);
            montageComp21.changeText("O2",21);
            Montage_name.SelectedIndex = 0;

            montageComp22.changeText("EKG",22);
            montageComp23.changeText("EMG1",23);
            montageComp24.changeText("RESP.",24);
            montageComp25.changeText("EMG",25);
            montageComp26.changeText("BP1",26);
            montageComp27.changeText("ENG",27);
            montageComp28.changeText("PG1",28);
            montageComp29.changeText("DC2",29);
            montageComp30.changeText("BP2",30);
            montageComp31.changeText("PG2",31);
            montageComp32.changeText("DC3",32);
           

        }
        public void loadChannel()
        {
            for (int i=0;i< Montage_channels.Count;i++)
            {
                if (Montage_channels[i].montage_name == Montage_name.Text)
                {
                    for (int y=0;y< Montage_channels[i].channelList.Length;y++)
                    {
                        if(y+1 == Montage_channels[i].channelList.Length)
                        {
                            montageWave.Text += Montage_channels[i].channelList[y];
                        }
                        else
                        montageWave.Text += Montage_channels[i].channelList[y] + '\n';
                    }
                    break;
                }
            }
        }
        
        private void MontageSetting_Load(object sender, EventArgs e)
        {

        }
        public List<string> channels = new List<string> { };
        private List<Montage> montage_channels = new List<Montage> { };

        internal List<Montage> Montage_channels { get => montage_channels; set => montage_channels = value; }

        private void button1_Click(object sender, EventArgs e)
        {
            if (montageInput.Text != "" && !(montageInput.Text.Contains("-")))
            {
                montageInput.Text += "-";
            }
        }

        private void channel_CheckedChanged(object sender, EventArgs e)
        {
            
           // channels.Add((sender as CheckBox).Text);
            if (montageInput.Text == "")
            {
                montageInput.Text = (sender as MontageComp).lab.Text;
                channels.Add((sender as MontageComp).lab.Text);
            }
            else
            {
               if(montageInput.Text.Contains("-"))
                {
                    if (channels.Count < 2)
                    {
                        channels.Add((sender as MontageComp).lab.Text);
                        montageInput.Text = channels[0].ToString() + "-" + channels[1];
                    }
                    else
                    {
                        channels.RemoveAt(1);
                        channels.Add((sender as MontageComp).lab.Text);
                        montageInput.Text = channels[0].ToString() + "-" + channels[1];
                    }
                   
                }
                else
                {
                    channels.RemoveAt(0);
                    channels.Add((sender as MontageComp).lab.Text);
                    montageInput.Text = (sender as MontageComp).lab.Text;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            montageInput.Text = "";
           
            while (channels.Count>0)
            channels.RemoveAt(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {

          //  Montage_channels.Add(new Montage(Montage_name.Text, montageInput.Text));
            if (montageWave.Text!= "")
                montageWave.Text += "\n"+montageInput.Text;
            else
                montageWave.Text += montageInput.Text;
            while (channels.Count > 0)
                channels.RemoveAt(0);
            montageInput.Text = "";
        }

        private void montageComp1_Click(object sender, EventArgs e)
        {

        }
      
        private void button4_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void b_Click(object sender, EventArgs e)
        {
            String[] list = montageWave.Text.Split('\n');
            Montage_channels.Add(new Montage(Montage_name.Text, list));
           
        }

        private void Montage_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            montageWave.Text = "";
            loadChannel();
        }

        private void montageComp22_Click(object sender, EventArgs e)
        {

        }

        private void montageComp26_Click(object sender, EventArgs e)
        {

        }
    }
}
