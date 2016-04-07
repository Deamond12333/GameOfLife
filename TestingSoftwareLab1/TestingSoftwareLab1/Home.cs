using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace TestingSoftwareLab1
{
    public partial class Home : Form
    {
        //List<Point> startField = new List<Point>();
        List<Figure> basicFigures = new List<Figure>();
        bool[,] startField;
        bool isStart = false;
        int condition = 0;
        Timer timer = new Timer();
        Graphics g;

        int height, width;
        public Home()
        {
            InitializeComponent();

            g = figurevisible.CreateGraphics();

            XmlDocument xml = new XmlDocument();
            xml.Load("figures.xml");

            foreach (XmlNode node in xml.DocumentElement)
            {
                Figure figure = new Figure();
                figure.name = node.Attributes["Name"].Value;
                figure.image = Image.FromFile(node.Attributes["Image"].Value);

                string points = node.Attributes["Points"].Value;
                string[] pointsArray = points.Split(';');

                List<Point> ps = new List<Point>();

                foreach(string point in pointsArray)
                {
                    string[] xys = point.Split(',');
                    Point p = new Point();
                    p.X = int.Parse(xys[0]);
                    p.Y = int.Parse(xys[1]);
                    ps.Add(p);
                }

                figure.points = ps;
                basicFigures.Add(figure);
            }

            height = field.Height - 1;
            width = field.Width - 1;
            timer.Interval = speed.Value;
            timer.Tick += timer_Tick;

            startField = new bool[width / 10, height / 10];
            for (int i = 0; i < width / 10; i++)
            {
                for (int j = 0; j < height / 10; j++)
                {
                    startField[i, j] = false;
                }
            }

            foreach(Figure f in basicFigures)
            {
                figures.Items.Add(f.name);
            }
            figures.SelectedIndex = 0;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            /*List<Point> buffer = new List<Point>();

            for (int i = 0; i <= width; i += 10)
            {
                for (int j = 0; j <= height; j += 10)
                {
                    Point qurPoint = new Point(i, j);

                    int neighbours = countOfNeighbours(qurPoint);

                    if (neighbours == 2)
                    {
                        for (int k = 0; k < startField.Count; ++k)
                        {
                            if (qurPoint.X == startField[k].X && qurPoint.Y == startField[k].Y)
                            {
                                buffer.Add(qurPoint);
                                break;
                            }
                        }
                    }
                    else if (neighbours == 3) buffer.Add(qurPoint);
                    else continue;
                }
            }

            startField.Clear();

            foreach (Point point in buffer)
            {
                startField.Add(point);
            }*/
            bool[,] buffer = new bool[width / 10, height / 10];

            for (int i = 0; i < width / 10; ++i)
            {
                for (int j = 0; j < height / 10; ++j)
                {
                    buffer[i, j] = false;
                }
            }

            for (int i = 0; i < width/10; ++i)
            {
                for (int j = 0; j < height/10; ++j)
                {
                    switch(countOfNeighbours(i, j))
                    {
                        case 2: buffer[i, j] = startField[i, j]; break;
                        case 3: buffer[i, j] = true; break;
                    }
                }
            }

            startField = buffer;

            field.Refresh();
            timer.Interval = speed.Value;
        }

        private void start_Click(object sender, EventArgs e)
        {
            isStart = !isStart;

            if (isStart)
            {
                clear.Enabled = false;
                start.Text = "Stop life";
                timer.Start();
            }
            else
            {
                timer.Stop();
                clear.Enabled = true;
                start.Text = "Start life";
            }
        }

        private int countOfNeighbours(int x, int y)
        {
            int count = 0;
            for (int i = x - 1; i <= x + 1; ++i)
            {
                for (int j = y - 1; j <= y + 1; ++j)
                {
                    int xl = i, yl = j;

                    if (i == x && j == y) continue;

                    if (i < 0)
                    {
                        if (j < 0)
                        {
                            xl = width / 10 - 1;
                            yl = height / 10 - 1;
                        }
                        else//j>0
                        {
                            xl = width / 10 - 1;
                        }
                    }
                    else//i>0
                    {
                        if (j < 0)
                        {
                            yl = height / 10 - 1;
                        }
                    }

                    if (i > width/10 - 1)
                    {
                        if (j > height/10 - 1)
                        {
                            xl = 0;
                            yl = 0;
                        }
                        else//j < height/10 - 1
                        {
                            xl = 0;
                        }
                    }
                    else//i < width/10 - 1
                    {
                        if (j > height / 10 - 1)
                        {
                            yl = 0;
                        }
                    }

                    if (startField[xl, yl]) count++;
                }
            }
            return count;
        }
      
        private void field_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i <= width/10; ++i)
            {
                for (int j = 0; j <= height/10; ++j)
                {
                    e.Graphics.DrawLine(new Pen(Brushes.Black, 1), new Point(10 * i, 0), new Point(10 * i, 10 * j));
                    e.Graphics.DrawLine(new Pen(Brushes.Black, 1), new Point(0, 10 * j), new Point(10 * i, 10 * j));
                }
            }

            for (int i = 0; i < width/10; ++i)
            {
                for (int j = 0; j < height/10; ++j)
                {
                    if (startField[i, j]) e.Graphics.FillRectangle(Brushes.Red, i*10 + 1, j*10 + 1, 9, 9);
                }
            }
        }

        private void field_MouseClick(object sender, MouseEventArgs e)
        {
            /*Point point = new Point(e.X - e.X % 10, e.Y - e.Y % 10);

            foreach (Point p in basikFigures[figures.SelectedIndex].points)
            {
                Point buffer = new Point(point.X + p.X, point.Y + p.Y);
                bool isAdd = false;

                if (startField.Count > 0)
                {
                    for (int i = 0; i < startField.Count; ++i)
                    {
                        if (startField[i].X == buffer.X && startField[i].Y == buffer.Y) continue;
                        else isAdd = true;
                    }
                }
                else startField.Add(buffer);

                if (isAdd) startField.Add(buffer);
            }*/
            foreach (Point p in basicFigures[figures.SelectedIndex].points)
            {
                startField[(e.X - e.X % 10) / 10 + p.X, (e.Y - e.Y % 10) / 10 + p.Y] = true;
            }

            field.Refresh();
        }

        private void field_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            /*for (int i = 0; i < startField.Count; ++i)
            {
                if (startField[i].X == e.X - e.X % 10 && startField[i].Y == e.Y - e.Y % 10)
                {
                    startField.RemoveAt(i);
                    field.Refresh();
                    return;
                }
            }

            if (startField.Count == 0) clear.Enabled = false;*/
            startField[(e.X - e.X % 10) / 10, (e.Y - e.Y % 10) / 10] = false;
            field.Refresh();
        }

        private void clear_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < width / 10; ++i)
            {
                for (int j = 0; j < height / 10; ++j)
                {
                    startField[i, j] = false;
                }
            }
            field.Refresh();
        }

        private void figures_SelectedIndexChanged(object sender, EventArgs e)
        {
            condition = 0;
            figurevisible.Image = basicFigures[figures.SelectedIndex].image;
        }

        private void plus90_Click(object sender, EventArgs e)
        {
            figurevisible.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            figurevisible.Refresh();

            //condition--;
            //if (condition < 0) condition = 4;

            for (int i = 0; i < basicFigures[figures.SelectedIndex].points.Count; ++i)
            {
                Point p = new Point();
                p.X = (int)(basicFigures[figures.SelectedIndex].points[i].X * Math.Cos(90.0));
                p.Y = (int)(basicFigures[figures.SelectedIndex].points[i].X * Math.Sin(90.0));
                basicFigures[figures.SelectedIndex].points.RemoveAt(i);
                basicFigures[figures.SelectedIndex].points.Add(p);
                /*switch (condition)
                {
                    case 1:
                    case 2:
                        {
                            p.X = basicFigures[figures.SelectedIndex].points[i].Y;
                            p.Y = basicFigures[figures.SelectedIndex].points[i].X * (-1);
                            basicFigures[figures.SelectedIndex].points.RemoveAt(i);
                            basicFigures[figures.SelectedIndex].points.Add(p);
                        } break;
                    case 3:
                        {
                            p.X = basicFigures[figures.SelectedIndex].points[i].Y * (-1);
                            p.Y = basicFigures[figures.SelectedIndex].points[i].X * (-1);
                            basicFigures[figures.SelectedIndex].points.RemoveAt(i);
                            basicFigures[figures.SelectedIndex].points.Add(p);
                        } break;
                    case 4:
                        {
                            p.X = basicFigures[figures.SelectedIndex].points[i].Y;
                            p.Y = basicFigures[figures.SelectedIndex].points[i].X;
                            basicFigures[figures.SelectedIndex].points.RemoveAt(i);
                            basicFigures[figures.SelectedIndex].points.Add(p);
                        } break;
                }*/
            }
        }

        private void minus90_Click(object sender, EventArgs e)
        {
            figurevisible.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
            figurevisible.Refresh();

            //condition++;
            //if (condition > 4) condition = 1;

            for (int i = 0; i < basicFigures[figures.SelectedIndex].points.Count; ++i)
            {
                Point p = new Point();
                p.X = (int)(basicFigures[figures.SelectedIndex].points[i].X * Math.Cos(270.0));
                p.Y = (int)(basicFigures[figures.SelectedIndex].points[i].X * Math.Sin(270.0));
                basicFigures[figures.SelectedIndex].points.RemoveAt(i);
                basicFigures[figures.SelectedIndex].points.Add(p);
                /*switch (condition)
                {
                    case 1:
                        {
                            p.X = basicFigures[figures.SelectedIndex].points[i].Y;
                            p.Y = basicFigures[figures.SelectedIndex].points[i].X;
                            basicFigures[figures.SelectedIndex].points.RemoveAt(i);
                            basicFigures[figures.SelectedIndex].points.Add(p);
                        } break;
                    case 2:
                        {
                            p.X = basicFigures[figures.SelectedIndex].points[i].Y * (-1);
                            p.Y = basicFigures[figures.SelectedIndex].points[i].X * (-1);
                            basicFigures[figures.SelectedIndex].points.RemoveAt(i);
                            basicFigures[figures.SelectedIndex].points.Add(p);
                        } break;
                    case 3:
                    case 4:
                        {
                            p.X = basicFigures[figures.SelectedIndex].points[i].Y * (-1);
                            p.Y = basicFigures[figures.SelectedIndex].points[i].X;
                            basicFigures[figures.SelectedIndex].points.RemoveAt(i);
                            basicFigures[figures.SelectedIndex].points.Add(p);
                        } break;
                }*/
            }
        }
    }
}