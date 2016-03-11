using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace TestingSoftwareLab1
{
    public partial class Home : Form
    {
        List<Point> startField = new List<Point>();
        bool isStart = false;
        BackgroundWorker thread = new BackgroundWorker();

        int height, width;
        public Home()
        {
            InitializeComponent();

            ToolTip tip = new ToolTip();
            tip.SetToolTip(glider, "Glider");
            tip.SetToolTip(block, "Block");
            tip.SetToolTip(boat, "Boat");
            tip.SetToolTip(blinker, "Blinker");
            tip.SetToolTip(tub, "Tub");
            tip.SetToolTip(lwss, "Small bird");
            tip.SetToolTip(mwss, "Average bird");
            tip.SetToolTip(hwss, "Big bird");

            height = field.Height - 1;
            width = field.Width - 1;
            clear.Enabled = false;

            thread.WorkerSupportsCancellation = true;
            thread.WorkerReportsProgress = true;
            thread.DoWork += thread_DoWork;
            thread.ProgressChanged += thread_ProgressChanged;
        }

        private void start_Click(object sender, EventArgs e)
        {
            isStart = !isStart;

            if (isStart)
            {
                clear.Enabled = false;
                start.Text = "Stop life";
                thread.RunWorkerAsync();
            }
            else
            {
                thread.CancelAsync();
                thread.Dispose();
                clear.Enabled = true;
                start.Text = "Start life";
            }
        }

        private void thread_DoWork(object sender, DoWorkEventArgs e)
        {
            while (isStart)
            {
                List<Point> buffer = new List<Point>();

                for (int i = 0; i <= width; i += 10)
                {
                    for (int j = 0; j <= height; j += 10)
                    {
                        Point qurPoint = new Point(i, j);

                        int neighbours = countOfNeighbours(qurPoint);

                        if (neighbours == 2)
                        {
                            for (int k = 0; k < startField.Count; ++k )
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
                }
                thread.ReportProgress(1);

                Thread.Sleep(60); //должно быть не менее 60, иначе поток не остановится!!
            }
        }

        void thread_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            field.Refresh();
        }

        private int countOfNeighbours(Point point)
        {
            int count = 0;
            for (int i = point.X - 10; i <= point.X + 10; i+=10)
            {
                for (int j = point.Y - 10; j <= point.Y + 10; j+=10)
                {
                    if (i == point.X && j == point.Y) continue;
                    if (i < 0 || j < 0) continue;
                    if (i >= width || j >= height) continue;

                    for (int k = 0; k < startField.Count; ++k)
                    {
                        if (startField[k].X == i && startField[k].Y == j) count++;
                    }
                }
            }

            return count;
        }
      
        private void field_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i <= width / 10; ++i)
            {
                for (int j = 0; j <= height / 10; ++j)
                {
                    e.Graphics.DrawLine(new Pen(Brushes.Black, 1), new Point(10 * i, 0), new Point(10 * i, 10 * j));
                    e.Graphics.DrawLine(new Pen(Brushes.Black, 1), new Point(0, 10 * j), new Point(10 * i, 10 * j));
                }
            }

            for (int i = 0; i < startField.Count; ++i)
            {
                e.Graphics.FillRectangle(Brushes.Red, startField[i].X + 1, startField[i].Y + 1, 9, 9);
            }
        }

        private void field_MouseClick(object sender, MouseEventArgs e)
        {
            Point point = new Point(e.X  - e.X % 10, e.Y - e.Y % 10);

            if (startField.Count > 0)
            {
                for (int i = 0; i < startField.Count; ++i )
                {
                    if (startField[i].X == point.X && startField[i].Y == point.Y) return;
                }
            }
            startField.Add(point);
            clear.Enabled = !isStart;
            field.Refresh();
        }

        private void field_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < startField.Count; ++i)
            {
                if (startField[i].X == e.X - e.X % 10 && startField[i].Y == e.Y - e.Y % 10)
                {
                    startField.RemoveAt(i);
                    field.Refresh();
                    return;
                }
            }

            if (startField.Count == 0) clear.Enabled = false;
        }

        private void figure_MouseDown(object sender, MouseEventArgs e)
        {
            ((PictureBox)sender).DoDragDrop(new Bitmap(((PictureBox)sender).Image), DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void field_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void field_DragDrop(object sender, DragEventArgs e)
        {
            Bitmap bitmap = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
        }

        private void clear_Click(object sender, EventArgs e)
        {
            startField.Clear();
            clear.Enabled = false;
            field.Refresh();
        }
    }
}