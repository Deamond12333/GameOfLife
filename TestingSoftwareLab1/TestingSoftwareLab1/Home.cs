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
        BackgroundWorker thread;
        
        public Home()
        {
            InitializeComponent();

            ToolTip tip = new ToolTip();
            tip.SetToolTip(glider, "Glider");
            tip.SetToolTip(block, "Block");
            tip.SetToolTip(boat, "Boat");
            tip.SetToolTip(blinker, "Blinker");
            tip.SetToolTip(tub, "Tub");
            tip.SetToolTip(lwss, "LWSS");
            tip.SetToolTip(mwss, "MWSS");
            tip.SetToolTip(hwss, "HWSS");
        }

        private void NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            List<Point> buffer = new List<Point>();
            switch (((NumericUpDown)sender).Name)
            {
                case "height":
                    {
                        foreach(Point point in startField)
                        {
                            if ((int)((NumericUpDown)sender).Value * 10 <= point.Y) buffer.Add(point);
                        }
                        foreach(Point point in buffer)
                        {
                            startField.Remove(point);
                        }
                    }break;

                case "width":
                    {
                        foreach (Point point in startField)
                        {
                            if ((int)((NumericUpDown)sender).Value * 10 <= point.X) buffer.Add(point);
                        }
                        foreach (Point point in buffer)
                        {
                            startField.Remove(point);
                        }
                    } break;
            }
            field.Refresh();
        }

        private void start_Click(object sender, EventArgs e)
        {
            isStart = !isStart;
            if (isStart)
            {
                start.Text = "Stop life";
                width.Enabled = false;
                height.Enabled = false;

                thread = new BackgroundWorker();
                thread.WorkerSupportsCancellation = true;
                thread.WorkerReportsProgress = true;
                thread.DoWork += thread_DoWork;
                thread.ProgressChanged += thread_ProgressChanged;
                thread.RunWorkerAsync();
            }
            else
            {
                thread.CancelAsync();
                start.Text = "Start life";
                width.Enabled = true;
                height.Enabled = true;
            }
        }

        private void thread_DoWork(object sender, DoWorkEventArgs e)
        {
            while (isStart)
            {
                List<Point> buffer = new List<Point>();

                for (int i = 0; i <= (int)width.Value * 10; i += 10)
                {
                    for (int j = 0; j <= (int)height.Value * 10; j += 10)
                    {
                        Point qurPoint = new Point(i, j);

                        int neighbours = countOfNeighbours(qurPoint);

                        if (neighbours == 2)
                        {
                            foreach (Point point in startField)
                            {
                                if (qurPoint.X == point.X && qurPoint.Y == point.Y)
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

                Thread.Sleep(50);
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
                    if (i >= (int)width.Value * 10 || j >= (int)height.Value * 10) continue;

                    foreach (Point p in startField)
                    {
                        if (p.X == i && p.Y == j) count++;
                    }
                }
            }

            return count;
        }
      
        private void field_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i <= (int)width.Value; ++i)
            {
                for (int j = 0; j <= (int)height.Value; ++j)
                {
                    e.Graphics.DrawLine(new Pen(Brushes.Black, 1), new Point(10 * i, 0), new Point(10 * i, 10 * j));
                    e.Graphics.DrawLine(new Pen(Brushes.Black, 1), new Point(0, 10 * j), new Point(10 * i, 10 * j));
                }
            }

            if (startField.Count > 0)
            {
                foreach (Point point in startField)
                {
                    e.Graphics.FillRectangle(Brushes.Red, point.X + 1, point.Y + 1, 9, 9);
                }
            }
        }

        private void field_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.X > ((int)width.Value * 10) - 1 || e.Y > ((int)height.Value * 10) - 1) return;

            Point point = new Point(e.X  - e.X % 10, e.Y - e.Y % 10);

            if (startField.Count > 0)
            {
                foreach (Point p in startField)
                {
                    if (p.X == point.X && p.Y == point.Y) return;
                }
            }
            startField.Add(point);
            field.Refresh();
        }

        private void field_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (startField.Count > 0)
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
            }
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
    }
}