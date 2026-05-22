using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace WindowsFormsApp7
{
    public partial class Form1 : Form
    {
        int state = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime CurrentTime = DateTime.Now;
            label1.Text = CurrentTime.ToString("yyyy.MM.dd HH:mm:ss");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            pictureBox1.ImageLocation = "./led_gray.png";
            state = 0;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Invoke(new MethodInvoker(delegate ()
            {
                DateTime CurrentTime = DateTime.Now;
                label1.Text = CurrentTime.ToString("yyyy.MM.dd HH:mm:ss");
            }));

            if (state == 0)
            {
                pictureBox1.Invoke(new MethodInvoker(delegate ()
                {
                    pictureBox1.ImageLocation = "./led_green.png";
                    state = 1;
                }));
            }
            else
            {
                pictureBox1.Invoke(new MethodInvoker(delegate ()
                {
                    pictureBox1.ImageLocation = "./led_gray.png";
                    state = 0;
                }));
            }
        }
    }
}
