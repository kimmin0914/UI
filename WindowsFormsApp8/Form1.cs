using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp8
{
    public partial class Form1 : Form
    {

        Random rnd = new Random();
        Timer timer1 = new Timer();
        public Form1()
        {
            InitializeComponent();

            
            timer1.Interval = 100;

            timer1.Tick += timer2_Tick;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (chart1.Series[0].Points.Count > 50)
                chart1.Series[0].Points.RemoveAt(0);

            chart1.Series[0].Points.AddXY(DateTime.Now.ToString(), 1);
            chart1.ChartAreas[0].RecalculateAxesScale();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (chart1.Series[0].Points.Count > 50)
                chart1.Series[0].Points.RemoveAt(0);

            chart1.Series[0].Points.AddXY(DateTime.Now.ToString(), 0);
            chart1.ChartAreas[0].RecalculateAxesScale();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            int randomValue = rnd.Next(0, 11);
            int randomValue2 = rnd.Next(0, 11);

            if (chart1.Series[0].Points.Count > 50)
            {
                chart1.Series[0].Points.RemoveAt(0);
            }

            chart1.Series[0].Points.AddXY(DateTime.Now.ToString("ss.f"), randomValue);
            chart1.ChartAreas[0].RecalculateAxesScale();

            if (chart1.Series[1].Points.Count > 50)
            {
                chart1.Series[1].Points.RemoveAt(0);
            }

            chart1.Series[1].Points.AddXY(DateTime.Now.ToString("ss.f"), randomValue2);
            chart1.ChartAreas[0].RecalculateAxesScale();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void 정지_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
