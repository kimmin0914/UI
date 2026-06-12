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

namespace PLCTest4
{
    public partial class Form1 : Form
    {
        ActEasyIF control = new ActEasyIF();

        bool isConnected = false;
        bool isAutoMode = false;
        int step = 0;
        short y_value = 0;

        // 입력(X) 센서
        int SENSOR_B_FWD = 1 << 2;  // X02: B실린더 전진 완료 
        int SENSOR_B_BWD = 1 << 3;  // X03: B실린더 후진 완료 
        int SENSOR_C_FWD = 1 << 5;  // X05: C실린더 전진 완료
        int SENSOR_C_BWD = 1 << 4;  // X04: C실린더 후진 완료

        int STAGE_A = 1 << 10; // X0A: 리프트센서A
        int STAGE_B = 1 << 11; // X0B: 리프트센서B

        // 출력(Y) 명령
        int OUT_B_FWD = 1 << 1;     // Y01: B실린더 전진
        int OUT_B_BWD = 1 << 2;     // Y02: B실린더 후진
        int OUT_C_FWD = 1 << 3;     // Y03: C실린더 전진
        int OUT_C_BWD = 1 << 4;     // Y04: C실린더 후진

        public Form1()
        {
            InitializeComponent();
        }

        // 버튼 1: 연결
        private void button1_Click(object sender, EventArgs e)
        {
            if (control.Open() == 0)
            {
                MessageBox.Show("연결 성공!");
                isConnected = true;
                label1.Text = "연결 완료. [시작] 버튼을 누르세요.";
                timer1.Interval = 100;
                timer1.Enabled = true;
            }
            else
            {
                MessageBox.Show("연결 실패!");
            }
        }

        // 버튼 2: 자동운전 시작
        private void button2_Click(object sender, EventArgs e)
        {
            if (!isConnected) return;

            isAutoMode = true;
            step = 0;

            // 시작과 동시에 실린더를 후진 상태로 꽉 잡아줌
            y_value = (short)(OUT_B_BWD | OUT_C_BWD);
            control.WriteDeviceBlock2("Y0", 1, ref y_value);

            label1.Text = "대기 중... 위쪽 선반(A)에 물건을 올려주세요.";
        }

        // 버튼 3: 자동운전 정지
        private void button3_Click(object sender, EventArgs e)
        {
            isAutoMode = false;
            step = 0;

            y_value = 0; // 전원 차단
            control.WriteDeviceBlock2("Y0", 1, ref y_value);
            label1.Text = "자동운전 정지됨.";
        }

        // 타이머: 센서 감시 및 자동화 로직
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!isConnected || !isAutoMode) return;

            short sensor = 0;
            if (control.ReadDeviceBlock2("X0", 1, out sensor) != 0) return;

            switch (step)
            {
                case 0:
                    // 리프트센서A(X0A)에 물건이 딱 감지되면 출발!
                    if ((sensor & STAGE_A) != 0)
                    {
                        y_value = (short)(y_value | OUT_B_FWD);   // B 전진 켜기
                        y_value = (short)(y_value & ~OUT_B_BWD);  // B 후진 끄기
                        control.WriteDeviceBlock2("Y0", 1, ref y_value);

                        step = 1;
                        label1.Text = "[1단계] 물건 감지! B실린더 전진 중...";
                    }
                    break;

                case 1:
                    // B실린더가 진짜로 끝까지 전진했는지 확인(X02)
                    if ((sensor & SENSOR_B_FWD) != 0)
                    {
                        y_value = (short)(y_value & ~OUT_B_FWD);  // B 전진 끄기
                        y_value = (short)(y_value | OUT_B_BWD);   // B 후진 켜기
                        control.WriteDeviceBlock2("Y0", 1, ref y_value);

                        step = 2;
                        label1.Text = "[2단계] B전진 완료! 후진 중...";
                    }
                    break;

                case 2:
                    // B실린더가 제자리로 오고(X03) & 물건이 아래로 떨어지면(X0B)
                    if (((sensor & SENSOR_B_BWD) != 0) && ((sensor & STAGE_B) != 0))
                    {
                        y_value = (short)(y_value | OUT_C_FWD);   // C 전진 켜기
                        y_value = (short)(y_value & ~OUT_C_BWD);  // C 후진 끄기
                        control.WriteDeviceBlock2("Y0", 1, ref y_value);

                        step = 3;
                        label1.Text = "[3단계] 하단 물건 도착! C실린더 전진 중...";
                    }
                    break;

                case 3:
                    // C실린더 끝까지 전진 확인(X05)
                    if ((sensor & SENSOR_C_FWD) != 0)
                    {
                        y_value = (short)(y_value & ~OUT_C_FWD);  // C 전진 끄기
                        y_value = (short)(y_value | OUT_C_BWD);   // C 후진 켜기
                        control.WriteDeviceBlock2("Y0", 1, ref y_value);

                        step = 4;
                        label1.Text = "[4단계] C전진 완료! 후진 중...";
                    }
                    break;

                case 4:
                    // C실린더 제자리로 오면(X04) 완료!
                    if ((sensor & SENSOR_C_BWD) != 0)
                    {
                        step = 0;
                        label1.Text = "사이클 완료! 다음 물건을 올려주세요.";
                    }
                    break;
            }
        }
    }
}