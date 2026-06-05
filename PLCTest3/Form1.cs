using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ACTMULTILIB_K;

namespace PLCTest3
{
    public partial class Form1 : Form
    {
        ActEasyIF control = new ActEasyIF();

        public Form1()
        {
            InitializeComponent();
        }

        // ==========================================
        // 버튼 1: B실린더 시작 (Y01)
        // ==========================================
        private void button1_Click(object sender, EventArgs e)
        {
            short value = 0x01 << 1;
            control.WriteDeviceBlock2("Y0", 1, ref value);
        }

        // ==========================================
        // 버튼 2: B실린더 정지 (Y02)
        // ==========================================
        private void button2_Click(object sender, EventArgs e)
        {
            short value = 0x01 << 2;
            control.WriteDeviceBlock2("Y0", 1, ref value);
        }

        // ==========================================
        // 버튼 3: C실린더 시작 (Y04)
        // ==========================================
        private void button3_Click(object sender, EventArgs e)
        {
            short value = 0x01 << 4;
            control.WriteDeviceBlock2("Y0", 1, ref value);
        }

        // ==========================================
        // 버튼 4: C실린더 정지 (Y05)
        // ==========================================
        private void button4_Click(object sender, EventArgs e)
        {
            short value = 0x01 << 5;
            control.WriteDeviceBlock2("Y0", 1, ref value);
        }

        // ==========================================
        // 버튼 5: 연결
        // ==========================================
        private void button5_Click(object sender, EventArgs e)
        {
            if (control.Open() == 0)
            {
                MessageBox.Show("PLC 연결 성공!");
                label1.Text = "연결됨";
            }
            else
            {
                MessageBox.Show("PLC 연결 실패!");
            }
        }

        // ==========================================
        // 버튼 6: 센서 읽기 (반대로 뜨는 현상 수정 완료!)
        // ==========================================
        private void button6_Click(object sender, EventArgs e)
        {
            short sensor = 0;

            if (control.ReadDeviceBlock2("X0", 1, out sensor) == 0)
            {
                string statusB = "";
                string statusC = "";

                // ★ B실린더: 반대로 출력되던 센서 값 뒤집기! (X02=전진, X03=후진)
                if ((sensor & (1 << 2)) != 0) statusB = "B: 전진";
                else if ((sensor & (1 << 3)) != 0) statusB = "B: 후진";

                // ★ C실린더: 반대로 출력되던 센서 값 뒤집기! (X04=전진, X05=후진)
                if ((sensor & (1 << 4)) != 0) statusC = "C: 전진";
                else if ((sensor & (1 << 5)) != 0) statusC = "C: 후진";

                label1.Text = $"{statusB}    {statusC}";
            }
            else
            {
                label1.Text = "센서 읽기 에러!";
            }
        }
    }
}