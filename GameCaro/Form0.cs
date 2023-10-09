using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameCaro
{
    public partial class Form0 : Form
    {
        public Form0()
        {
            InitializeComponent();
        }

        //Truyền thống
        private void button1_Click(object sender, EventArgs e)
        {
            InputName frmInputName = new InputName();
            frmInputName.Show();
            this.Hide();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.Orange;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.White;
        }

        //Hiện đại
        //private void button3_Click(object sender, EventArgs e)
        //{
        //    Form2 f2 = new Form2();
        //    f2.Show();
        //    this.Hide();
        //}

        //private void button3_MouseEnter(object sender, EventArgs e)
        //{
        //    button3.BackColor = Color.Orange;
        //}

        //private void button3_MouseLeave(object sender, EventArgs e)
        //{
        //    button3.BackColor = Color.White;
        //}

        //Thoát
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dl = MessageBox.Show("Bạn có muốn thoát khỏi trò chơi?", "Thông báo", MessageBoxButtons.YesNo);
            if (dl == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (dl == DialogResult.No)
            {
                //Tự động tắt Dialog
            }
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.DimGray;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.White;
        }
    }
}
