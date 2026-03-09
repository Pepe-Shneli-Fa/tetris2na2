namespace tetris2na2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblPlayer1 = new Label();
            lblPlayer2 = new Label();
            lblScore1 = new Label();
            lblScore2 = new Label();
            lblSeparator = new Label();
            lblNext1 = new Label();
            lblNext2 = new Label();
            gbControls1 = new GroupBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            gbControls2 = new GroupBox();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            btnNewGame = new Button();
            btnPause = new Button();
            btnExit = new Button();
            panelGame1 = new Panel();
            panelGame2 = new Panel();
            panelNext1 = new Panel();
            panelNext2 = new Panel();
            lblStatus = new Label();
            btnFullScreen = new Button();
            gbControls1.SuspendLayout();
            gbControls2.SuspendLayout();
            SuspendLayout();
            // 
            // lblPlayer1
            // 
            lblPlayer1.AutoSize = true;
            lblPlayer1.Location = new Point(644, 120);
            lblPlayer1.Name = "lblPlayer1";
            lblPlayer1.Size = new Size(75, 25);
            lblPlayer1.TabIndex = 0;
            lblPlayer1.Text = "игрок 1";
            lblPlayer1.Click += lblPlayer1_Click;
            // 
            // lblPlayer2
            // 
            lblPlayer2.AutoSize = true;
            lblPlayer2.Location = new Point(959, 120);
            lblPlayer2.Name = "lblPlayer2";
            lblPlayer2.Size = new Size(75, 25);
            lblPlayer2.TabIndex = 1;
            lblPlayer2.Text = "игрок 2";
            lblPlayer2.Click += lblPlayer2_Click;
            // 
            // lblScore1
            // 
            lblScore1.AutoSize = true;
            lblScore1.ForeColor = Color.Blue;
            lblScore1.Location = new Point(723, 123);
            lblScore1.Name = "lblScore1";
            lblScore1.Size = new Size(53, 25);
            lblScore1.TabIndex = 2;
            lblScore1.Text = "Счёт:";
            lblScore1.Click += lblScore1_Click;
            // 
            // lblScore2
            // 
            lblScore2.AutoSize = true;
            lblScore2.ForeColor = Color.FromArgb(192, 0, 0);
            lblScore2.Location = new Point(1040, 120);
            lblScore2.Name = "lblScore2";
            lblScore2.Size = new Size(53, 25);
            lblScore2.TabIndex = 3;
            lblScore2.Text = "Счёт:";
            lblScore2.Click += lblScore2_Click;
            // 
            // lblSeparator
            // 
            lblSeparator.AutoSize = true;
            lblSeparator.Location = new Point(853, 54);
            lblSeparator.Name = "lblSeparator";
            lblSeparator.Size = new Size(0, 25);
            lblSeparator.TabIndex = 4;
            lblSeparator.Click += lblSeparator_Click;
            // 
            // lblNext1
            // 
            lblNext1.AutoSize = true;
            lblNext1.Location = new Point(628, 175);
            lblNext1.Name = "lblNext1";
            lblNext1.Size = new Size(45, 25);
            lblNext1.TabIndex = 5;
            lblNext1.Text = "next";
            lblNext1.Click += lblNext1_Click;
            // 
            // lblNext2
            // 
            lblNext2.AutoSize = true;
            lblNext2.Location = new Point(926, 175);
            lblNext2.Name = "lblNext2";
            lblNext2.Size = new Size(45, 25);
            lblNext2.TabIndex = 6;
            lblNext2.Text = "next";
            lblNext2.Click += lblNext2_Click;
            // 
            // gbControls1
            // 
            gbControls1.Controls.Add(label4);
            gbControls1.Controls.Add(label3);
            gbControls1.Controls.Add(label2);
            gbControls1.Controls.Add(label1);
            gbControls1.Location = new Point(620, 647);
            gbControls1.Name = "gbControls1";
            gbControls1.Size = new Size(185, 150);
            gbControls1.TabIndex = 7;
            gbControls1.TabStop = false;
            gbControls1.Text = "Управление для 1";
            gbControls1.Enter += gbControls1_Enter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 104);
            label4.Name = "label4";
            label4.Size = new Size(149, 25);
            label4.TabIndex = 3;
            label4.Text = "Пробел → сброс";
            label4.Click += label4_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 52);
            label3.Name = "label3";
            label3.Size = new Size(122, 25);
            label3.TabIndex = 2;
            label3.Text = "S → ускорить";
            label3.Click += label3_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 70);
            label2.Name = "label2";
            label2.Size = new Size(126, 25);
            label2.TabIndex = 1;
            label2.Text = "W → поворот";
            label2.Click += label2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 27);
            label1.Name = "label1";
            label1.Size = new Size(161, 25);
            label1.TabIndex = 0;
            label1.Text = "A / D → движение";
            label1.Click += label1_Click;
            // 
            // gbControls2
            // 
            gbControls2.Controls.Add(label8);
            gbControls2.Controls.Add(label7);
            gbControls2.Controls.Add(label6);
            gbControls2.Controls.Add(label5);
            gbControls2.Location = new Point(909, 647);
            gbControls2.Name = "gbControls2";
            gbControls2.Size = new Size(217, 150);
            gbControls2.TabIndex = 8;
            gbControls2.TabStop = false;
            gbControls2.Text = "Управление для 2";
            gbControls2.Enter += gbControls2_Enter;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(21, 115);
            label8.Name = "label8";
            label8.Size = new Size(99, 25);
            label8.TabIndex = 3;
            label8.Text = "H → сброс";
            label8.Click += label8_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(24, 88);
            label7.Name = "label7";
            label7.Size = new Size(122, 25);
            label7.TabIndex = 2;
            label7.Text = "K → ускорить";
            label7.Click += label7_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(22, 58);
            label6.Name = "label6";
            label6.Size = new Size(123, 25);
            label6.TabIndex = 1;
            label6.Text = "O → поворот";
            label6.Click += label6_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(20, 33);
            label5.Name = "label5";
            label5.Size = new Size(150, 25);
            label5.TabIndex = 0;
            label5.Text = "J / L → движение";
            label5.Click += label5_Click;
            // 
            // btnNewGame
            // 
            btnNewGame.BackColor = Color.LightGreen;
            btnNewGame.ForeColor = SystemColors.ActiveCaptionText;
            btnNewGame.Location = new Point(608, 55);
            btnNewGame.Name = "btnNewGame";
            btnNewGame.Size = new Size(188, 34);
            btnNewGame.TabIndex = 9;
            btnNewGame.Text = "Новая игра";
            btnNewGame.UseVisualStyleBackColor = false;
            btnNewGame.Click += btnNewGame_Click;
            // 
            // btnPause
            // 
            btnPause.BackColor = Color.LightYellow;
            btnPause.Location = new Point(859, 54);
            btnPause.Name = "btnPause";
            btnPause.Size = new Size(112, 34);
            btnPause.TabIndex = 10;
            btnPause.Text = "Пауза";
            btnPause.UseVisualStyleBackColor = false;
            btnPause.Click += btnPause_Click;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.LightCoral;
            btnExit.Location = new Point(1014, 55);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(112, 34);
            btnExit.TabIndex = 11;
            btnExit.Text = "Выход";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // panelGame1
            // 
            panelGame1.BackColor = Color.Black;
            panelGame1.BorderStyle = BorderStyle.FixedSingle;
            panelGame1.Location = new Point(615, 241);
            panelGame1.Name = "panelGame1";
            panelGame1.Size = new Size(200, 400);
            panelGame1.TabIndex = 12;
            panelGame1.Paint += panelGame1_Paint;
            // 
            // panelGame2
            // 
            panelGame2.BackColor = Color.Black;
            panelGame2.BorderStyle = BorderStyle.FixedSingle;
            panelGame2.Location = new Point(909, 241);
            panelGame2.Name = "panelGame2";
            panelGame2.Size = new Size(200, 400);
            panelGame2.TabIndex = 13;
            panelGame2.Paint += panelGame2_Paint;
            // 
            // panelNext1
            // 
            panelNext1.BackColor = Color.DarkGray;
            panelNext1.BorderStyle = BorderStyle.FixedSingle;
            panelNext1.Location = new Point(679, 155);
            panelNext1.Name = "panelNext1";
            panelNext1.Size = new Size(80, 80);
            panelNext1.TabIndex = 14;
            panelNext1.Paint += panelNext1_Paint;
            // 
            // panelNext2
            // 
            panelNext2.BackColor = Color.DarkGray;
            panelNext2.BorderStyle = BorderStyle.FixedSingle;
            panelNext2.Location = new Point(977, 155);
            panelNext2.Name = "panelNext2";
            panelNext2.Size = new Size(80, 80);
            panelNext2.TabIndex = 15;
            panelNext2.Paint += panelNext2_Paint;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(1201, 114);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(93, 25);
            lblStatus.TabIndex = 16;
            lblStatus.Text = "Игра идет";
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            lblStatus.Click += lblStatus_Click;
            // 
            // btnFullScreen
            // 
            btnFullScreen.Location = new Point(1190, 172);
            btnFullScreen.Name = "btnFullScreen";
            btnFullScreen.Size = new Size(112, 34);
            btnFullScreen.TabIndex = 17;
            btnFullScreen.Text = "Fullscrean";
            btnFullScreen.UseVisualStyleBackColor = true;
            btnFullScreen.Click += btnFullScreen_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.AppWorkspace;
            ClientSize = new Size(1924, 1050);
            Controls.Add(btnFullScreen);
            Controls.Add(lblStatus);
            Controls.Add(panelNext2);
            Controls.Add(panelNext1);
            Controls.Add(panelGame2);
            Controls.Add(panelGame1);
            Controls.Add(btnExit);
            Controls.Add(btnPause);
            Controls.Add(btnNewGame);
            Controls.Add(gbControls2);
            Controls.Add(gbControls1);
            Controls.Add(lblNext2);
            Controls.Add(lblNext1);
            Controls.Add(lblSeparator);
            Controls.Add(lblScore2);
            Controls.Add(lblScore1);
            Controls.Add(lblPlayer2);
            Controls.Add(lblPlayer1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            FormScreenCaptureMode = ScreenCaptureMode.HideWindow;
            KeyPreview = true;
            MaximizeBox = false;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            gbControls1.ResumeLayout(false);
            gbControls1.PerformLayout();
            gbControls2.ResumeLayout(false);
            gbControls2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPlayer1;
        private Label lblPlayer2;
        private Label lblScore1;
        private Label lblScore2;
        private Label lblSeparator;
        private Label lblNext1;
        private Label lblNext2;
        private GroupBox gbControls1;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private GroupBox gbControls2;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Button btnNewGame;
        private Button btnPause;
        private Button btnExit;
        private Panel panelGame1;
        private Panel panelGame2;
        private Panel panelNext1;
        private Panel panelNext2;
        private Label lblStatus;
        private Button btnFullScreen;
    }
}
