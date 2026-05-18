using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int elapsedTime = 0; // 시간이 얼마나 흘렀는지 숫자로 세어서 기억해둘 변수입니다. 처음엔 0으로 시작합니다.
        private void timer1_Tick(object sender, EventArgs e) // 타이머가 째깍거릴 때마다(설정된 간격마다) 반복해서 실행되는 코드입니다.
        {
            elapsedTime++; // 타이머가 한 번 째깍일 때마다 경과 시간(숫자)을 1씩 증가시킵니다.
            textBox1.Text = (elapsedTime * 0.005).ToString("F2") + "초 경과";

        }

        private void button1_Click(object sender, EventArgs e) // [시작] 버튼을 클릭했을 때 실행되는 코드입니다.
        {
            timer1.Enabled = true; // 타이머를 켜서(Enabled = true) 시간이 흘러가게 만듭니다.
        }

        private void button2_Click(object sender, EventArgs e) // [스톱] 버튼을 클릭했을 때 실행되는 코드입니다.
        {
            timer1.Enabled = false; // 타이머를 꺼서(Enabled = false) 시간의 흐름을 딱 멈춥니다.
            if (textBox1.Text == "2.00초 경과") // 멈춘 순간 텍스트박스1의 글자가 정확히 "2.00초 경과"와 똑같은지 검사합니다.
            {
                textBox2.Text = "당첨!"; // 똑같다면(정확히 2초에 멈췄다면) 결과창인 텍스트박스2에 "당첨!"을 띄웁니다.
            }
            else
            {
                textBox2.Text = "실패"; // 2초보다 빠르거나 느렸다면 결과창에 "실패"를 띄웁니다.
            }
        }

        private void button3_Click(object sender, EventArgs e) // [초기화] 버튼을 클릭했을 때 실행되는 코드입니다.
        {
            timer1.Enabled = false; // 혹시라도 타이머가 아직 돌아가고 있다면 먼저 확실하게 멈춰줍니다.
            textBox1.Text = " "; // 텍스트박스1에 적힌 시간을 지우고 빈칸으로 만듭니다.

            elapsedTime = 0; // 다시 처음부터 게임을 시작할 수 있게 기억해둔 경과 시간을 0으로 돌려놓습니다.
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ApplyUltraDopeDesign();
        }

        private void ApplyUltraDopeDesign()
        {
            // 1. 폼 전체 스타일 (완전한 딥 다크 블랙)
            this.BackColor = Color.FromArgb(15, 15, 15);
            this.Text = "⚡ 2.00 SEC DEATHMATCH ⚡";
            this.ClientSize = new Size(400, 450);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            // 2. 타이머 텍스트박스 (디지털 감성 Consolas 폰트 + 형광 초록)
            textBox1.BackColor = Color.FromArgb(20, 20, 20);
            textBox1.ForeColor = Color.Lime;
            textBox1.Font = new Font("Consolas", 42, FontStyle.Bold | FontStyle.Italic);
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.TextAlign = HorizontalAlignment.Center;
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(360, 80);
            textBox1.Location = new Point(20, 30);

            // 3. 결과 텍스트박스 (네온 핫핑크)
            textBox2.BackColor = Color.FromArgb(20, 20, 20);
            textBox2.ForeColor = Color.DeepPink;
            textBox2.Font = new Font("Consolas", 28, FontStyle.Bold);
            textBox2.BorderStyle = BorderStyle.FixedSingle;
            textBox2.TextAlign = HorizontalAlignment.Center;
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(360, 60);
            textBox2.Location = new Point(20, 130);

            // 4. 미친 색감과 효과의 네온 버튼들
            // 인자: 버튼, 텍스트, 네온포인트컬러, 반전시글자색, 위치, 크기
            StyleUltraButton(button1, "ENGAGE (시작)", Color.FromArgb(50, 205, 50), Color.Black, new Point(20, 220), new Size(170, 70));
            StyleUltraButton(button2, "HALT (스톱)", Color.FromArgb(255, 20, 147), Color.White, new Point(210, 220), new Size(170, 70));
            StyleUltraButton(button3, "REBOOT (초기화)", Color.FromArgb(0, 255, 255), Color.Black, new Point(20, 310), new Size(360, 70));

            if (string.IsNullOrWhiteSpace(textBox1.Text)) textBox1.Text = "0.00초 경과";
        }

        private void StyleUltraButton(Button btn, string text, Color neonColor, Color invertTextColor, Point loc, Size size)
        {
            btn.Text = text;
            btn.Font = new Font("Impact", 16, FontStyle.Regular); // 임팩트 있는 두꺼운 폰트
            btn.BackColor = Color.FromArgb(25, 25, 25); // 기본 배경은 어둡게
            btn.ForeColor = neonColor; // 기본 글자색은 네온
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderColor = neonColor; // 테두리를 네온색으로 씌움 (핵심 포인트!)
            btn.FlatAppearance.BorderSize = 2;
            btn.Location = loc;
            btn.Size = size;
            btn.Cursor = Cursors.Cross; // 마우스 커서를 조준점(Cross) 모양으로 변경!

            // 마우스 호버 시 배경과 글씨색이 확 반전되는 애니메이션
            btn.MouseEnter += (s, ev) =>
            {
                btn.BackColor = neonColor;
                btn.ForeColor = invertTextColor;
            };
            btn.MouseLeave += (s, ev) =>
            {
                btn.BackColor = Color.FromArgb(25, 25, 25);
                btn.ForeColor = neonColor;
            };
        }
    }
}
