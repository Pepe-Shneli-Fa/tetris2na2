using System;
using System.Drawing;
using System.Windows.Forms;
using System.Timers;
namespace tetris2na2
{
    public partial class Form1 : Form
    {
        public class Tetromino
        {
            public int[,] Shape { get; set; }
            public int X { get; set; }
            public int Y { get; set; }
            public Color Color { get; set; }

            public Tetromino(int[,] shape, Color color)
            {
                Shape = shape;
                Color = color;
                X = 3;
                Y = 0;
            }

            public void Rotate()
            {
                int rows = Shape.GetLength(0);
                int cols = Shape.GetLength(1);

                int[,] rotated = new int[cols, rows];

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        rotated[j, rows - 1 - i] = Shape[i, j];
                    }
                }

                Shape = rotated;
            }

            public static Tetromino GetRandomPiece(Random rnd)
            {
                int type = rnd.Next(7);

                switch (type)
                {
                    case 0: 
                        return new Tetromino(new int[,] { { 1, 1, 1, 1 } }, Color.Cyan);
                    case 1: 
                        return new Tetromino(new int[,] { { 1, 1 }, { 1, 1 } }, Color.Yellow);
                    case 2:
                        return new Tetromino(new int[,] { { 0, 1, 0 }, { 1, 1, 1 } }, Color.Purple);
                    case 3: 
                        return new Tetromino(new int[,] { { 0, 1, 1 }, { 1, 1, 0 } }, Color.Green);
                    case 4: 
                        return new Tetromino(new int[,] { { 1, 1, 0 }, { 0, 1, 1 } }, Color.Red);
                    case 5: 
                        return new Tetromino(new int[,] { { 1, 0, 0 }, { 1, 1, 1 } }, Color.Blue);
                    case 6: 
                        return new Tetromino(new int[,] { { 0, 0, 1 }, { 1, 1, 1 } }, Color.Orange);
                    default:
                        return new Tetromino(new int[,] { { 1 } }, Color.White);
                }
            }
        }
        private int[,] field1 = new int[10, 20];
        private int[,] field2 = new int[10, 20];

        private Tetromino currentPiece1;
        private Tetromino currentPiece2;

        private Tetromino nextPiece1;
        private Tetromino nextPiece2;

        private int score1 = 0;
        private int score2 = 0;

        private System.Windows.Forms.Timer gameTimer;

        private bool isPaused = false;

        private bool gameOver = false;

        private Random random = new Random();
        public Form1()
        {
            InitializeComponent();

            typeof(Panel).InvokeMember("DoubleBuffered",
        System.Reflection.BindingFlags.SetProperty |
        System.Reflection.BindingFlags.Instance |
        System.Reflection.BindingFlags.NonPublic,
        null, panelGame1, new object[] { true });

            typeof(Panel).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic,
                null, panelGame2, new object[] { true });

            typeof(Panel).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic,
                null, panelNext1, new object[] { true });

            typeof(Panel).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic,
                null, panelNext2, new object[] { true });
            gameTimer = new System.Windows.Forms.Timer();
            gameTimer.Interval = 500;
            gameTimer.Tick += GameTimer_Tick;

            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;

            NewGame();
        }

        private void NewGame()
        {
            field1 = new int[10, 20];
            field2 = new int[10, 20];

            score1 = 0;
            score2 = 0;
            UpdateScore();

            currentPiece1 = Tetromino.GetRandomPiece(random);
            currentPiece2 = Tetromino.GetRandomPiece(random);
            nextPiece1 = Tetromino.GetRandomPiece(random);
            nextPiece2 = Tetromino.GetRandomPiece(random);

            gameOver = false;
            isPaused = false;
            btnPause.Text = "Пауза";
            lblStatus.Text = "Игра идет";

            gameTimer.Start();
        }
            private void ToggleFullScreen()
        {
            if (this.FormBorderStyle == FormBorderStyle.None)
            {
                this.FormBorderStyle = FormBorderStyle.FixedSingle;
                this.WindowState = FormWindowState.Normal;
                this.TopMost = false;
                lblStatus.Text = "Игра идет";
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                this.TopMost = true; 
                lblStatus.Text = "Полноэкранный режим (T)";
            }

            this.Invalidate();

        panelGame1.Invalidate();
            panelGame2.Invalidate();
            panelNext1.Invalidate();
            panelNext2.Invalidate();
        }

        private void UpdateScore()
        {
            lblScore1.Text = score1.ToString();
            lblScore2.Text = score2.ToString();
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (gameOver || isPaused) return;

            if (!MovePieceDown(field1, currentPiece1))
            {
                PlacePiece(field1, ref currentPiece1, ref nextPiece1, ref score1);
            }

            if (!MovePieceDown(field2, currentPiece2))
            {
                PlacePiece(field2, ref currentPiece2, ref nextPiece2, ref score2);
            }

            panelGame1.Invalidate();
            panelGame2.Invalidate();
            panelNext1.Invalidate();
            panelNext2.Invalidate();
        }

        private bool MovePieceDown(int[,] field, Tetromino piece)
        {
            piece.Y++;
            if (Collision(field, piece))
            {
                piece.Y--;
                return false;
            }
            return true;
        }

        private bool Collision(int[,] field, Tetromino piece)
        {
            for (int i = 0; i < piece.Shape.GetLength(0); i++)
            {
                for (int j = 0; j < piece.Shape.GetLength(1); j++)
                {
                    if (piece.Shape[i, j] == 1)
                    {
                        int x = piece.X + i;
                        int y = piece.Y + j;

                        if (x < 0 || x >= 10 || y >= 20)
                            return true;

                        if (y >= 0 && field[x, y] == 1)
                            return true;
                    }
                }
            }
            return false;
        }

        private void PlacePiece(int[,] field, ref Tetromino currentPiece, ref Tetromino nextPiece, ref int score)
        {
            for (int i = 0; i < currentPiece.Shape.GetLength(0); i++)
            {
                for (int j = 0; j < currentPiece.Shape.GetLength(1); j++)
                {
                    if (currentPiece.Shape[i, j] == 1)
                    {
                        int x = currentPiece.X + i;
                        int y = currentPiece.Y + j;
                        if (x >= 0 && x < 10 && y >= 0 && y < 20)
                        {
                            field[x, y] = 1;
                        }
                    }
                }
            }

            CheckLines(field, ref score);

            currentPiece = nextPiece;
            currentPiece.X = 3;
            currentPiece.Y = 0;
            nextPiece = Tetromino.GetRandomPiece(random);

            if (Collision(field, currentPiece))
            {
                gameOver = true;
                gameTimer.Stop();

                if (field == field1)
                    lblStatus.Text = "Игрок 2 победил!";
                else
                    lblStatus.Text = "Игрок 1 победил!";
            }

            UpdateScore();
        }

        private void CheckLines(int[,] field, ref int score)
        {
            int linesCleared = 0;

            for (int y = 19; y >= 0; y--)
            {
                bool fullLine = true;

                for (int x = 0; x < 10; x++)
                {
                    if (field[x, y] == 0)
                    {
                        fullLine = false;
                        break;
                    }
                }

                if (fullLine)
                {
                    linesCleared++;

                    for (int yy = y; yy > 0; yy--)
                    {
                        for (int x = 0; x < 10; x++)
                        {
                            field[x, yy] = field[x, yy - 1];
                        }
                    }

                    for (int x = 0; x < 10; x++)
                    {
                        field[x, 0] = 0;
                    }

                    y++;
                }
            }

            if (linesCleared > 0)
            {
                score += linesCleared * 100;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;

            if (e.KeyCode == Keys.F2) 
            {
                NewGame();
                return;
            }
            if (e.KeyCode == Keys.P) 
            {
                btnPause.PerformClick();
                return;
            }
            if (e.KeyCode == Keys.Escape) 
            {
                btnExit.PerformClick();
                return;
            }
            if (e.KeyCode == Keys.T)
            {
                ToggleFullScreen();
                return;
            }

            if (gameOver || isPaused) return;

            if (e.KeyCode == Keys.A)
            {
                currentPiece1.X--;
                if (Collision(field1, currentPiece1))
                    currentPiece1.X++;
            }
            else if (e.KeyCode == Keys.D) 
            {
                currentPiece1.X++;
                if (Collision(field1, currentPiece1))
                    currentPiece1.X--;
            }
            else if (e.KeyCode == Keys.W)
            {
                currentPiece1.Rotate();
                if (Collision(field1, currentPiece1))
                {
                    currentPiece1.X--;
                    if (!Collision(field1, currentPiece1)) { }
                    else
                    {
                        currentPiece1.X += 2;
                        if (!Collision(field1, currentPiece1)) { }
                        else
                        {
                            currentPiece1.X--;
                            for (int i = 0; i < 3; i++)
                                currentPiece1.Rotate();
                        }
                    }
                }
            }
            else if (e.KeyCode == Keys.S)
            {
                MovePieceDown(field1, currentPiece1);
            }
            else if (e.KeyCode == Keys.Space) 
            {
                while (MovePieceDown(field1, currentPiece1)) { }
                PlacePiece(field1, ref currentPiece1, ref nextPiece1, ref score1);
            }

            else if (e.KeyCode == Keys.J)
            {
                currentPiece2.X--;
                if (Collision(field2, currentPiece2))
                    currentPiece2.X++;
            }
            else if (e.KeyCode == Keys.L) 
            {
                currentPiece2.X++;
                if (Collision(field2, currentPiece2))
                    currentPiece2.X--;
            }
            else if (e.KeyCode == Keys.I) 
            {
                int oldX = currentPiece2.X;
                int[,] oldShape = currentPiece2.Shape;

                currentPiece2.Rotate();

                while (currentPiece2.X < 0)
                {
                    currentPiece2.X++;
                }

                while (currentPiece2.X + currentPiece2.Shape.GetLength(0) > 10)
                {
                    currentPiece2.X--;
                }

                if (Collision(field2, currentPiece2))
                {
                    currentPiece2.Shape = oldShape;
                    currentPiece2.X = oldX;
                }
            }
            else if (e.KeyCode == Keys.K) 
            {
                MovePieceDown(field2, currentPiece2);
            }
            else if (e.KeyCode == Keys.H) 
            {
                while (MovePieceDown(field2, currentPiece2)) { }
                PlacePiece(field2, ref currentPiece2, ref nextPiece2, ref score2);
            }

            panelGame1.Invalidate();
            panelGame2.Invalidate();
            panelNext1.Invalidate();
            panelNext2.Invalidate();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lblSeparator_Click(object sender, EventArgs e)
        {

        }

        private void lblScore2_Click(object sender, EventArgs e)
        {

        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            isPaused = !isPaused;

            if (isPaused)
            {
                gameTimer.Stop();
                btnPause.Text = "Продолжить";
                lblStatus.Text = "Пауза";
            }
            else
            {
                gameTimer.Start();
                btnPause.Text = "Пауза";
                lblStatus.Text = "Игра идет";
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
               "Точно выйти?",
               "Выход",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question
           );

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void lblPlayer1_Click(object sender, EventArgs e)
        {

        }

        private void lblScore1_Click(object sender, EventArgs e)
        {

        }

        private void lblPlayer2_Click(object sender, EventArgs e)
        {

        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }

        private void lblNext1_Click(object sender, EventArgs e)
        {

        }

        private void panelNext1_Paint(object sender, PaintEventArgs e)
        {
            DrawNextPiece(e.Graphics, nextPiece1);
        }

        private void lblNext2_Click(object sender, EventArgs e)
        {

        }

        private void panelNext2_Paint(object sender, PaintEventArgs e)
        {
            DrawNextPiece(e.Graphics, nextPiece2);
        }
        private void DrawField(Graphics g, int[,] field, Tetromino currentPiece)
        {
            int cellSize = 20;

            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 20; y++)
                {
                    Rectangle cell = new Rectangle(
                        x * cellSize,
                        y * cellSize,
                        cellSize - 1,
                        cellSize - 1
                    );

                    if (field[x, y] == 1)
                    {
                        g.FillRectangle(Brushes.Blue, cell);
                    }
                    else
                    {
                        g.DrawRectangle(Pens.Gray, cell);
                    }
                }
            }

            if (currentPiece != null && !gameOver)
            {
                for (int i = 0; i < currentPiece.Shape.GetLength(0); i++)
                {
                    for (int j = 0; j < currentPiece.Shape.GetLength(1); j++)
                    {
                        if (currentPiece.Shape[i, j] == 1)
                        {
                            int x = currentPiece.X + i;
                            int y = currentPiece.Y + j;

                            if (x >= 0 && x < 10 && y >= 0 && y < 20)
                            {
                                Rectangle cell = new Rectangle(
                                    x * cellSize,
                                    y * cellSize,
                                    cellSize - 1,
                                    cellSize - 1
                                );
                                g.FillRectangle(new SolidBrush(currentPiece.Color), cell);
                            }
                        }
                    }
                }
            }
        }

        private void DrawNextPiece(Graphics g, Tetromino piece)
        {
            g.Clear(Color.DarkGray);

            if (piece != null)
            {
                int cellSize = 20;
                int offsetX = (panelNext1.Width - piece.Shape.GetLength(0) * cellSize) / 2;
                int offsetY = (panelNext1.Height - piece.Shape.GetLength(1) * cellSize) / 2;

                for (int i = 0; i < piece.Shape.GetLength(0); i++)
                {
                    for (int j = 0; j < piece.Shape.GetLength(1); j++)
                    {
                        if (piece.Shape[i, j] == 1)
                        {
                            Rectangle cell = new Rectangle(
                                offsetX + i * cellSize,
                                offsetY + j * cellSize,
                                cellSize - 1,
                                cellSize - 1
                            );
                            g.FillRectangle(new SolidBrush(piece.Color), cell);
                        }
                    }
                }
            }
        }
        private void panelGame1_Paint(object sender, PaintEventArgs e)
        {
            DrawField(e.Graphics, field1, currentPiece1);
        }

        private void panelGame2_Paint(object sender, PaintEventArgs e)
        {
            DrawField(e.Graphics, field2, currentPiece2);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void gbControls1_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void gbControls2_Enter(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btnFullScreen_Click(object sender, EventArgs e)
        {
            ToggleFullScreen();
        }
    }
}
