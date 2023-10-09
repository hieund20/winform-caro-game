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
    public partial class Form2 : Form
    {
        private Button btn;
        private Button[,] btnArray = new Button[3, 3];
        private int[,] a = new int[3, 3];
        private int xLocation = 0;
        private int yLocation = 0;
        private int checkNextTurnFlag = 1; //X
        private int xScore = 0;
        private int oScore = 0;
        private int checkDrawFlag = 1; //Draw

        private int countDoc = 0;
        private int countNgang = 0;
        private int countCheoTrai = 0;
        private int countCheoPhai = 0;

        //Khởi tạo Button
        public Button createButton(int i, int j)
        {
            btn = new Button();
            btn.Name = "btn" + i.ToString() + j.ToString();
            btn.Location = new Point(xLocation, yLocation);
            btn.Size = new Size(130, 130);
            btn.BackColor = Color.White;
            btn.TextAlign = ContentAlignment.MiddleCenter;
            btn.UseCompatibleTextRendering = true; //Render text chuẩn hơn
            btn.Font = new Font("Microsoft Sans Serif", 50);

            return btn;
        }

        //Xử lý sự kiện Click Button
        public void attachEventButtonClick(int i, int j)
        {
            btnArray[i, j].MouseClick += button_Click;
        }

        public void button_Click(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                if(checkNextTurnFlag == 1) //X
                {
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            if (sender.Equals(btnArray[i, j])){
                                btnArray[i, j].Text = "x";
                                a[i, j] = 1;

                                rangBuocGoc(i, j); //Kiểm tra các nước cờ

                                checkNextTurnFlag = 0;
                                showWhoIsNextTurn();
                                checkDraw();
                                disableButton(i, j); //Vô hiệu hóa ô cờ đã đi
                                return;
                            }
                        }
                    }
                }
                else if (checkNextTurnFlag == 0) //o
                {
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            if (sender.Equals(btnArray[i, j])){
                                btnArray[i, j].Text = "o";

                                a[i, j] = 2;

                                rangBuocGoc(i, j); //Kiểm tra các nước cờ

                                checkNextTurnFlag = 1;
                                showWhoIsNextTurn();
                                checkDraw();
                                disableButton(i, j); //Vô hiệu hóa ô cờ đã đi
                            }
                        }
                    }
                }
            }
        }

        //Xử lý sự kiện Mouse Enter, Mouse Leave
        public void attachEventMouseEnterAndLeave(int i, int j)
        {
            btnArray[i, j].MouseEnter += button_MouseEnter;
            btnArray[i, j].MouseLeave += button_MouseLeave;
        }

        public void button_MouseEnter(object sender, EventArgs e)
        {
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    if(sender.Equals(btnArray[i, j]))
                    {
                        btnArray[i, j].BackColor = Color.Orange;
                    }
                }
            }
        }

        public void button_MouseLeave(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (sender.Equals(btnArray[i, j]))
                    {
                        btnArray[i, j].BackColor = Color.White;
                    }
                }
            }
        }

        //Hiển thị lượt chơi của người tiếp theo
        public void showWhoIsNextTurn()
        {
            if(checkNextTurnFlag == 1)
            {
                labelTurnOfX.BackColor = Color.Orange;
                labelTurnOfO.BackColor = Color.White;
            }
            if (checkNextTurnFlag == 0)
            {
                labelTurnOfO.BackColor = Color.Orange;
                labelTurnOfX.BackColor = Color.White;
            }
        }

        //Thiết lập điểm của 2 người chơi là 0 khi mới bắt đầu
        public void setPlayerScoreWhenStart()
        {
            labelXScore.Text = xScore.ToString();
            labelOScore.Text = oScore.ToString();
        }

        //Hiển thị điểm của người chơi thắng ở lượt hiện tại
        public void showPlayerScore()
        {
            if(checkNextTurnFlag == 1)
            {
                xScore++;
                labelXScore.Text = xScore.ToString();
                labelXScore.BackColor = Color.LightYellow;
                labelOScore.BackColor = Color.White;
            }
            if(checkNextTurnFlag == 0)
            {
                oScore++;
                labelOScore.Text = oScore.ToString();
                labelOScore.BackColor = Color.LightYellow;
                labelXScore.BackColor = Color.White;
            }
        }

        //Kiểm tra hàng ngang qua Phải
        public void ktNgangPhai(int i, int j, int countNgang)
        {
            if(countNgang == 2)
            {
                countNgang = 0;
                showPlayerScore();
                checkDrawFlag = 0;
                MessageBox.Show("Kết thúc !!", "Thông báo");
                disableAllButton();
                return;
            }
            try
            {
                if (a[i, j] == a[i, ++j])
                {
                    countNgang++;
                    ktNgangPhai(i, j, countNgang);
                }
            }
            catch(IndexOutOfRangeException)
            {}           
        }
        //Kiểm tra hàng ngang qua Trái
        public void ktNgangTrai(int i, int j, int countNgang)
        {
            if (countNgang == 2)
            {
                countNgang = 0;
                showPlayerScore();
                checkDrawFlag = 0;
                MessageBox.Show("Kết thúc !!", "Thông báo");
                disableAllButton();
                return;
            }
            try
            {
                if (a[i, j] == a[i, --j])
                {
                    countNgang++;
                    ktNgangTrai(i, j, countNgang);
                }
            }
            catch(IndexOutOfRangeException)
            {}           
        }

        //Kiểm tra hàng dọc hướng Lên
        public void ktDocLen(int i, int j, int countDoc)
        {
            if (countDoc == 2)
            {
                countDoc = 0;
                showPlayerScore();
                checkDrawFlag = 0;
                MessageBox.Show("Kết thúc !!", "Thông báo");
                disableAllButton();
                return;
            }
            try
            {
                if (a[i, j] == a[--i, j])
                {
                    countDoc++;
                    ktDocLen(i, j, countDoc);
                }
            }
            catch (IndexOutOfRangeException)
            { }

        }
        //Kiểm tra hàng dọc hướng Xuống
        public void ktDocXuong(int i, int j, int countDoc)
        {
            if (countDoc == 2)
            {
                countDoc = 0;
                showPlayerScore();
                checkDrawFlag = 0;
                MessageBox.Show("Kết thúc !!", "Thông báo");
                disableAllButton();
                return;
            }
            try
            {
                if (a[i, j] == a[++i, j])
                {
                    countDoc++;
                    ktDocXuong(i, j, countDoc);
                }
            }
            catch (IndexOutOfRangeException)
            { }
        }

        //Kiểm tra hàng chéo Trái hướng Lên
        public void ktCheoTraiLen(int i, int j, int countCheoTrai)
        {
            if (countCheoTrai == 2)
            {
                countCheoTrai = 0;
                showPlayerScore();
                checkDrawFlag = 0;
                MessageBox.Show("Kết thúc !!", "Thông báo");
                disableAllButton();
                return;
            }
            try
            {
                if (a[i, j] == a[--i, --j])
                {
                    countCheoTrai++;
                    ktCheoTraiLen(i, j, countCheoTrai);
                }
            }
            catch (IndexOutOfRangeException)
            { }

        }
        //Kiểm tra hàng chéo Trái hướng Xuống
        public void ktCheoTraiXuong(int i, int j, int countCheoTrai)
        {
            if (countCheoTrai == 2)
            {
                countCheoTrai = 0;
                showPlayerScore();
                checkDrawFlag = 0;
                MessageBox.Show("Kết thúc !!", "Thông báo");
                disableAllButton();
                return;
            }
            try
            {
                if (a[i, j] == a[++i, ++j])
                {
                    countCheoTrai++;
                    ktCheoTraiXuong(i, j, countCheoTrai);
                }
            }
            catch (IndexOutOfRangeException)
            { }
        }

        //Kiểm tra hàng chéo Phải hướng Lên
        public void ktCheoPhaiLen(int i, int j, int countCheoPhai)
        {
            if (countCheoPhai == 2)
            {
                countCheoPhai = 0;
                showPlayerScore();
                checkDrawFlag = 0;
                MessageBox.Show("Kết thúc !!", "Thông báo");
                disableAllButton();
                return;
            }
            try
            {
                if (a[i, j] == a[--i, ++j])
                {
                    countCheoPhai++;
                    ktCheoPhaiLen(i, j, countCheoPhai);
                }
            }
            catch (IndexOutOfRangeException)
            { }

        }
        //Kiểm tra hàng chéo Phải hướng Xuống
        public void ktCheoPhaiXuong(int i, int j, int countCheoPhai)
        {
            if (countCheoPhai == 2)
            {
                countCheoPhai = 0;
                showPlayerScore();
                checkDrawFlag = 0;
                MessageBox.Show("Kết thúc !!", "Thông báo");
                disableAllButton();
                return;
            }
            try
            {
                if (a[i, j] == a[++i, --j])
                {
                    countCheoPhai++;
                    ktCheoPhaiXuong(i, j, countCheoPhai);
                }
            }
            catch (IndexOutOfRangeException)
            { }
        }

        //Ràng buộc trường hợp kiểm tra ở 4 góc, 4 cạnh
        public void rangBuocGoc(int i, int j)
        {
            //Góc trên trái
            if (i == 0 && j == 0)
            {
                ktNgangPhai(i, j, countNgang);
                ktDocXuong(i, j, countDoc);
                ktCheoTraiXuong(i, j, countCheoTrai);
            }
            //Góc trên phải
            else if (i == 0 && j == 2)
            {
                ktNgangTrai(i, j, countNgang);
                ktDocXuong(i, j, countDoc);
                ktCheoPhaiXuong(i, j, countCheoPhai);
            }
            //Góc dưới trái
            else if (i == 2 && j == 0)
            {
                ktNgangPhai(i, j, countNgang);
                ktDocLen(i, j, countDoc);
                ktCheoPhaiLen(i, j, countCheoPhai);
            }
            //Góc dưới phải
            else if (i == 2 && j == 2)
            {
                ktNgangTrai(i, j, countNgang);
                ktDocLen(i, j, countDoc);
                ktCheoTraiLen(i, j, countCheoTrai);
            }
            //Cạnh Top (1 ô)
            else if (i == 0 && j == 1)
            {
                ktNgangPhai(i, j, countNgang);
                ktNgangTrai(i, j, countNgang);
                ktDocXuong(i, j, countDoc);
                ktCheoPhaiXuong(i, j, countCheoPhai);
                ktCheoTraiXuong(i, j, countCheoTrai);
            }
            //Cạnh Bottom (1 ô)
            else if (i == 2 && j == 1)
            {
                ktNgangPhai(i, j, countNgang);
                ktNgangTrai(i, j, countNgang);
                ktDocLen(i, j, countDoc);
                ktCheoPhaiLen(i, j, countCheoPhai);
                ktCheoTraiLen(i, j, countCheoTrai);
            }
            //Cạnh Left (1 ô)
            else if (i == 1 && j == 0)
            {
                ktNgangPhai(i, j, countNgang);
                ktDocLen(i, j, countDoc);
                ktDocXuong(i, j, countDoc);
                ktCheoPhaiLen(i, j, countCheoPhai);
                ktCheoTraiXuong(i, j, countCheoTrai);
            }
            //Cạnh Right (1 ô)
            else if (i == 1 && j == 2)
            {
                ktNgangTrai(i, j, countNgang);
                ktDocLen(i, j, countDoc);
                ktDocXuong(i, j, countDoc);
                ktCheoPhaiXuong(i, j, countCheoPhai);
                ktCheoTraiLen(i, j, countCheoTrai);
            }
            else //Trường hợp còn lại
            {
                ktNgangPhai(i, j, countNgang);
                ktNgangTrai(i, j, countNgang);
                ktDocLen(i, j, countDoc);
                ktDocXuong(i, j, countDoc);
                ktCheoTraiLen(i, j, countCheoTrai);
                ktCheoTraiXuong(i, j, countCheoTrai);
                ktCheoPhaiLen(i, j, countCheoPhai);
                ktCheoPhaiXuong(i, j, countCheoPhai);
            }         
        }

        //Kiểm tra nước cờ Hòa
        public void checkDraw()
        {
            int countDraw = 0;
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    if(a[i, j] != 0)
                    {
                        countDraw++;
                    }
                }
            }

            if(countDraw == 9 && checkDrawFlag == 1)
            {
                MessageBox.Show("Draw");
            }
        }

        //Vô hiệu ô cờ sau khi nhấn
        public void disableButton(int i, int j)
        {
            btnArray[i, j].Enabled = false;
        }
        //Vô hiệu hóa cả bàn cờ sau khi kết thúc
        public void disableAllButton()
        {
            for(int i = 0; i < 3; i++)
            {
                for(int j  = 0; j < 3; j++)
                {
                    btnArray[i, j].Enabled = false;
                }
            }
        }
        //Tái khởi động bàn cờ
        public void enableAllButton()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    btnArray[i, j].Enabled = true;
                }
            }
        }

        //Khởi tạo bàn cờ (mảng các button)
        public void initButtonArray()
        {
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    btnArray[i, j] = createButton(i, j);
                    attachEventButtonClick(i, j);
                    attachEventMouseEnterAndLeave(i, j);
                    panelContainer.Controls.Add(btnArray[i, j]);

                    xLocation += 128;
                }
                xLocation = 0;
                yLocation += 128;
            }
        }

        //Khởi tạo mảng số nguyên lưu trữ các số 0, 1, 2:
        //0: Nước cờ chưa được đánh
        //1: Nước cờ X
        //2: Nước cờ O
        public void initIntArray()
        {
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    a[i, j] = 0;
                }
            }
        }

        //Play Again Button
        private void button1_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    btnArray[i, j].Text = "";
                    a[i, j] = 0;
                }
            }
            checkNextTurnFlag = 1; //Mặc định ban đầu khi chơi lại phải là X chơi đầu tiên
            showWhoIsNextTurn();

            xScore = 0;
            labelXScore.Text = xScore.ToString();
            labelXScore.BackColor = Color.White;
            oScore = 0;
            labelOScore.Text = oScore.ToString();
            labelOScore.BackColor = Color.White;

            enableAllButton();
            checkDrawFlag = 1;
        }

        private void buttonPlayAgain_MouseEnter(object sender, EventArgs e)
        {
            buttonPlayAgain.BackColor = Color.Orange;
        }

        private void buttonPlayAgain_MouseLeave(object sender, EventArgs e)
        {
            buttonPlayAgain.BackColor = Color.White;
        }

        //Continue Button
        private void button1_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    btnArray[i, j].Text = "";
                    a[i, j] = 0;
                }
            }
            checkNextTurnFlag = 1; //Mặc định ban đầu phải là X chơi đầu tiên
            showWhoIsNextTurn();

            enableAllButton();
            checkDrawFlag = 1;
        }

        private void buttonContinue_MouseEnter(object sender, EventArgs e)
        {
            buttonContinue.BackColor = Color.Orange;
        }

        private void buttonContinue_MouseLeave(object sender, EventArgs e)
        {
            buttonContinue.BackColor = Color.White;
        }

        //Back To Menu Button
        private void buttonReturn_Click(object sender, EventArgs e)
        {
            Form0 f0 = new Form0();
            f0.Show();
            this.Hide();
        }

        private void buttonReturn_MouseEnter(object sender, EventArgs e)
        {
            buttonReturn.BackColor = Color.DimGray;
        }

        private void buttonReturn_MouseLeave(object sender, EventArgs e)
        {
            buttonReturn.BackColor = Color.White;
        }

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            initButtonArray();
            initIntArray();
            setPlayerScoreWhenStart();
        }

       
    }
}
