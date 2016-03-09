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
    class Process
    {
        public List<Point> startField;

        private List<Point> buffer = new List<Point>();
        private int width, height;

        public Process(List<Point> startField, int width, int height)
        {
            this.startField = startField;
            this.width = width;
            this.height = height;

            for (int i = 0; i < width; i+=10)
            {
                for (int j = 0; j < height; j += 10)
                {
                    buffer.Add(new Point(i, j));
                }
            }
        }

        public void run()
        {
            while (true)
            {
                for (int i = 0; i < buffer.Count; ++i)
                {
                    int neighbours = countOfNeighbours(buffer[i]);

                    if (neighbours < 2 || neighbours > 3) buffer.RemoveAt(i);
                    else if (neighbours == 2)
                    {
                        bool delete = true;

                        for (int j = 0; j < startField.Count; ++i)
                        {
                            if (buffer[i].X == startField[j].X && buffer[i].Y == startField[j].Y)
                            {
                                delete = false;
                                break;
                            }
                        }

                        if (delete) buffer.RemoveAt(i);
                    }
                    else if (neighbours == 3) continue;
                }

                startField.Clear();
                foreach (Point point in buffer)
                {
                    startField.Add(point);
                }
                Thread.Sleep(200);
            }
        }

        private int countOfNeighbours(Point point)
        {
            int count = 0;
            foreach (Point p in startField)
            {
                if ((point.X + 1 == p.X || point.X - 1 == p.X) && (point.Y + 1 == p.Y || point.Y - 1 == p.Y)) count++;
            }
            return count;
        }
    }
}
