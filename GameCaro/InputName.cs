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
    public partial class InputName : Form
    {
        public string playerName1 { get; set; } = "";
        public string playerName2 { get; set; } = "";

        public InputName()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBoxPLayer1_TextChanged(object sender, EventArgs e)
        {
            this.playerName1 = textBoxPLayer1.Text;
        }

        private void textBoxPlayer2_TextChanged(object sender, EventArgs e)
        {
            this.playerName2 = textBoxPlayer2.Text;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1(this.playerName1, this.playerName2);
            form1.Show();
            this.Hide();
        }
    }
}
