using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameCaro
{
    public partial class Form1 : Form
    {
        int[,] a = new int[19, 23]; //15 x 15
        Button[,] buttonArray = new Button[19, 23];
        private Button btn;
        private int xLocation = 0;
        private int yLocation = 0;
        //Mặc định ban đầu chọn X
        private int checkNextTurnFlag = 1; //X
        private int xScore = 0;
        private int oScore = 0;
        private int count = 0; //count dọc
        private int countNgang = 0;
        private int countCheoTrai = 0;
        private int countCheoPhai = 0;

        //Khởi tạo button
        public Button createButton(int i, int j)
        {
            btn = new Button();
            btn.Name = "btn" + i.ToString() + j.ToString();
            btn.BackColor = Color.White;
            //btn.Text = i.ToString() + j.ToString();
            btn.Text = "";
            //Căn chỉnh text trong button
            btn.TextAlign = ContentAlignment.MiddleCenter;
            btn.UseCompatibleTextRendering = true; //Render text chuẩn hơn
            //------------------------------------------
            btn.Font = new Font("Microsoft Sans Serif", 18);
            btn.Size = new Size(35,35);
            btn.Location = new Point(xLocation, yLocation);

            return btn;
        }
        
        //Sự kiện khi click chuột trái lên vị trí đánh nước cờ (button)
        public void attachEventButton(int i, int j)
        {
            buttonArray[i,j].MouseClick += button_Click;
        }

        public void button_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) //Khi click chuột trái
            {
                if (checkNextTurnFlag == 1)
                {
                    for(int i = 0; i < 19; i++)
                    {
                        for(int j = 0; j < 23; j++)
                        {
                            if(sender.Equals(buttonArray[i, j]))
                            {
                                buttonArray[i, j].Text = "x";
                                a[i, j] = 1; //x = 1

                                rangBuocGoc(i, j);
                                disableButton(i, j); //Vô hiệu hóa ô cờ đã được đánh
                            }
                        }
                    }
                    
                    checkNextTurnFlag = 0;
                    showWhoIsNextTurn();
                    return;
                }
                else if (checkNextTurnFlag == 0)
                {
                    for (int i = 0; i < 19; i++)
                    {
                        for (int j = 0; j < 23; j++)
                        {
                            if (sender.Equals(buttonArray[i, j]))
                            {
                                buttonArray[i, j].Text = "o";
                                a[i, j] = 2; // o = 2

                                rangBuocGoc(i, j);
                                disableButton(i, j); //Vô hiệu hóa ô cờ đã được đánh
                            }
                        }
                    }
                    checkNextTurnFlag = 1;
                    showWhoIsNextTurn();
                }
            }
        }

        //Xự kiện khi hover lên từng button trên bàn cờ
        public void attachEventButtonHover(int i, int j)
            {
                buttonArray[i, j].MouseEnter += button_MouseEnter;
                buttonArray[i, j].MouseLeave += button_MouseLeave;
            }

        public void button_MouseEnter(object sender, EventArgs e)
        {
            for(int i = 0; i < 19; i++)
            {
                for(int j = 0; j < 23; j++)
                {
                    if(sender.Equals(buttonArray[i, j]))
                    {
                        buttonArray[i, j].BackColor = Color.Orange;
                    }
                }
            }
        }

        public void button_MouseLeave(object sender, EventArgs e)
        {
            for (int i = 0; i < 19; i++)
            {
                for (int j = 0; j < 23; j++)
                {
                    if (sender.Equals(buttonArray[i, j]))
                    {
                        buttonArray[i, j].BackColor = Color.White;
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
            else if(checkNextTurnFlag == 0)
            {
                labelTurnOfX.BackColor = Color.White;
                labelTurnOfO.BackColor = Color.Orange;
            }
        }

        //Ghi nhận lượt người chơi thắng và hiển thị điểm số
        public void showPlayerScore()
        {
            if(checkNextTurnFlag == 1)
            {
                xScore++;
                labelXScore.Text = xScore.ToString();
                labelXScore.BackColor = Color.LightYellow;
                labelOScore.BackColor = Color.White;
            }
            if (checkNextTurnFlag == 0)
            {
                oScore++;
                labelOScore.Text = oScore.ToString();
                labelOScore.BackColor = Color.LightYellow;
                labelXScore.BackColor = Color.White;
            }
            savePlayerScoreToFile();
            Console.WriteLine(a);
        }

        //Lưu điểm người chơi vào file
        public void savePlayerScoreToFile()
        {
            string currentDirectory = Environment.CurrentDirectory;
            string fileName = "score.txt"; // Replace with your desired file name
            string path = Path.Combine(currentDirectory, fileName);

            // Data to append
            string newData = $"Điểm của {this.labelPLayer1.Text}: {xScore}\nĐiểm của {this.labelPLayer2.Text}: {oScore}\n----------------\n";

            using (StreamWriter writer = new StreamWriter(path, true)) // The 'true' parameter specifies append mode
            {
                writer.Write(newData);
            }
        }

        //Highlight các ô thắng lượt
        public void higlightVitoryRow(int vitorySide)
        {
            if (vitorySide == 1)
            {
                //highlight các ô mà chứa x thắng
                for (int i = 0; i < 19; i++)
                {
                    for (int j = 0; j < 23; j++)
                    {

                    }
                }
            }   
            else
            {
                //highlight các ô mà chứa o thắng
            }
        }

        //Thiết lập điểm số ban đầu của hai người chơi đều là 0
        public void setScoreWhenStart()
        {
            labelXScore.Text = xScore.ToString();
            labelOScore.Text = oScore.ToString();
        }

        //Khởi tạo bàn cờ gồm các Button
        public void initButtonArray()
        {
            for(int i = 0; i < 19; i++)
            {
                for(int j = 0; j < 23; j++)
                {
                    buttonArray[i, j] = createButton(i, j);
                    attachEventButton(i,j); //Gán sự kiện Mouse Click cho các button trong Button Array
                    attachEventButtonHover(i, j);
                    panelButtonArray.Controls.Add(buttonArray[i, j]);

                    xLocation += 33;
                }
                yLocation += 33;
                xLocation = 0;
            }     
        }

        //Khởi tạo mảng số nguyên lưu trữ các số 0, 1, 2:
        //0: Nước cờ chưa được đánh
        //1: Nước cờ X
        //2: Nước cờ O
        public void initIntArray()
        {
            for(int i = 0; i < 19; i++)
            {
                for(int j = 0; j < 23; j++)
                {
                    a[i, j] = 0;
                }
            }
        }

        //Kiểm tra hàng dọc hướng Xuống
        public void ktDocXuong(int i, int j, int count)
        {
            if(count == 4)
            {
                count = 0;
                showPlayerScore();
                MessageBox.Show("Kết thúc !!", "Thông báo");
                disableAllButton();
                return;
            }
            try
            {
                if (a[i, j] == a[++i, j])
                {
                    count++;
                    ktDocXuong(i, j, count);
                }
            }
            catch (IndexOutOfRangeException)
            {}           
        }

        //Kiểm tra hàng dọc hướng Lên
        public void ktDocLen(int i, int j, int count)
        {
            if (count == 4)
            {
                count = 0;
                showPlayerScore();
                MessageBox.Show("Kết thúc !!", "Thông báo");
                disableAllButton();
                return;
            }
            try
            {
                if (a[i, j] == a[--i, j])
                {
                    count++;
                    ktDocLen(i, j, count);
                }
            }
            catch (IndexOutOfRangeException)
            {}           
        }

        //Kiểm tra hàng ngang qua Phải
        public void ktNgangPhai(int i, int j, int countNgang)
        {
            if(countNgang == 4)
            {
                countNgang = 0;
                showPlayerScore();
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
            catch (IndexOutOfRangeException)
            {}           
        }

        //Kiểm tra hàng ngang qua Trái
        public void ktNgangTrai(int i, int j, int countNgang)
        {
            if (countNgang == 4)
            {
                countNgang = 0;
                showPlayerScore();
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

        //Kiểm tra chéo Trái lên
        public void ktCheoTraiLen(int i, int j, int countCheoTrai)
        {
            if (countCheoTrai == 4)
            {
                countCheoTrai = 0;
                showPlayerScore();
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
            {}           
        }

        //Kiểm tra chéo Trái xuống
        public void ktCheoTraiXuong(int i, int j, int countCheoTrai)
        {
            if (countCheoTrai == 4)
            {
                countCheoTrai = 0;
                showPlayerScore();
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
            {}         
        }

        //Kiểm tra chéo Phải lên
        public void ktCheoPhaiLen(int i, int j, int countCheoPhai)
        {
            if (countCheoPhai == 4)
            {
                countCheoPhai = 0;
                showPlayerScore();
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
            {}
        }

        //Kiểm tra chéo Phải xuống
        public void ktCheoPhaiXuong(int i, int j, int countCheoPhai)
        {
            if (countCheoPhai == 4)
            {
                countCheoPhai = 0;
                showPlayerScore();
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
            {}
        }

        //Ràng buộc các trường hợp nước cờ ở vị trí góc, cạnh và các trường hợp còn lại
        public void rangBuocGoc(int i, int j)
        {
            //Góc trên trái
            if(i == 0 && j == 0)
            {
                ktDocXuong(i, j, count);
                ktNgangPhai(i, j, countNgang);
                ktCheoTraiXuong(i, j, countCheoTrai);
            }
            //Góc trên phải
            else if (i == 0 && j == 22)
            {
                ktDocXuong(i, j, count);
                ktNgangTrai(i, j, countNgang);
                ktCheoPhaiXuong(i, j, countCheoPhai);
            }
            //Góc dưới trái
            else if (i == 18 && j == 0)
            {
                ktDocLen(i, j, count);
                ktNgangPhai(i, j, countNgang);
                ktCheoPhaiLen(i, j, countCheoPhai);
            }
            //Góc dưới phải
            else if (i == 18 && j == 22)
            {
                ktDocLen(i, j, count);
                ktNgangTrai(i, j, countNgang);
                ktCheoTraiLen(i, j, countCheoTrai);
            }
            //Cạnh Left
            else if(i > 0 && i < 18 && j == 0)
            {
                ktDocXuong(i, j, count);
                ktDocLen(i, j, count);
                ktNgangPhai(i, j, countNgang);
            }
            //Cạnh Right
            else if (i > 0 && i < 18 && j == 22)
            {
                ktDocXuong(i, j, count);
                ktDocLen(i, j, count);
                ktNgangTrai(i, j, countNgang);
            }
            //Cạnh Top
            else if (j > 0 && i < 22 && i == 0)
            {
                ktDocXuong(i, j, count);
                ktNgangPhai(i, j, countNgang);
                ktNgangTrai(i, j, countNgang);
            }
            //Cạnh Bottom
            else if (j > 0 && i < 22 && i == 18)
            {
                ktDocLen(i, j, count);
                ktNgangPhai(i, j, countNgang);
                ktNgangTrai(i, j, countNgang);
            }
            else
            {
                ktDocXuong(i, j, count);
                ktDocLen(i, j, count);
                ktNgangPhai(i, j, countNgang);
                ktNgangTrai(i, j, countNgang);
                ktCheoTraiLen(i, j, countCheoTrai);
                ktCheoTraiXuong(i, j, countCheoTrai);
                ktCheoPhaiLen(i, j, countCheoPhai);
                ktCheoPhaiXuong(i, j, countCheoPhai);
            }
        }


        //Vô hiệu ô cờ sau khi nhấn
        public void disableButton(int i, int j)
        {
            buttonArray[i, j].Enabled = false;
        }
        //Vô hiệu hóa cả bàn cờ sau khi 1 người thắng
        public void disableAllButton()
        {
            for (int i = 0; i < 19; i++)
            {
                for (int j = 0; j < 23; j++)
                {
                    buttonArray[i, j].Enabled = false;
                }
            }
        }
        //Tái khởi động bàn cờ
        public void enableAllButton()
        {
            for (int i = 0; i < 19; i++)
            {
                for (int j = 0; j < 23; j++)
                {
                    buttonArray[i, j].Enabled = true;
                }
            }
        }

        //Play Again button
        private void buttonPlayAgain_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < 19; i++)
            {
                for(int j = 0; j < 23; j++)
                {
                    buttonArray[i, j].Text = "";
                    a[i, j] = 0;
                }
            }
            //Set điểm về lại 0
            xScore = 0;
            labelXScore.Text = xScore.ToString();
            oScore = 0;
            labelOScore.Text = oScore.ToString();
            //Set backgroundColor hai ô điểm về màu Trắng
            labelXScore.BackColor = Color.White;
            labelOScore.BackColor = Color.White;
            //Mặc định khi chơi lại, lượt đầu tiên là của X
            checkNextTurnFlag = 1;
            showWhoIsNextTurn();
            //Tái khởi động bàn cờ
            enableAllButton();
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
        private void buttonContinue_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 19; i++)
            {
                for (int j = 0; j < 23; j++)
                {
                    buttonArray[i, j].Text = "";
                    a[i, j] = 0;
                }
            }
            //Set backgroundColor hai ô điểm về màu Trắng
            labelXScore.BackColor = Color.White;
            labelOScore.BackColor = Color.White;
            //Mặc định khi chơi lại, lượt đầu tiên là của X
            checkNextTurnFlag = 1;
            showWhoIsNextTurn();
            //Tái khởi động bàn cờ
            enableAllButton();
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
        private void buttonBackToMenu_Click(object sender, EventArgs e)
        {
            Form0 f = new Form0();
            f.Show();
            this.Hide();
        }

        private void buttonBackToMenu_MouseEnter(object sender, EventArgs e)
        {
            buttonBackToMenu.BackColor = Color.DimGray;
        }

        private void buttonBackToMenu_MouseLeave(object sender, EventArgs e)
        {
            buttonBackToMenu.BackColor = Color.White;
        }


        public Form1()
        {
            InitializeComponent();         
        }

        public Form1(string playerName1, string playerName2)
        {
            InitializeComponent();
            this.labelPLayer1.Text = playerName1;
            this.labelPLayer2.Text = playerName2;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            initButtonArray();
            initIntArray();
            showWhoIsNextTurn();
            setScoreWhenStart();
        }

    }
}
