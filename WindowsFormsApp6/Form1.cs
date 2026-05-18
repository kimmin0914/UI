using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void UpdateTotal()
        {
            int total = 0;
            foreach (var item in productBindingSource)
            {
                if (item is Product p)
                {
                    total += p.Price;
                }
            }
            textBox3.Text = total.ToString("#,##0") + "원";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
         
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            if (btnAddProduct.Text != "" && textBox2.Text != "")
            {
                string newName = btnAddProduct.Text;
                int newPrice = int.Parse(textBox2.Text); // 입력한 글자를 숫자로 변환

                // 리스트에 추가하고 합계 업데이트
                productBindingSource.Add(new Product { Name = newName, Price = newPrice });
                UpdateTotal();

                // 입력 완료 후 텍스트박스 비우기
                btnAddProduct.Text = "";
                textBox2.Text = "";
            }
            else
            {
                MessageBox.Show("추가할 상품명과 가격을 입력해주세요!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 리스트에 선택된 항목이 있다면
            if (productBindingSource.Current != null)
            {
                // 현재 선택된 항목을 리스트에서 완전히 지움
                productBindingSource.RemoveCurrent();
                UpdateTotal(); // 지운 후의 합계를 다시 계산
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 리스트(DataGridView)에서 현재 마우스로 파랗게 선택된 항목을 가져옴
            Product selectedProduct = productBindingSource.Current as Product;

            if (selectedProduct != null)
            {
                // 가져온 정보를 텍스트박스에 띄워줌
                btnAddProduct.Text = selectedProduct.Name;
                textBox2.Text = selectedProduct.Price.ToString();
            }
        }

        
        private void button11_Click(object sender, EventArgs e)
        {
            productBindingSource.Add(new Product { Name = "제육볶음", Price = 10000 });
            UpdateTotal();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            productBindingSource.Add(new Product { Name = "감자", Price = 3000 });
            UpdateTotal();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            productBindingSource.Add(new Product { Name = "짜장면", Price = 6000 });
            UpdateTotal();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            productBindingSource.Add(new Product { Name = "김치찌개", Price = 8000 });
            UpdateTotal();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            productBindingSource.Add(new Product { Name = "치즈스틱", Price = 2000 });
            UpdateTotal();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            productBindingSource.Add(new Product { Name = "고구마", Price = 4000 });
            UpdateTotal();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            productBindingSource.Add(new Product { Name = "위스키", Price = 200000 });
            UpdateTotal();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            productBindingSource.Add(new Product { Name = "소주", Price = 4500 });
            UpdateTotal();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            productBindingSource.Add(new Product { Name = "닭볶음탕", Price = 15000 });
            UpdateTotal();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
           
        }

    }
}
