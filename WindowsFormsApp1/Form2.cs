using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DSPLib;
using System.Numerics;

using MathNet.Numerics.Providers.FourierTransform;
using MathNet.Numerics.IntegralTransforms;
namespace WindowsFormsApp1
{

    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        List<Complex> list2 = new List<Complex>();
        List<Complex> list1 = new List<Complex>();
        int c = 10;
        public Boolean flag = false;


        public void loadData(List<Complex> list2)
        {


            /*      Complex[] input = new Complex[1024];
                  Complex[] output = new Complex[input.Length];
                  double[] out1 = new double[input.Length];

                  for (int i = 0; i < 1024; i++)
                  {
        //  100*sin(2*PI*freq*timeVal)
                      input[i] = Math.Sin(i * 2 * Math.PI * 50 );
                      out1[i] = i;
                  }*/

            /*
                                   using (var pinIn = new PinnedArray<Complex>(input))
                                   using (var pinOut = new PinnedArray<Complex>(output))
                                   {
                                       FFTW.NET.DFT.FFT(pinIn, pinOut);
                                       //FFTW.NET.DFT.IFFT(pinOut, pinOut);
                                   }

                                   double[] in1 = DSP.ConvertComplex.ToMagnitude(output);
                                   chart1.ChartAreas[0].AxisY.Minimum = -1;
                                   chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineWidth = 0;
                                   chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineWidth = 0;
                                   chart1.Series["Series1"].Points.DataBindXY(out1, in1);
                                   // double[] ou1 = DSP.ConvertComplex.ToMagnitude(xx);

                                   */
            chart1.Series["Series1"].Points.Clear();
            Complex[] input = new Complex[]{ };
                // Complex[] xx = new Complex[1024];
                // xx = list1.ToArray();
                 input = list2.ToArray();
  Fourier.Forward(input, FourierOptions.NoScaling);
            int numsamples = 1024;
            double sampleRate = 1024;
            double[] outMag = new double[input.Length];
            int l_pass = 10;
            int h_pass = 120;
            int notch_f = 50;
              for (int i=0;i<input.Length;i++)
              {
                  if (i>h_pass || i<l_pass)
                  {
                      input[i] = 0;
                  }
              }
              
            for (int i = 0; i < 512; i++)
            {
                if (input[i].Real < 1000)
                {
                    input[i] = new Complex(0, 0);
                }
            }
            for (int j = 95; j < 106; j++)
            {
                input[j] = new Complex(0, 0);
            }
            for (int i = 512; i < 1024; i++)
            {
                input[i] = new Complex(0, 0);
            }
            Fourier.Inverse(input, FourierOptions.Matlab);
            chart1.ChartAreas["ChartArea1"].AxisY.Maximum = 400;
            chart1.ChartAreas["ChartArea1"].AxisY.Minimum = 0;
            double[] in1 = DSP.ConvertComplex.ToMagnitude(input);
            for (int i = 0; i < input.Length ; i++)
            {
               // double mag = (2.0 / numsamples) * Math.Abs(Math.Sqrt(Math.Pow(input[i].Real, 2) + Math.Pow(input[i].Imaginary, 2)));
                double HZPerSample = sampleRate / numsamples;
               // outMag[i] = mag;
                chart1.Series["Series1"].Points.AddXY(HZPerSample * i, in1[i]);
            }
         /*     DSPLib.DFT dft = new DSPLib.DFT();

              double[] freqSpan = dft.FrequencySpan(1024);

              Complex[] input = new Complex[1024];
              Complex[] xx = new Complex[1024];
              xx = list1.ToArray();
              input = list2.ToArray();
              Complex[] output = new Complex[input.Length];
                      // serialData.AppendText("input array :" + input.Length+" value: "+ input[255]);
                      using (var pinIn = new PinnedArray<Complex>(input))
                      using (var pinOut = new PinnedArray<Complex>(output))
                      {
                          //serialData.AppendText("before fft :");
                          FFTW.NET.DFT.FFT(pinIn, pinOut);
                          // FFTW.NET.DFT.IFFT(pinOut, pinOut);

                          //
                          //double[] in1 = DSP.ConvertComplex.ToMagnitude();
                      }
                      //Dou c1;*/
         //double[] in1 = DSP.ConvertComplex.ToMagnitude(input);
         // double[] ou1 = DSP.ConvertComplex.ToMagnitude(xx);
         /*  chart1.ChartAreas[0].AxisY.Minimum = -1;
           chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineWidth = 0;
           chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineWidth = 0;
           chart1.Series["Series1"].Points.DataBindXY(out1, in1);*/

            // double[] out1 = DSP.ConvertComplex.ToMagnitude(output);



        }
        Point? prevPosition = null;
        ToolTip tooltip = new ToolTip();

        private void chart_MouseMove(object sender, MouseEventArgs e)
        {
            var pos = e.Location;
            if (prevPosition.HasValue && pos == prevPosition.Value)
                return;
            tooltip.RemoveAll();
            prevPosition = pos;
            var results = chart1.HitTest(pos.X, pos.Y, false, System.Windows.Forms.DataVisualization.Charting.ChartElementType.DataPoint); // set ChartElementType.PlottingArea for full area, not only DataPoints
            foreach (var result in results)
            {
                if (result.ChartElementType == System.Windows.Forms.DataVisualization.Charting.ChartElementType.DataPoint) // set ChartElementType.PlottingArea for full area, not only DataPoints
                {
                    var yVal = result.ChartArea.AxisY.PixelPositionToValue(pos.Y);
                    var xVal = result.ChartArea.AxisX.PixelPositionToValue(pos.X);
                    tooltip.Show(((int)xVal).ToString(), chart1, pos.X, pos.Y - 15);
                }
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
