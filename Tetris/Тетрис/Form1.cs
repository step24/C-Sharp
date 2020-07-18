using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace Тетрис
{
    public partial class Form1 : Form
    {
        Square[,] desk = new Square[10, 20];

        int[] records = new int[10];

        bool ProcessGame;
        bool ifod;
        int BaseLVL;

        Random rnd = new Random(DateTime.Now.Millisecond);

        BaseFigure f, fNext;

        int level = 0, lines = 0, points = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Size s = new Size(800, 660);
            this.MinimumSize = s;
            this.MaximumSize = s;
            this.Location = new Point(50, 50);

            GetRecords();

            ProcessGame = false;
            ifod = false;

            for (int i = 0; i < desk.GetLength(0); i++)
                for (int j = 0; j < desk.GetLength(1); j++)
                    desk[i, j] = Square.Empty;
            BaseLVL = 0;

        }

        int DeleteLine()
        {
            int Lines = 0;
            bool thisline = true;
            for (int i = 0; i < desk.GetLength(1); i++)
            {
                if (desk[0, i].Flag)
                    thisline = true;
                else thisline = false;
                for (int j = 0; j < desk.GetLength(0); j++)
                {
                    if (desk[j, i].Flag && thisline)
                        thisline = true;
                    else
                    {
                        thisline = false;
                        break;
                    }
                }
                if (thisline)
                {
                    Lines++;
                    for (int q = i; q >= 1; q--)
                        for (int w = 0; w < desk.GetLength(0); w++)
                        {
                            desk[w, q] = desk[w, q - 1];
                        }
                    for (int w = 0; w < desk.GetLength(0); w++)
                        desk[w, 0] = Square.Empty;
                }
            }
            return Lines;
        }

        bool CanCreate()
        {
            if (f is Figure1)
            {
                if (desk[4, 0].Flag || desk[4, 1].Flag || desk[4, 2].Flag || desk[4, 3].Flag)
                    return false;
                else return true;
            }
            if (f is Figure2)
            {
                if (desk[4, 0].Flag || desk[4, 1].Flag || desk[5, 0].Flag || desk[5, 1].Flag)
                    return false;
                else return true;
            }
            if (f is Figure3)
            {
                if (desk[4, 0].Flag || desk[4, 1].Flag || desk[5, 1].Flag || desk[5, 2].Flag)
                    return false;
                return true;
            }
            if (f is Figure4)
            {
                if (desk[4, 1].Flag || desk[4, 2].Flag || desk[5, 0].Flag || desk[5, 1].Flag)
                    return false;
                return true;
            }
            if (f is Figure5)
            {
                if (desk[4, 0].Flag || desk[4, 1].Flag || desk[4, 2].Flag || desk[5, 2].Flag)
                    return false;
                return true;
            }
            if (f is Figure6)
            {
                if (desk[5, 0].Flag || desk[5, 1].Flag || desk[5, 2].Flag || desk[4, 2].Flag)
                    return false;
                return true;
            }
            if (f is Figure7)
            {
                if (desk[4, 0].Flag || desk[4, 1].Flag || desk[4, 2].Flag || desk[5, 1].Flag)
                    return false;
                return true;
            }
            return false;
        }

        private void GetRecords()
        {
            if (!File.Exists("records.txt"))
                for (int i = 0; i < 10; i++)
                    records[i] = -1000;
            else
            {
                string[] arr = File.ReadAllLines("records.txt");
                int i;
                for (i = 0; i < 10 && i < arr.Length; i++)
                    records[i] = Convert.ToInt32(arr[i]);
                for (; i < 10; i++)
                    records[i] = -1000;
            }
            rec1.Text = records[0] == -1000 ? "" : Convert.ToString(records[0]);
            rec2.Text = records[1] == -1000 ? "" : Convert.ToString(records[1]);
            rec3.Text = records[2] == -1000 ? "" : Convert.ToString(records[2]);
            rec4.Text = records[3] == -1000 ? "" : Convert.ToString(records[3]);
            rec5.Text = records[4] == -1000 ? "" : Convert.ToString(records[4]);
            rec6.Text = records[5] == -1000 ? "" : Convert.ToString(records[5]);
            rec7.Text = records[6] == -1000 ? "" : Convert.ToString(records[6]);
            rec8.Text = records[7] == -1000 ? "" : Convert.ToString(records[7]);
            rec9.Text = records[8] == -1000 ? "" : Convert.ToString(records[8]);
            rec10.Text = records[9] == -1000 ? "" : Convert.ToString(records[9]);

        }

        private void WriteRecords()
        {
            for(int i = 0; i < 10; i++)
                if (points > records[i])
                {
                    for (int j = 9; j > i; j--)
                        records[j] = records[j - 1];

                    records[i] = points;
                    break;
                }

            StreamWriter sw = new StreamWriter("records.txt");
            for (int i = 0; i < 10; i++)
            {
                if (records[i] == -1000)
                    break;
                sw.WriteLine(records[i]);
            }
            sw.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int p = points % 3000;
            int o = points - p;
            level = BaseLVL + o / 3000;

            try
            {
                timer1.Interval = 1000 - level * 100;
            }
            catch
            {
                timer1.Interval = 100;
            }

            if (ifod)
            {
                if (MoveDown())
                {
                    for (int i = 0; i < f.Fi.GetLength(0); i++)
                        for (int j = 0; j < f.Fi.GetLength(1); j++)
                            if (f.Fi[i, j].Flag)
                                desk[f.Position.I + i, f.Position.J + j] = f.Fi[i, j];
                    points -= (level + 1);
                }
                else
                {
                    ifod = false;
                    if (!MoveDown(1))
                    {
                        points += f.Position.J * (level + 1);
                        int deletedlines = DeleteLine();
                        lines += deletedlines;
                        points += Convert.ToInt32(10 * Math.Pow(deletedlines, 2)) * (level + 1);
                    }
                    else return;
                }
            }
            if (!ifod)
            {
                f = fNext;
                if (CanCreate())
                {
                    ProcessGame = true;
                    ifod = true;
                }
                else ProcessGame = false;
                for (int i = 0; i < f.Fi.GetLength(0); i++)
                    for (int j = 0; j < f.Fi.GetLength(1); j++)
                        if (f.Fi[i, j].Flag)
                            desk[i + f.Position.I, j + f.Position.J] = f.Fi[i, j];
                if (ProcessGame)
                {
                    StartPosition positionFNext;
                    positionFNext.I = 4;
                    positionFNext.J = 0;

                    switch (rnd.Next(1, 8))
                    {
                        case 1: fNext = new Figure1(rnd, positionFNext); break;
                        case 2: fNext = new Figure2(rnd, positionFNext); break;
                        case 3: fNext = new Figure3(rnd, positionFNext); break;
                        case 4: fNext = new Figure4(rnd, positionFNext); break;
                        case 5: fNext = new Figure5(rnd, positionFNext); break;
                        case 6: fNext = new Figure6(rnd, positionFNext); break;
                        case 7: fNext = new Figure7(rnd, positionFNext); break;
                    }
                }
                else
                {
                    timer1.Stop();
                    pictureBox1.Invalidate();
                    pictureBox2.Invalidate();
                    WriteRecords();
                    MessageBox.Show("Игра окончена со счетом " + Convert.ToString(points) + ", на уровне " + Convert.ToString(level) + ", после удаления " + Convert.ToString(lines) + " строк(-и)", "Игра окончена");
                    GetRecords();
                }
            }

            _lines.Text = Convert.ToString(lines);
            _points.Text = Convert.ToString(points);
            _level.Text = Convert.ToString(level);

            pictureBox1.Invalidate();
            pictureBox2.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetRecords();
            if (!ProcessGame)
            {
                lines = 0;
                points = 0;
                BaseLVL = Convert.ToInt32(numericUpDown1.Value);
                level = BaseLVL;

                ProcessGame = true;
                for (int i = 0; i < desk.GetLength(0); i++)
                    for (int j = 0; j < desk.GetLength(1); j++)
                        desk[i, j] = Square.Empty;

                ifod = false;

                StartPosition positionFNext;

                positionFNext.I = 4;
                positionFNext.J = 0;

                switch (rnd.Next(1, 8))
                {
                    case 1: fNext = new Figure1(rnd, positionFNext); break;
                    case 2: fNext = new Figure2(rnd, positionFNext); break;
                    case 3: fNext = new Figure3(rnd, positionFNext); break;
                    case 4: fNext = new Figure4(rnd, positionFNext); break;
                    case 5: fNext = new Figure5(rnd, positionFNext); break;
                    case 6: fNext = new Figure6(rnd, positionFNext); break;
                    case 7: fNext = new Figure7(rnd, positionFNext); break;
                }

                timer1.Start();
                timer1_Tick(sender, e);
            }
        }

        /// <summary>
        /// Обработчик клавиши
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (ProcessGame)
            {
                if (keyData == Keys.Down)
                    MoveDown();
                if (keyData == Keys.Up)
                    Turn();
                if (keyData == Keys.Left)
                    MoveLeft();
                if (keyData == Keys.Right)
                    MoveRight();
                if (keyData == Keys.Y)
                {
                    KeyY();
                    MessageBox.Show("Игра временно приостановлена", "Временная приостановка игры");
                    KeyY();
                    return base.ProcessCmdKey(ref msg, keyData);
                }
                if (keyData == Keys.Escape)
                {
                    if (ProcessGame)
                    {
                        ProcessGame = false;
                        ifod = false;
                        timer1.Stop();
                        WriteRecords();
                        MessageBox.Show("Игра окончена со счетом " + Convert.ToString(points) + ", на уровне " + Convert.ToString(level) + ", после удаления " + Convert.ToString(lines) + " строк(-и)", "Игра окончена по Вашей инициативе");
                        GetRecords();
                    }
                    else return base.ProcessCmdKey(ref msg, keyData);
                }

                for (int i = 0; i < f.Fi.GetLength(0); i++)
                {
                    for (int j = 0; j < f.Fi.GetLength(1); j++)
                    {
                        if (f.Fi[i, j].Flag)
                            desk[i + f.Position.I, j + f.Position.J] = f.Fi[i, j];
                    }
                }
                pictureBox1.Invalidate();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int k = pictureBox1.Width / 10;
            g.Clear(Color.WhiteSmoke);
            for (int i = 0; i < desk.GetLength(0); i++)
                for (int j = 0; j < desk.GetLength(1); j++)
                    g.FillRectangle(new SolidBrush(desk[i, j].Color), i * k + 1, j * k + 1, k - 2, k - 2);
        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            if (ProcessGame)
            {
                Graphics g = e.Graphics;
                int k = pictureBox1.Width / 10;
                g.Clear(Color.White);
                g.DrawString("Следующая фигура:", new Font("Times New Roman", 14, FontStyle.Italic), new SolidBrush(Color.Black), 10, 10);
                for (int i = 0; i < fNext.Fi.GetLength(0); i++)
                    for (int j = 0; j < fNext.Fi.GetLength(1); j++)
                        g.FillRectangle(new SolidBrush(fNext.Fi[i, j].Color), 40 + (i + 1) * k + 1, 40 + (j + 1) * k + 1, k - 2, k - 2);
            }
        }

        bool MoveDown()
        {
            bool con = false;

            if (f is Figure1)
            {
                if (f.Location == FigureLocation.Up || f.Location == FigureLocation.Down)
                {
                    if (f.Position.J == 16 || desk[f.Position.I, f.Position.J + 4].Flag)
                        con = false;
                    else con = true;
                    if (con)
                    {
                        desk[f.Position.I, f.Position.J] = Square.Empty;
                    }
                }
                if (f.Location == FigureLocation.Left || f.Location == FigureLocation.Right)
                {
                    if (f.Position.J == 19 || desk[f.Position.I, f.Position.J + 1].Flag || desk[f.Position.I + 1, f.Position.J + 1].Flag || desk[f.Position.I + 2, f.Position.J + 1].Flag || desk[f.Position.I + 3, f.Position.J + 1].Flag)
                        con = false;
                    else con = true;
                    if (con)
                    {
                        desk[f.Position.I, f.Position.J] = Square.Empty; desk[f.Position.I + 1, f.Position.J] = Square.Empty; desk[f.Position.I + 2, f.Position.J] = Square.Empty; desk[f.Position.I + 3, f.Position.J] = Square.Empty;
                    }
                }
            }

            if (f is Figure2)
            {
                if (f.Position.J == 18 || desk[f.Position.I, f.Position.J + 2].Flag || desk[f.Position.I + 1, f.Position.J + 2].Flag)
                    con = false;
                else con = true;
                if (con)
                {
                    desk[f.Position.I, f.Position.J] = Square.Empty; desk[f.Position.I + 1, f.Position.J] = Square.Empty;
                }
            }

            if (f is Figure3)
            {
                if (f.Location == FigureLocation.Up || f.Location == FigureLocation.Down)
                {
                    if (f.Position.J == 17 || desk[f.Position.I, f.Position.J + 2].Flag || desk[f.Position.I + 1, f.Position.J + 3].Flag)
                        con = false;
                    else con = true;
                    if (con)
                    {
                        desk[f.Position.I, f.Position.J] = Square.Empty; desk[f.Position.I + 1, f.Position.J + 1] = Square.Empty;
                    }
                }
                if (f.Location == FigureLocation.Left || f.Location == FigureLocation.Right)
                {
                    if (f.Position.J == 18 || desk[f.Position.I, f.Position.J + 2].Flag || desk[f.Position.I + 1, f.Position.J + 2].Flag || desk[f.Position.I + 2, f.Position.J + 1].Flag)
                        con = false;
                    else con = true;
                    if (con)
                    {
                        desk[f.Position.I + 1, f.Position.J] = Square.Empty; desk[f.Position.I + 2, f.Position.J] = Square.Empty; desk[f.Position.I, f.Position.J + 1] = Square.Empty;
                    }
                }
            }

            if (f is Figure4)
            {
                if (f.Location == FigureLocation.Up || f.Location == FigureLocation.Down)
                {
                    if (f.Position.J == 17 || desk[f.Position.I, f.Position.J + 3].Flag || desk[f.Position.I + 1, f.Position.J + 2].Flag)
                        con = false;
                    else con = true;
                    if (con)
                    {
                        desk[f.Position.I + 1, f.Position.J] = Square.Empty; desk[f.Position.I, f.Position.J + 1] = Square.Empty;
                    }
                }
                if (f.Location == FigureLocation.Left || f.Location == FigureLocation.Right)
                {
                    if (f.Position.J == 18 || desk[f.Position.I, f.Position.J + 1].Flag || desk[f.Position.I + 1, f.Position.J + 2].Flag || desk[f.Position.I + 2, f.Position.J + 2].Flag)
                        con = false;
                    else con = true;
                    if (con)
                    {
                        desk[f.Position.I, f.Position.J] = Square.Empty; desk[f.Position.I + 1, f.Position.J] = Square.Empty; desk[f.Position.I + 2, f.Position.J + 1] = Square.Empty;
                    }
                }
            }
            if (f is Figure5)
            {
                if (f.Location == FigureLocation.Up)
                {
                    if (f.Position.J == 17 || desk[f.Position.I, f.Position.J + 3].Flag || desk[f.Position.I + 1, f.Position.J + 3].Flag)
                        con = false;
                    else con = true;
                    if (con)
                    {
                        desk[f.Position.I, f.Position.J] = Square.Empty; desk[f.Position.I + 1, f.Position.J + 2] = Square.Empty;
                    }
                }
                if (f.Location == FigureLocation.Right)
                {
                    if (f.Position.J == 18 || desk[f.Position.I, f.Position.J + 2].Flag || desk[f.Position.I + 1, f.Position.J + 1].Flag || desk[f.Position.I + 2, f.Position.J + 1].Flag)
                        con = false;
                    else con = true;
                    if (con)
                    {
                        desk[f.Position.I, f.Position.J] = Square.Empty; desk[f.Position.I + 1, f.Position.J] = Square.Empty; desk[f.Position.I + 2, f.Position.J] = Square.Empty;
                    }
                }
                if (f.Location == FigureLocation.Down)
                {
                    if (f.Position.J == 17 || desk[f.Position.I, f.Position.J + 1].Flag || desk[f.Position.I + 1, f.Position.J + 3].Flag)
                        con = false;
                    else con = true;
                    if (con)
                    {
                        desk[f.Position.I, f.Position.J] = Square.Empty; desk[f.Position.I + 1, f.Position.J] = Square.Empty;
                    }
                }
                if (f.Location == FigureLocation.Left)
                {
                    if (f.Position.J == 18 || desk[f.Position.I, f.Position.J + 2].Flag || desk[f.Position.I + 1, f.Position.J + 2].Flag || desk[f.Position.I + 2, f.Position.J + 2].Flag)
                        con = false;
                    else con = true;
                    if (con)
                    {
                        desk[f.Position.I, f.Position.J + 1] = Square.Empty; desk[f.Position.I + 1, f.Position.J + 1] = Square.Empty; desk[f.Position.I + 2, f.Position.J] = Square.Empty;
                    }
                }
            }
            if (f is Figure6)
            {
                if (f.Location == FigureLocation.Up)
                {
                    if (f.Position.J == 17 || desk[f.Position.I, f.Position.J + 3].Flag || desk[f.Position.I + 1, f.Position.J + 3].Flag)
                        con = false;
                    else con = true;
                    if (con)
                    {
                        desk[f.Position.I, f.Position.J + 2] = Square.Empty; desk[f.Position.I + 1, f.Position.J] = Square.Empty;
                    }
                }
                if (f.Location == FigureLocation.Right)
                {
                    if (f.Position.J == 18 || desk[f.Position.I, f.Position.J + 2].Flag || desk[f.Position.I + 1, f.Position.J + 2].Flag || desk[f.Position.I + 2, f.Position.J + 2].Flag)
                        con = false;
                    else con = true;
                    if (con)
                    {
                        desk[f.Position.I, f.Position.J] = Square.Empty; desk[f.Position.I + 1, f.Position.J + 1] = Square.Empty; desk[f.Position.I + 2, f.Position.J + 1] = Square.Empty;
                    }
                }
                if (f.Location == FigureLocation.Down)
                {
                    if (f.Position.J == 17 || desk[f.Position.I, f.Position.J + 3].Flag || desk[f.Position.I + 1, f.Position.J + 1].Flag)
                        con = false;
                    else con = true;
                    if (con)
                    {
                        desk[f.Position.I, f.Position.J] = Square.Empty; desk[f.Position.I + 1, f.Position.J] = Square.Empty;
                    }
                }
                if (f.Location == FigureLocation.Left)
                {
                    if (f.Position.J == 18 || desk[f.Position.I, f.Position.J + 1].Flag || desk[f.Position.I + 1, f.Position.J + 1].Flag || desk[f.Position.I + 2, f.Position.J + 2].Flag)
                        con = false;
                    else con = true;
                    if (con)
                    {
                        desk[f.Position.I, f.Position.J] = Square.Empty; desk[f.Position.I + 1, f.Position.J] = Square.Empty; desk[f.Position.I + 2, f.Position.J] = Square.Empty;
                    }
                }
            }
            if (f is Figure7)
            {
                if (f.Location == FigureLocation.Up)
                {
                    if (f.Position.J == 17 || desk[f.Position.I, f.Position.J + 3].Flag || desk[f.Position.I + 1, f.Position.J + 2].Flag)
                        con = false;
                    else con = true;
                    if (con)
                    {
                        desk[f.Position.I, f.Position.J] = Square.Empty; desk[f.Position.I + 1, f.Position.J + 1] = Square.Empty;
                    }
                }
                if (f.Location == FigureLocation.Right)
                {
                    if (f.Position.J == 18 || desk[f.Position.I, f.Position.J + 1].Flag || desk[f.Position.I + 1, f.Position.J + 2].Flag || desk[f.Position.I + 2, f.Position.J + 1].Flag)
                        con = false;
                    else con = true;
                    if (con)
                    {
                        desk[f.Position.I, f.Position.J] = Square.Empty; desk[f.Position.I + 1, f.Position.J] = Square.Empty; desk[f.Position.I + 2, f.Position.J] = Square.Empty;
                    }
                }
                if (f.Location == FigureLocation.Down)
                {
                    if (f.Position.J == 17 || desk[f.Position.I, f.Position.J + 2].Flag || desk[f.Position.I + 1, f.Position.J + 3].Flag)
                        con = false;
                    else con = true;
                    if (con)
                    {
                        desk[f.Position.I + 1, f.Position.J] = Square.Empty; desk[f.Position.I, f.Position.J + 1] = Square.Empty;
                    }
                }
                if (f.Location == FigureLocation.Left)
                {
                    if (f.Position.J == 18 || desk[f.Position.I, f.Position.J + 2].Flag || desk[f.Position.I + 1, f.Position.J + 2].Flag || desk[f.Position.I + 2, f.Position.J + 2].Flag)
                        con = false;
                    else con = true;
                    if (con)
                    {
                        desk[f.Position.I, f.Position.J + 1] = Square.Empty; desk[f.Position.I + 1, f.Position.J] = Square.Empty; desk[f.Position.I + 2, f.Position.J + 1] = Square.Empty;
                    }
                }
            }

            if (con)
            {
                f.PositionJ++;
            }

            return con;
        }

        bool MoveDown(int e)
        {
            {
                bool con = false;

                if (f is Figure1)
                {
                    if (f.Location == FigureLocation.Up || f.Location == FigureLocation.Down)
                    {
                        if (f.Position.J == 16 || desk[f.Position.I, f.Position.J + 4].Flag)
                            con = false;
                        else con = true;
                    }
                    if (f.Location == FigureLocation.Left || f.Location == FigureLocation.Right)
                    {
                        if (f.Position.J == 19 || desk[f.Position.I, f.Position.J + 1].Flag || desk[f.Position.I + 1, f.Position.J + 1].Flag || desk[f.Position.I + 2, f.Position.J + 1].Flag || desk[f.Position.I + 3, f.Position.J + 1].Flag)
                            con = false;
                        else con = true;
                    }
                }
                if (f is Figure2)
                {
                    if (f.Position.J == 18 || desk[f.Position.I, f.Position.J + 2].Flag || desk[f.Position.I + 1, f.Position.J + 2].Flag)
                        con = false;
                    else con = true;
                }

                if (f is Figure3)
                {
                    if (f.Location == FigureLocation.Up || f.Location == FigureLocation.Down)
                    {
                        if (f.Position.J == 17 || desk[f.Position.I, f.Position.J + 2].Flag || desk[f.Position.I + 1, f.Position.J + 3].Flag)
                            con = false;
                        else con = true;
                    }
                    if (f.Location == FigureLocation.Left || f.Location == FigureLocation.Right)
                    {
                        if (f.Position.J == 18 || desk[f.Position.I, f.Position.J + 2].Flag || desk[f.Position.I + 1, f.Position.J + 2].Flag || desk[f.Position.I + 2, f.Position.J + 1].Flag)
                            con = false;
                        else con = true;
                    }
                }
                if (f is Figure4)
                {
                    if (f.Location == FigureLocation.Up || f.Location == FigureLocation.Down)
                    {
                        if (f.Position.J == 17 || desk[f.Position.I, f.Position.J + 3].Flag || desk[f.Position.I + 1, f.Position.J + 2].Flag)
                            con = false;
                        else con = true;
                    }
                    if (f.Location == FigureLocation.Left || f.Location == FigureLocation.Right)
                    {
                        if (f.Position.J == 18 || desk[f.Position.I, f.Position.J + 1].Flag || desk[f.Position.I + 1, f.Position.J + 2].Flag || desk[f.Position.I + 2, f.Position.J + 2].Flag)
                            con = false;
                        else con = true;
                    }
                }
                if (f is Figure5)
                {
                    if (f.Location == FigureLocation.Up)
                    {
                        if (f.Position.J == 17 || desk[f.Position.I, f.Position.J + 3].Flag || desk[f.Position.I + 1, f.Position.J + 3].Flag)
                            con = false;
                        else con = true;
                    }
                    if (f.Location == FigureLocation.Right)
                    {
                        if (f.Position.J == 18 || desk[f.Position.I, f.Position.J + 2].Flag || desk[f.Position.I + 1, f.Position.J + 1].Flag || desk[f.Position.I + 2, f.Position.J + 1].Flag)
                            con = false;
                        else con = true;
                    }
                    if (f.Location == FigureLocation.Down)
                    {
                        if (f.Position.J == 17 || desk[f.Position.I, f.Position.J + 1].Flag || desk[f.Position.I + 1, f.Position.J + 3].Flag)
                            con = false;
                        else con = true;
                    }
                    if (f.Location == FigureLocation.Left)
                    {
                        if (f.Position.J == 18 || desk[f.Position.I, f.Position.J + 2].Flag || desk[f.Position.I + 1, f.Position.J + 2].Flag || desk[f.Position.I + 2, f.Position.J + 2].Flag)
                            con = false;
                        else con = true;
                    }
                }
                if (f is Figure6)
                {
                    if (f.Location == FigureLocation.Up)
                    {
                        if (f.Position.J == 17 || desk[f.Position.I, f.Position.J + 3].Flag || desk[f.Position.I + 1, f.Position.J + 3].Flag)
                            con = false;
                        else con = true;
                    }
                    if (f.Location == FigureLocation.Right)
                    {
                        if (f.Position.J == 18 || desk[f.Position.I, f.Position.J + 2].Flag || desk[f.Position.I + 1, f.Position.J + 2].Flag || desk[f.Position.I + 2, f.Position.J + 2].Flag)
                            con = false;
                        else con = true;
                    }
                    if (f.Location == FigureLocation.Down)
                    {
                        if (f.Position.J == 17 || desk[f.Position.I, f.Position.J + 3].Flag || desk[f.Position.I + 1, f.Position.J + 1].Flag)
                            con = false;
                        else con = true;
                    }
                    if (f.Location == FigureLocation.Left)
                    {
                        if (f.Position.J == 18 || desk[f.Position.I, f.Position.J + 1].Flag || desk[f.Position.I + 1, f.Position.J + 1].Flag || desk[f.Position.I + 2, f.Position.J + 2].Flag)
                            con = false;
                        else con = true;
                    }
                }
                if (f is Figure7)
                {
                    if (f.Location == FigureLocation.Up)
                    {
                        if (f.Position.J == 17 || desk[f.Position.I, f.Position.J + 3].Flag || desk[f.Position.I + 1, f.Position.J + 2].Flag)
                            con = false;
                        else con = true;
                    }
                    if (f.Location == FigureLocation.Right)
                    {
                        if (f.Position.J == 18 || desk[f.Position.I, f.Position.J + 1].Flag || desk[f.Position.I + 1, f.Position.J + 2].Flag || desk[f.Position.I + 2, f.Position.J + 1].Flag)
                            con = false;
                        else con = true;
                    }
                    if (f.Location == FigureLocation.Down)
                    {
                        if (f.Position.J == 17 || desk[f.Position.I, f.Position.J + 2].Flag || desk[f.Position.I + 1, f.Position.J + 3].Flag)
                            con = false;
                        else con = true;
                    }
                    if (f.Location == FigureLocation.Left)
                    {
                        if (f.Position.J == 18 || desk[f.Position.I, f.Position.J + 2].Flag || desk[f.Position.I + 1, f.Position.J + 2].Flag || desk[f.Position.I + 2, f.Position.J + 2].Flag)
                            con = false;
                        else con = true;
                    }
                }
                return con;
            }
        }

        void Turn()
        {
            bool con = false;

            if (f is Figure1)
            {
                if (f.Location == FigureLocation.Up || f.Location == FigureLocation.Down)
                {
                    if (f.Position.I > 6 || desk[f.Position.I + 1, f.Position.J].Flag || desk[f.Position.I + 2, f.Position.J].Flag || desk[f.Position.I + 3, f.Position.J].Flag)
                        con = false;
                    else con = true;
                    if (con)
                    {
                        desk[f.Position.I, f.Position.J + 1] = Square.Empty; desk[f.Position.I, f.Position.J + 2] = Square.Empty; desk[f.Position.I, f.Position.J + 3] = Square.Empty;
                    }
                }
                if (f.Location == FigureLocation.Left || f.Location == FigureLocation.Right)
                {
                    if (f.Position.J > 16 || desk[f.Position.I, f.Position.J + 1].Flag || desk[f.Position.I, f.Position.J + 2].Flag || desk[f.Position.I, f.Position.J + 3].Flag)
                        con = false;
                    else con = true;
                    if (con)
                    {
                        desk[f.Position.I + 1, f.Position.J] = Square.Empty; desk[f.Position.I + 2, f.Position.J] = Square.Empty; desk[f.Position.I + 3, f.Position.J] = Square.Empty;
                    }
                }
            }
            if (f is Figure2)
            {
                con = true;
            }
            if (f is Figure3)
            {
                if (f.Location == FigureLocation.Up || f.Location == FigureLocation.Down)
                {
                    if (f.Position.I > 7 || desk[f.Position.I + 1, f.Position.J].Flag || desk[f.Position.I + 2, f.Position.J].Flag)
                        con = false;
                    else con = true;
                    if (con)
                    {
                        desk[f.Position.I, f.Position.J] = Square.Empty; desk[f.Position.I + 1, f.Position.J + 2] = Square.Empty;
                    }
                }
                if (f.Location == FigureLocation.Left || f.Location == FigureLocation.Right)
                {
                    if (f.Position.J > 17 || desk[f.Position.I, f.Position.J].Flag || desk[f.Position.I + 1, f.Position.J + 2].Flag)
                        con = false;
                    else con = true;
                    if (con)
                    {
                        desk[f.Position.I + 1, f.Position.J] = Square.Empty; desk[f.Position.I + 2, f.Position.J] = Square.Empty;
                    }
                }
            }
            if (f is Figure4)
            {
                if (f.Location == FigureLocation.Up || f.Location == FigureLocation.Down)
                {
                    if (f.Position.I > 7 || desk[f.Position.I, f.Position.J].Flag || desk[f.Position.I + 2, f.Position.J + 1].Flag)
                        con = false;
                    else con = true;
                    if (con)
                    {
                        desk[f.Position.I, f.Position.J + 1] = Square.Empty; desk[f.Position.I, f.Position.J + 2] = Square.Empty;
                    }
                }
                if (f.Location == FigureLocation.Left || f.Location == FigureLocation.Right)
                {
                    if (f.Position.J > 17 || desk[f.Position.I, f.Position.J + 1].Flag || desk[f.Position.I, f.Position.J + 2].Flag)
                        con = false;
                    else con = true;
                    if (con)
                    {
                        desk[f.Position.I, f.Position.J] = Square.Empty; desk[f.Position.I + 2, f.Position.J + 1] = Square.Empty;
                    }
                }
            }
            if (f is Figure5)
            {
                if (f.Location == FigureLocation.Up)
                {
                    if (f.Position.I > 7 || desk[f.Position.I + 1, f.Position.J].Flag || desk[f.Position.I + 2, f.Position.J].Flag)
                        con = false;
                    else con = true;
                    if (con)
                    {
                        desk[f.Position.I, f.Position.J + 1] = Square.Empty; desk[f.Position.I, f.Position.J + 2] = Square.Empty; desk[f.Position.I + 1, f.Position.J + 2] = Square.Empty;
                    }
                }
                if (f.Location == FigureLocation.Right)
                {
                    if (f.Position.J > 17 || desk[f.Position.I + 1, f.Position.J + 1].Flag || desk[f.Position.I + 1, f.Position.J + 2].Flag)
                        con = false;
                    else con = true;
                    if (con)
                    {
                        desk[f.Position.I, f.Position.J + 1] = Square.Empty; desk[f.Position.I + 2, f.Position.J] = Square.Empty;
                    }
                }
                if (f.Location == FigureLocation.Down)
                {
                    if (f.Position.I > 7 || desk[f.Position.I, f.Position.J + 1].Flag || desk[f.Position.I + 2, f.Position.J].Flag || desk[f.Position.I + 2, f.Position.J + 1].Flag)
                        con = false;
                    else con = true;
                    if (con)
                    {
                        desk[f.Position.I, f.Position.J] = Square.Empty; desk[f.Position.I + 1, f.Position.J] = Square.Empty; desk[f.Position.I + 1, f.Position.J + 2] = Square.Empty;
                    }
                }
                if (f.Location == FigureLocation.Left)
                {
                    if (f.Position.J > 17 || desk[f.Position.I, f.Position.J].Flag || desk[f.Position.I, f.Position.J + 2].Flag || desk[f.Position.I + 1, f.Position.J + 2].Flag)
                        con = false;
                    else con = true;
                    if (con)
                    {
                        desk[f.Position.I + 1, f.Position.J + 1] = Square.Empty; desk[f.Position.I + 2, f.Position.J] = Square.Empty; desk[f.Position.I + 2, f.Position.J + 1] = Square.Empty;
                    }
                }
            }
            if (f is Figure6)
            {
                if (f.Location == FigureLocation.Up)
                {
                    if (f.Position.I > 7 || desk[f.Position.I, f.Position.J].Flag || desk[f.Position.I, f.Position.J + 1].Flag || desk[f.Position.I + 2, f.Position.J + 1].Flag)
                        con = false;
                    else con = true;
                    if (con)
                    {
                        desk[f.Position.I + 1, f.Position.J] = Square.Empty; desk[f.Position.I, f.Position.J + 2] = Square.Empty; desk[f.Position.I + 1, f.Position.J + 2] = Square.Empty;
                    }
                }
                if (f.Location == FigureLocation.Right)
                {
                    if (f.Position.J > 17 || desk[f.Position.I + 1, f.Position.J].Flag || desk[f.Position.I, f.Position.J + 2].Flag)
                        con = false;
                    else con = true;
                    if (con)
                    {
                        desk[f.Position.I + 1, f.Position.J + 1] = Square.Empty; desk[f.Position.I + 2, f.Position.J + 1] = Square.Empty;
                    }
                }
                if (f.Location == FigureLocation.Down)
                {
                    if (f.Position.I > 7 || desk[f.Position.I + 2, f.Position.J].Flag || desk[f.Position.I + 2, f.Position.J + 1].Flag)
                        con = false;
                    else con = true;
                    if (con)
                    {
                        desk[f.Position.I, f.Position.J + 1] = Square.Empty; desk[f.Position.I, f.Position.J + 2] = Square.Empty;
                    }
                }
                if (f.Location == FigureLocation.Left)
                {
                    if (f.Position.J > 17 || desk[f.Position.I + 1, f.Position.J + 1].Flag || desk[f.Position.I, f.Position.J + 2].Flag || desk[f.Position.I + 1, f.Position.J + 2].Flag)
                        con = false;
                    else con = true;
                    if (con)
                    {
                        desk[f.Position.I, f.Position.J] = Square.Empty; desk[f.Position.I + 2, f.Position.J] = Square.Empty; desk[f.Position.I + 2, f.Position.J + 1] = Square.Empty;
                    }
                }
            }
            if (f is Figure7)
            {
                if (f.Location == FigureLocation.Up)
                {
                    if (f.Position.I > 7 || desk[f.Position.I + 1, f.Position.J].Flag || desk[f.Position.I + 2, f.Position.J].Flag)
                        con = false;
                    else con = true;
                    if (con)
                    {
                        desk[f.Position.I, f.Position.J + 1] = Square.Empty; desk[f.Position.I, f.Position.J + 2] = Square.Empty;
                    }
                }
                if (f.Location == FigureLocation.Right)
                {
                    if (f.Position.J > 17 || desk[f.Position.I, f.Position.J + 1].Flag || desk[f.Position.I + 1, f.Position.J + 2].Flag)
                        con = false;
                    else con = true;
                    if (con)
                    {
                        desk[f.Position.I, f.Position.J] = Square.Empty; desk[f.Position.I + 2, f.Position.J] = Square.Empty;
                    }
                }
                if (f.Location == FigureLocation.Down)
                {
                    if (f.Position.I > 7 || desk[f.Position.I + 2, f.Position.J + 1].Flag)
                        con = false;
                    else con = true;
                    if (con)
                    {
                        desk[f.Position.I + 1, f.Position.J + 2] = Square.Empty;
                    }
                }
                if (f.Location == FigureLocation.Left)
                {
                    if (f.Position.J > 17 || desk[f.Position.I, f.Position.J].Flag || desk[f.Position.I, f.Position.J + 2].Flag)
                        con = false;
                    else con = true;
                    if (con)
                    {
                        desk[f.Position.I + 1, f.Position.J] = Square.Empty; desk[f.Position.I + 2, f.Position.J + 1] = Square.Empty;
                    }
                }
            }
            if (con)
                f = f.NextLocation();
        }

        void MoveLeft()
        {
            bool con = false;

            if (f is Figure1)
            {
                if (f.Location == FigureLocation.Up || f.Location == FigureLocation.Down)
                {
                    if (f.Position.I < 1 || desk[f.Position.I - 1, f.Position.J].Flag || desk[f.Position.I - 1, f.Position.J + 1].Flag || desk[f.Position.I - 1, f.Position.J + 2].Flag || desk[f.Position.I - 1, f.Position.J + 3].Flag)
                        con = false;
                    else con = true;
                    if (con)
                    {
                        desk[f.Position.I, f.Position.J] = Square.Empty; desk[f.Position.I, f.Position.J + 1] = Square.Empty; desk[f.Position.I, f.Position.J + 2] = Square.Empty; desk[f.Position.I, f.Position.J + 3] = Square.Empty;
                    }
                }
                if (f.Location == FigureLocation.Right || f.Location == FigureLocation.Left)
                {
                    if (f.Position.I < 1 || desk[f.Position.I - 1, f.Position.J].Flag)
                        con = false;
                    else con = true;
                    if (con)
                    {
                        desk[f.Position.I + 3, f.Position.J] = Square.Empty;
                    }
                }
            }
            if (f is Figure2)
            {
                if (f.Position.I < 1 || desk[f.Position.I - 1, f.Position.J].Flag || desk[f.Position.I - 1, f.Position.J + 1].Flag)
                    con = false;
                else con = true;
                if (con)
                {
                    desk[f.Position.I + 1, f.Position.J] = Square.Empty; desk[f.Position.I + 1, f.Position.J + 1] = Square.Empty;
                }
            }
            if (f is Figure3)
            {
                if (f.Location == FigureLocation.Up || f.Location == FigureLocation.Down)
                {
                    if (f.Position.I < 1 || desk[f.Position.I - 1, f.Position.J].Flag || desk[f.Position.I - 1, f.Position.J + 1].Flag || desk[f.Position.I, f.Position.J + 2].Flag)
                        con = false;
                    else con = true;
                    if (con)
                    {
                        desk[f.Position.I, f.Position.J] = Square.Empty; desk[f.Position.I + 1, f.Position.J + 1] = Square.Empty; desk[f.Position.I + 1, f.Position.J + 2] = Square.Empty;
                    }
                }
                if (f.Location == FigureLocation.Left || f.Location == FigureLocation.Right)
                {
                    if (f.Position.I < 1 || desk[f.Position.I, f.Position.J].Flag || desk[f.Position.I - 1, f.Position.J + 1].Flag)
                        con = false;
                    else con = true;
                    if (con)
                    {
                        desk[f.Position.I + 2, f.Position.J] = Square.Empty; desk[f.Position.I + 1, f.Position.J + 1] = Square.Empty;
                    }
                }
            }
            if (f is Figure4)
            {
                if (f.Location == FigureLocation.Up || f.Location == FigureLocation.Down)
                {
                    if (f.Position.I < 1 || desk[f.Position.I - 1, f.Position.J + 1].Flag || desk[f.Position.I - 1, f.Position.J + 2].Flag || desk[f.Position.I, f.Position.J].Flag)
                        con = false;
                    else con = true;
                    if (con)
                    {
                        desk[f.Position.I + 1, f.Position.J] = Square.Empty; desk[f.Position.I + 1, f.Position.J + 1] = Square.Empty; desk[f.Position.I, f.Position.J + 2] = Square.Empty;
                    }
                }
                if (f.Location == FigureLocation.Left || f.Location == FigureLocation.Right)
                {
                    if (f.Position.I < 1 || desk[f.Position.I - 1, f.Position.J].Flag || desk[f.Position.I, f.Position.J + 1].Flag)
                        con = false;
                    else con = true;
                    if (con)
                    {
                        desk[f.Position.I + 1, f.Position.J] = Square.Empty; desk[f.Position.I + 2, f.Position.J + 1] = Square.Empty;
                    }
                }
            }
            if (f is Figure5)
            {
                if (f.Location == FigureLocation.Up)
                {
                    if (f.Position.I < 1 || desk[f.Position.I - 1, f.Position.J].Flag || desk[f.Position.I - 1, f.Position.J + 1].Flag || desk[f.Position.I - 1, f.Position.J + 2].Flag)
                        con = false;
                    else con = true;
                    if (con)
                    {
                        desk[f.Position.I, f.Position.J] = Square.Empty; desk[f.Position.I, f.Position.J + 1] = Square.Empty; desk[f.Position.I + 1, f.Position.J + 2] = Square.Empty;
                    }
                }
                if (f.Location == FigureLocation.Right)
                {
                    if (f.Position.I < 1 || desk[f.Position.I - 1, f.Position.J].Flag || desk[f.Position.I - 1, f.Position.J + 1].Flag)
                        con = false;
                    else con = true;
                    if (con)
                    {
                        desk[f.Position.I + 2, f.Position.J] = Square.Empty; desk[f.Position.I, f.Position.J + 1] = Square.Empty;
                    }
                }
                if (f.Location == FigureLocation.Down)
                {
                    if (f.Position.I < 1 || desk[f.Position.I - 1, f.Position.J].Flag || desk[f.Position.I, f.Position.J + 1].Flag || desk[f.Position.I, f.Position.J + 2].Flag)
                        con = false;
                    else con = true;
                    if (con)
                    {
                        desk[f.Position.I + 1, f.Position.J] = Square.Empty; desk[f.Position.I + 1, f.Position.J + 1] = Square.Empty; desk[f.Position.I + 1, f.Position.J + 2] = Square.Empty;
                    }
                }
                if (f.Location == FigureLocation.Left)
                {
                    if (f.Position.I < 1 || desk[f.Position.I - 1, f.Position.J + 1].Flag || desk[f.Position.I + 1, f.Position.J].Flag)
                        con = false;
                    else con = true;
                    if (con)
                    {
                        desk[f.Position.I + 2, f.Position.J] = Square.Empty; desk[f.Position.I + 2, f.Position.J + 1] = Square.Empty;
                    }
                }
            }
            if (f is Figure6)
            {
                if (f.Location == FigureLocation.Up)
                {
                    if (f.Position.I < 1 || desk[f.Position.I - 1, f.Position.J + 2].Flag || desk[f.Position.I, f.Position.J].Flag || desk[f.Position.I, f.Position.J + 1].Flag)
                        con = false;
                    else con = true;
                    if (con)
                    {
                        desk[f.Position.I + 1, f.Position.J] = Square.Empty; desk[f.Position.I + 1, f.Position.J + 1] = Square.Empty; desk[f.Position.I + 1, f.Position.J + 2] = Square.Empty;
                    }
                }
                if (f.Location == FigureLocation.Right)
                {
                    if (f.Position.I < 1 || desk[f.Position.I - 1, f.Position.J].Flag || desk[f.Position.I - 1, f.Position.J + 1].Flag)
                        con = false;
                    else con = true;
                    if (con)
                    {
                        desk[f.Position.I, f.Position.J] = Square.Empty; desk[f.Position.I + 2, f.Position.J + 1] = Square.Empty;
                    }
                }
                if (f.Location == FigureLocation.Down)
                {
                    if (f.Position.I < 1 || desk[f.Position.I - 1, f.Position.J].Flag || desk[f.Position.I - 1, f.Position.J + 1].Flag || desk[f.Position.I - 1, f.Position.J + 2].Flag)
                        con = false;
                    else con = true;
                    if (con)
                    {
                        desk[f.Position.I + 1, f.Position.J] = Square.Empty; desk[f.Position.I, f.Position.J + 1] = Square.Empty; desk[f.Position.I, f.Position.J + 2] = Square.Empty;
                    }
                }
                if (f.Location == FigureLocation.Left)
                {
                    if (f.Position.I < 1 || desk[f.Position.I - 1, f.Position.J].Flag || desk[f.Position.I + 1, f.Position.J + 1].Flag)
                        con = false;
                    else con = true;
                    if (con)
                    {
                        desk[f.Position.I + 2, f.Position.J] = Square.Empty; desk[f.Position.I + 2, f.Position.J + 1] = Square.Empty;
                    }
                }
            }
            if (f is Figure7)
            {
                if (f.Location == FigureLocation.Up)
                {
                    if (f.Position.I < 1 || desk[f.Position.I - 1, f.Position.J].Flag || desk[f.Position.I - 1, f.Position.J + 1].Flag || desk[f.Position.I - 1, f.Position.J + 2].Flag)
                        con = false;
                    else con = true;
                    if (con)
                    {
                        desk[f.Position.I, f.Position.J] = Square.Empty; desk[f.Position.I + 1, f.Position.J + 1] = Square.Empty; desk[f.Position.I, f.Position.J + 2] = Square.Empty;
                    }
                }
                if (f.Location == FigureLocation.Right)
                {
                    if (f.Position.I < 1 || desk[f.Position.I - 1, f.Position.J].Flag || desk[f.Position.I, f.Position.J + 1].Flag)
                        con = false;
                    else con = true;
                    if (con)
                    {
                        desk[f.Position.I + 2, f.Position.J] = Square.Empty; desk[f.Position.I + 1, f.Position.J + 1] = Square.Empty;
                    }
                }
                if (f.Location == FigureLocation.Down)
                {
                    if (f.Position.I < 1 || desk[f.Position.I, f.Position.J].Flag || desk[f.Position.I - 1, f.Position.J + 1].Flag || desk[f.Position.I, f.Position.J + 2].Flag)
                        con = false;
                    else con = true;
                    if (con)
                    {
                        desk[f.Position.I + 1, f.Position.J] = Square.Empty; desk[f.Position.I + 1, f.Position.J + 1] = Square.Empty; desk[f.Position.I + 1, f.Position.J + 2] = Square.Empty;
                    }
                }
                if (f.Location == FigureLocation.Left)
                {
                    if (f.Position.I < 1 || desk[f.Position.I, f.Position.J].Flag || desk[f.Position.I - 1, f.Position.J + 1].Flag)
                        con = false;
                    else con = true;
                    if (con)
                    {
                        desk[f.Position.I + 1, f.Position.J] = Square.Empty; desk[f.Position.I + 2, f.Position.J + 1] = Square.Empty;
                    }
                }
            }
            if (con)
                f.PositionI--;
        }

        void MoveRight()
        {
            bool con = false;

            if (f is Figure1)
            {
                if (f.Location == FigureLocation.Up || f.Location == FigureLocation.Down)
                {
                    if (f.Position.I > 8 || desk[f.Position.I + 1, f.Position.J].Flag || desk[f.Position.I + 1, f.Position.J + 1].Flag || desk[f.Position.I + 1, f.Position.J + 2].Flag || desk[f.Position.I + 1, f.Position.J + 3].Flag)
                        con = false;
                    else con = true;
                    if (con)
                    {
                        desk[f.Position.I, f.Position.J] = Square.Empty; desk[f.Position.I, f.Position.J + 1] = Square.Empty; desk[f.Position.I, f.Position.J + 2] = Square.Empty; desk[f.Position.I, f.Position.J + 3] = Square.Empty;
                    }
                }
                if (f.Location == FigureLocation.Right || f.Location == FigureLocation.Left)
                {
                    if (f.Position.I > 5 || desk[f.Position.I + 4, f.Position.J].Flag)
                        con = false;
                    else con = true;
                    if (con)
                    {
                        desk[f.Position.I, f.Position.J] = Square.Empty;
                    }
                }
            }
            if (f is Figure2)
            {
                if (f.Position.I > 7 || desk[f.Position.I + 2, f.Position.J].Flag || desk[f.Position.I + 2, f.Position.J + 1].Flag)
                    con = false;
                else con = true;
                if (con)
                {
                    desk[f.Position.I, f.Position.J] = Square.Empty; desk[f.Position.I, f.Position.J + 1] = Square.Empty;
                }
            }
            if (f is Figure3)
            {
                if (f.Location == FigureLocation.Up || f.Location == FigureLocation.Down)
                {
                    if (f.Position.I > 7 || desk[f.Position.I + 1, f.Position.J].Flag || desk[f.Position.I + 2, f.Position.J + 1].Flag || desk[f.Position.I + 2, f.Position.J + 2].Flag)
                        con = false;
                    else con = true;
                    if (con)
                    {
                        desk[f.Position.I, f.Position.J] = Square.Empty; desk[f.Position.I, f.Position.J + 1] = Square.Empty; desk[f.Position.I + 1, f.Position.J + 2] = Square.Empty;
                    }
                }
                if (f.Location == FigureLocation.Right || f.Location == FigureLocation.Left)
                {
                    if (f.Position.I > 6 || desk[f.Position.I + 3, f.Position.J].Flag || desk[f.Position.I + 2, f.Position.J + 1].Flag)
                        con = false;
                    else con = true;
                    if (con)
                    {
                        desk[f.Position.I + 1, f.Position.J] = Square.Empty; desk[f.Position.I, f.Position.J + 1] = Square.Empty;
                    }
                }
            }
            if (f is Figure4)
            {
                if (f.Location == FigureLocation.Up || f.Location == FigureLocation.Down)
                {
                    if (f.Position.I > 7 || desk[f.Position.I + 2, f.Position.J].Flag || desk[f.Position.I + 2, f.Position.J + 1].Flag || desk[f.Position.I + 1, f.Position.J + 2].Flag)
                        con = false;
                    else con = true;
                    if (con)
                    {
                        desk[f.Position.I + 1, f.Position.J] = Square.Empty; desk[f.Position.I, f.Position.J + 1] = Square.Empty; desk[f.Position.I, f.Position.J + 2] = Square.Empty;
                    }
                }
                if (f.Location == FigureLocation.Right || f.Location == FigureLocation.Left)
                {
                    if (f.Position.I > 6 || desk[f.Position.I + 2, f.Position.J].Flag || desk[f.Position.I + 3, f.Position.J + 1].Flag)
                        con = false;
                    else con = true;
                    if (con)
                    {
                        desk[f.Position.I, f.Position.J] = Square.Empty; desk[f.Position.I + 1, f.Position.J + 1] = Square.Empty;
                    }
                }
            }
            if (f is Figure5)
            {
                if (f.Location == FigureLocation.Up)
                {
                    if (f.Position.I > 7 || desk[f.Position.I + 1, f.Position.J].Flag || desk[f.Position.I + 1, f.Position.J + 1].Flag || desk[f.Position.I + 2, f.Position.J + 2].Flag)
                        con = false;
                    else con = true;
                    if (con)
                    {
                        desk[f.Position.I, f.Position.J] = Square.Empty; desk[f.Position.I, f.Position.J + 1] = Square.Empty; desk[f.Position.I, f.Position.J + 2] = Square.Empty;
                    }
                }
                if (f.Location == FigureLocation.Right)
                {
                    if (f.Position.I > 6 || desk[f.Position.I + 3, f.Position.J].Flag || desk[f.Position.I + 1, f.Position.J + 1].Flag)
                        con = false;
                    else con = true;
                    if (con)
                    {
                        desk[f.Position.I, f.Position.J] = Square.Empty; desk[f.Position.I, f.Position.J + 1] = Square.Empty;
                    }
                }
                if (f.Location == FigureLocation.Down)
                {
                    if (f.Position.I > 7 || desk[f.Position.I + 2, f.Position.J].Flag || desk[f.Position.I + 2, f.Position.J + 1].Flag || desk[f.Position.I + 2, f.Position.J + 2].Flag)
                        con = false;
                    else con = true;
                    if (con)
                    {
                        desk[f.Position.I, f.Position.J] = Square.Empty; desk[f.Position.I + 1, f.Position.J + 1] = Square.Empty; desk[f.Position.I + 1, f.Position.J + 2] = Square.Empty;
                    }
                }
                if (f.Location == FigureLocation.Left)
                {
                    if (f.Position.I > 6 || desk[f.Position.I + 3, f.Position.J].Flag || desk[f.Position.I + 3, f.Position.J + 1].Flag)
                        con = false;
                    else con = true;
                    if (con)
                    {
                        desk[f.Position.I, f.Position.J + 1] = Square.Empty; desk[f.Position.I + 2, f.Position.J] = Square.Empty;
                    }
                }
            }
            if (f is Figure6)
            {
                if (f.Location == FigureLocation.Up)
                {
                    if (f.Position.I > 7 || desk[f.Position.I + 2, f.Position.J].Flag || desk[f.Position.I + 2, f.Position.J + 1].Flag || desk[f.Position.I + 2, f.Position.J + 2].Flag)
                        con = false;
                    else con = true;
                    if (con)
                    {
                        desk[f.Position.I + 1, f.Position.J] = Square.Empty; desk[f.Position.I + 1, f.Position.J + 1] = Square.Empty; desk[f.Position.I, f.Position.J + 2] = Square.Empty;
                    }
                }
                if (f.Location == FigureLocation.Right)
                {
                    if (f.Position.I > 6 || desk[f.Position.I + 3, f.Position.J + 1].Flag || desk[f.Position.I + 1, f.Position.J].Flag)
                        con = false;
                    else con = true;
                    if (con)
                    {
                        desk[f.Position.I, f.Position.J] = Square.Empty; desk[f.Position.I, f.Position.J + 1] = Square.Empty;
                    }
                }
                if (f.Location == FigureLocation.Down)
                {
                    if (f.Position.I > 7 || desk[f.Position.I + 2, f.Position.J].Flag || desk[f.Position.I + 1, f.Position.J + 1].Flag || desk[f.Position.I + 1, f.Position.J + 2].Flag)
                        con = false;
                    else con = true;
                    if (con)
                    {
                        desk[f.Position.I, f.Position.J] = Square.Empty; desk[f.Position.I, f.Position.J + 1] = Square.Empty; desk[f.Position.I, f.Position.J + 2] = Square.Empty;
                    }
                }
                if (f.Location == FigureLocation.Left)
                {
                    if (f.Position.I > 6 || desk[f.Position.I + 3, f.Position.J].Flag || desk[f.Position.I + 3, f.Position.J + 1].Flag)
                        con = false;
                    else con = true;
                    if (con)
                    {
                        desk[f.Position.I, f.Position.J] = Square.Empty; desk[f.Position.I + 2, f.Position.J + 1] = Square.Empty;
                    }
                }
            }
            if (f is Figure7)
            {
                if (f.Location == FigureLocation.Up)
                {
                    if (f.Position.I > 7 || desk[f.Position.I + 1, f.Position.J].Flag || desk[f.Position.I + 2, f.Position.J + 1].Flag || desk[f.Position.I + 1, f.Position.J + 2].Flag)
                        con = false;
                    else con = true;
                    if (con)
                    {
                        desk[f.Position.I, f.Position.J] = Square.Empty; desk[f.Position.I, f.Position.J + 1] = Square.Empty; desk[f.Position.I, f.Position.J + 2] = Square.Empty;
                    }
                }
                if (f.Location == FigureLocation.Right)
                {
                    if (f.Position.I > 6 || desk[f.Position.I + 3, f.Position.J].Flag || desk[f.Position.I + 2, f.Position.J + 1].Flag)
                        con = false;
                    else con = true;
                    if (con)
                    {
                        desk[f.Position.I, f.Position.J] = Square.Empty; desk[f.Position.I + 1, f.Position.J + 1] = Square.Empty;
                    }
                }
                if (f.Location == FigureLocation.Down)
                {
                    if (f.Position.I > 7 || desk[f.Position.I + 2, f.Position.J].Flag || desk[f.Position.I + 2, f.Position.J + 1].Flag || desk[f.Position.I + 2, f.Position.J + 2].Flag)
                        con = false;
                    else con = true;
                    if (con)
                    {
                        desk[f.Position.I + 1, f.Position.J] = Square.Empty; desk[f.Position.I, f.Position.J + 1] = Square.Empty; desk[f.Position.I + 1, f.Position.J + 2] = Square.Empty;
                    }
                }
                if (f.Location == FigureLocation.Left)
                {
                    if (f.Position.I > 6 || desk[f.Position.I + 2, f.Position.J].Flag || desk[f.Position.I + 3, f.Position.J + 1].Flag)
                        con = false;
                    else con = true;
                    if (con)
                    {
                        desk[f.Position.I + 1, f.Position.J] = Square.Empty; desk[f.Position.I, f.Position.J + 1] = Square.Empty;
                    }
                }
            }
            if (con)
                f.PositionI++;
        }

        void KeyY()
        {
            timer1.Enabled = !timer1.Enabled;
        }

        void KeyEsc()
        {
            timer1.Stop();
        }

        
    }
}