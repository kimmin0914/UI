using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ACTMULTILIB_K;

namespace PLCTest2
{
    public partial class Form1 : Form
    {
        ActEasyIF control = new ActEasyIF();

        bool isAutoMode = false;
        int currentStep = 0;
        bool isConnected = false;

        int MASK_FWD = 0x04; // X02 전진 센서
        int MASK_BWD = 0x08; // X03 후진 센서

        public Form1()
        {
            InitializeComponent();
            chart1.Series.Clear();
            chart1.Series.Add("Series1");
            chart1.Series[0].ChartType = SeriesChartType.Line;

            // Y축 0 ~ 100, 간격 20 세팅
            chart1.ChartAreas[0].AxisY.Maximum = 100;
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Interval = 20;

            // X축 1 ~ 8, 간격 1 세팅
            chart1.ChartAreas[0].AxisX.Maximum = 8;
            chart1.ChartAreas[0].AxisX.Minimum = 1;
            chart1.ChartAreas[0].AxisX.Interval = 1;

            // X축이 계속 늘어나지 않고 1~8로 고정되도록, 미리 0점 8개를 찍어둡니다.
            for (int i = 1; i <= 8; i++)
            {
                chart1.Series[0].Points.AddXY(i, 0);
            }

            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (control.Open() == 0)
            {
                MessageBox.Show("연결 성공!");
                label1.Text = "연결됨";

                isConnected = true;
                timer1.Interval = 1000;
                timer1.Enabled = true;
            }
            else
            {
                MessageBox.Show("연결 실패!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            isAutoMode = false;
            short value = 0x01 << 1;
            control.WriteDeviceBlock2("Y0", 1, ref value);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            isAutoMode = false;
            short value = 0x01 << 2;
            control.WriteDeviceBlock2("Y0", 1, ref value);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!timer1.Enabled) return;
            isAutoMode = true;
            currentStep = 1;
            short value = 0x01 << 1;
            control.WriteDeviceBlock2("Y0", 1, ref value);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            isAutoMode = false;
            short value = 0;
            control.WriteDeviceBlock2("Y0", 1, ref value);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isConnected == false) return;

            short sensor = 0;
            if (control.ReadDeviceBlock2("X0", 1, out sensor) != 0) return;

            int graphValue = 0;

            if (((int)(sensor) & MASK_FWD) != 0)
            {
                label1.Text = "전진 완료";
                pictureBox1.Image = Properties.Resources.cylinderon;
                graphValue = 100; // 전진 시 천장(100)에 닿음
            }
            else if (((int)(sensor) & MASK_BWD) != 0)
            {
                label1.Text = "후진 완료";
                pictureBox1.Image = Properties.Resources.cylinderoff;
                graphValue = 0; // 후진 시 바닥(0)에 닿음
            }
            else
            {
                label1.Text = "이동 중...";
                graphValue = 0;
            }

            for (int i = 0; i < 7; i++)
            {
                chart1.Series[0].Points[i].YValues[0] = chart1.Series[0].Points[i + 1].YValues[0];
            }
            chart1.Series[0].Points[7].YValues[0] = graphValue;
            chart1.Invalidate();

            // 자동 왕복 제어 로직
            if (isAutoMode)
            {
                if (currentStep == 1 && (((int)(sensor) & MASK_FWD) != 0))
                {
                    currentStep = 2;
                    short value = 0x01 << 2;
                    control.WriteDeviceBlock2("Y0", 1, ref value);
                }
                else if (currentStep == 2 && (((int)(sensor) & MASK_BWD) != 0))
                {
                    currentStep = 1;
                    short value = 0x01 << 1;
                    control.WriteDeviceBlock2("Y0", 1, ref value);
                }
            }
        }
    }
}