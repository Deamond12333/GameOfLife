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

        Process process;
        Thread thread;
        
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

                process = new Process(startField, (int)width.Value, (int)height.Value);
                thread = new Thread(process.run);
                thread.Start();
            }
            else
            {
                thread.Abort();
                start.Text = "Start life";
                width.Enabled = true;
                height.Enabled = true;
            }
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
    }
}
