namespace GameCaro
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelContainer = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.labelTurnOfX = new System.Windows.Forms.Label();
            this.labelTurnOfO = new System.Windows.Forms.Label();
            this.labelOScore = new System.Windows.Forms.Label();
            this.labelXScore = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonPlayAgain = new System.Windows.Forms.Button();
            this.buttonReturn = new System.Windows.Forms.Button();
            this.buttonContinue = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panelContainer
            // 
            this.panelContainer.BackColor = System.Drawing.Color.Black;
            this.panelContainer.Location = new System.Drawing.Point(43, 39);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(386, 386);
            this.panelContainer.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(524, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(265, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Lượt chơi";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTurnOfX
            // 
            this.labelTurnOfX.BackColor = System.Drawing.Color.White;
            this.labelTurnOfX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelTurnOfX.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTurnOfX.Location = new System.Drawing.Point(527, 78);
            this.labelTurnOfX.Name = "labelTurnOfX";
            this.labelTurnOfX.Size = new System.Drawing.Size(128, 37);
            this.labelTurnOfX.TabIndex = 2;
            this.labelTurnOfX.Text = "x";
            this.labelTurnOfX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTurnOfO
            // 
            this.labelTurnOfO.BackColor = System.Drawing.Color.White;
            this.labelTurnOfO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelTurnOfO.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTurnOfO.Location = new System.Drawing.Point(661, 78);
            this.labelTurnOfO.Name = "labelTurnOfO";
            this.labelTurnOfO.Size = new System.Drawing.Size(128, 37);
            this.labelTurnOfO.TabIndex = 3;
            this.labelTurnOfO.Text = "o";
            this.labelTurnOfO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelOScore
            // 
            this.labelOScore.BackColor = System.Drawing.Color.White;
            this.labelOScore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelOScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOScore.Location = new System.Drawing.Point(661, 184);
            this.labelOScore.Name = "labelOScore";
            this.labelOScore.Size = new System.Drawing.Size(128, 80);
            this.labelOScore.TabIndex = 6;
            this.labelOScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelXScore
            // 
            this.labelXScore.BackColor = System.Drawing.Color.White;
            this.labelXScore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelXScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelXScore.Location = new System.Drawing.Point(527, 184);
            this.labelXScore.Name = "labelXScore";
            this.labelXScore.Size = new System.Drawing.Size(128, 80);
            this.labelXScore.TabIndex = 5;
            this.labelXScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(524, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(265, 23);
            this.label5.TabIndex = 4;
            this.label5.Text = "Điểm số";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonPlayAgain
            // 
            this.buttonPlayAgain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonPlayAgain.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPlayAgain.Location = new System.Drawing.Point(661, 284);
            this.buttonPlayAgain.Name = "buttonPlayAgain";
            this.buttonPlayAgain.Size = new System.Drawing.Size(128, 37);
            this.buttonPlayAgain.TabIndex = 7;
            this.buttonPlayAgain.Text = "Chơi lại";
            this.buttonPlayAgain.UseVisualStyleBackColor = true;
            this.buttonPlayAgain.Click += new System.EventHandler(this.button1_Click);
            this.buttonPlayAgain.MouseEnter += new System.EventHandler(this.buttonPlayAgain_MouseEnter);
            this.buttonPlayAgain.MouseLeave += new System.EventHandler(this.buttonPlayAgain_MouseLeave);
            // 
            // buttonReturn
            // 
            this.buttonReturn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonReturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReturn.Location = new System.Drawing.Point(527, 337);
            this.buttonReturn.Name = "buttonReturn";
            this.buttonReturn.Size = new System.Drawing.Size(262, 37);
            this.buttonReturn.TabIndex = 8;
            this.buttonReturn.Text = "Trở về";
            this.buttonReturn.UseVisualStyleBackColor = true;
            this.buttonReturn.Click += new System.EventHandler(this.buttonReturn_Click);
            this.buttonReturn.MouseEnter += new System.EventHandler(this.buttonReturn_MouseEnter);
            this.buttonReturn.MouseLeave += new System.EventHandler(this.buttonReturn_MouseLeave);
            // 
            // buttonContinue
            // 
            this.buttonContinue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonContinue.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonContinue.Location = new System.Drawing.Point(527, 284);
            this.buttonContinue.Name = "buttonContinue";
            this.buttonContinue.Size = new System.Drawing.Size(128, 37);
            this.buttonContinue.TabIndex = 18;
            this.buttonContinue.Text = "Tiếp tục";
            this.buttonContinue.UseVisualStyleBackColor = true;
            this.buttonContinue.Click += new System.EventHandler(this.button1_Click_1);
            this.buttonContinue.MouseEnter += new System.EventHandler(this.buttonContinue_MouseEnter);
            this.buttonContinue.MouseLeave += new System.EventHandler(this.buttonContinue_MouseLeave);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(834, 471);
            this.Controls.Add(this.buttonContinue);
            this.Controls.Add(this.buttonReturn);
            this.Controls.Add(this.buttonPlayAgain);
            this.Controls.Add(this.labelOScore);
            this.Controls.Add(this.labelXScore);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelTurnOfO);
            this.Controls.Add(this.labelTurnOfX);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelContainer);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chế độ chơi hiện đại";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelTurnOfX;
        private System.Windows.Forms.Label labelTurnOfO;
        private System.Windows.Forms.Label labelOScore;
        private System.Windows.Forms.Label labelXScore;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonPlayAgain;
        private System.Windows.Forms.Button buttonReturn;
        private System.Windows.Forms.Button buttonContinue;
    }
}