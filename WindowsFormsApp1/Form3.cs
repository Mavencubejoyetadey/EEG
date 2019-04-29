using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathNet.Numerics;
using MathNet.Numerics.IntegralTransforms;
using System.Numerics;
using System.Windows.Forms.DataVisualization;
namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
       static int numsamples = 500;
        static double sampleRate = 2000;
        Complex[] samples = new Complex[numsamples];
        static int magsecond;
        static int magthird;
        static double PHsecond;
        static double PHthird;
        public void plotWaveForm(int secondHarm,int thirdharm,double secondPH,double thirdPH)
        {
            chart1.Series["WaveForm"].Points.Clear();
            chart1.Series["SecondHarmonic"].Points.Clear();
            chart1.Series["ThirdHarmonic"].Points.Clear();

            double[] fundamental = Generate.Sinusoidal(numsamples,sampleRate,50,10.0);
            double[] second = Generate.Sinusoidal(numsamples, sampleRate, 120, 0.0,secondPH);
            double[] third = Generate.Sinusoidal(numsamples, sampleRate, 180, 0.0,thirdPH);

            for (int i =0;i<numsamples;i++)
            {
                samples[i] = new Complex(fundamental[i]+second[i]+third[i],0);
            }
            for (int i=0;i<samples.Length/5;i++)

            {
                double time = ((i + 1.0) / numsamples) / 2;
                if (checkBox1.Checked)
                {
                    chart1.Series["SecondHarmonic"].Points.AddXY(time, second[i]);
                }
                if (checkBox2.Checked)
                {
                    chart1.Series["ThirdHarmonic"].Points.AddXY(time,third[i]);
                }
                chart1.Series["WaveForm"].Points.AddXY(time, samples[i].Real);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            plotWaveForm(0,0,0,0);
        }
        public void PlotFFT()
        {
            chart2.Series["Frequency"].Points.Clear();
            Fourier.Forward(samples,FourierOptions.NoScaling);
           // Fourier.Inverse(samples, FourierOptions.Matlab);
            for (int i =0;i<samples.Length/10;i++)
            {
                double time = ((i + 1.0) / numsamples) / 2;
                double mag = (2.0 / numsamples) * Math.Abs(Math.Sqrt(Math.Pow(samples[i].Real, 2) + Math.Pow(samples[i].Imaginary, 2)));
                double HZPerSample = sampleRate / numsamples;
                chart2.Series["Frequency"].Points.AddXY(time, samples[i].Real);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            PlotFFT();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            trackBar3ph.Enabled = true;
            magsecond = trackBar1.Value;
            plotWaveForm(magsecond,magthird,PHsecond,PHthird);
            PlotFFT();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            trackBar3ph.Enabled = true;
            magthird = trackBar2.Value;
            plotWaveForm(magsecond, magthird, PHsecond, PHthird);
            PlotFFT();
        }
    }
}
