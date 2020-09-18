using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace DFSMaze.Logic
{

    public class ByteGrid
    {
        public bool[,] Cell;

        public uint Count;
        public uint CellCount;
        public uint VisitedCount;
        public Point[] WayOut;
        public Stack<Point> FullWay;
        public ByteGrid(uint n)
        {
            FullWay = new Stack<Point>();
            VisitedCount = 0;
            CellCount = n * n;
            Count = 2 * n + 1;
            Cell = new bool[Count, Count];
            for (int i = 0; i < Count; ++i)
            {
                for (int j = 0; j < Count; ++j)
                {
                    Cell[i, j] = false;
                }
            }
        }


        public ByteGrid GoToCell(ref int i, ref int j, byte dir)
        {
            switch (dir)
            {
                //влево
                case 0:
                    --i;
                    Cell[i, j] = true;
                    FullWay.Push(new Point(i, j));
                    --i;
                    Cell[i, j] = true;
                    FullWay.Push(new Point(i, j));
                    ++VisitedCount;
                    break;
                //вверх
                case 1:
                    --j;
                    Cell[i, j] = true;
                    FullWay.Push(new Point(i, j));
                    --j;
                    Cell[i, j] = true;
                    FullWay.Push(new Point(i, j));
                    ++VisitedCount;
                    break;
                //вправо
                case 2:
                    ++i;
                    Cell[i, j] = true;
                    FullWay.Push(new Point(i, j));
                    ++i;
                    Cell[i, j] = true;
                    FullWay.Push(new Point(i, j));
                    ++VisitedCount;
                    break;
                //вниз
                case 3:
                    ++j;
                    Cell[i, j] = true;
                    FullWay.Push(new Point(i, j));
                    ++j;
                    Cell[i, j] = true;
                    FullWay.Push(new Point(i, j));
                    ++VisitedCount;
                    break;

            }

            return this;
        }


        public void CreateMaze(Point enter, Point exit)
        {
            int iEnter = enter.Y * 2 + 1;
            int jEnter = enter.X * 2 + 1;

            int iExit = exit.Y * 2 + 1;
            int jExit = exit.X * 2 + 1;
            FullWay.Push(new Point(iEnter, jEnter));
            Cell[iEnter, jEnter] = true;
            ++VisitedCount;
            var neighbours = HasNeigboursToVisit(iEnter, jEnter);
            Random randomizer = new Random();
            byte index;
            while (VisitedCount != CellCount)
            {
                if (neighbours.Contains(true))
                {
                    index = Convert.ToByte(randomizer.Next(0, 4));
                    while (!neighbours[index])
                    {
                        index = Convert.ToByte(randomizer.Next(0, 4));
                    }

                    GoToCell(ref iEnter, ref jEnter, index);

                    if (iEnter == iExit && jEnter == jExit)
                    {
                        WayOut = new Point[FullWay.Count];
                        FullWay.CopyTo(WayOut, 0);
                    }
                    neighbours = HasNeigboursToVisit(iEnter, jEnter);
                }
                else
                {
                    do
                    {
                        var point = FullWay.Pop();

                        iEnter = point.X;
                        jEnter = point.Y;
                        neighbours = HasNeigboursToVisit(iEnter, jEnter);
                        if (neighbours.Contains(true))
                            FullWay.Push(point);
                        else
                            FullWay.Pop();

                    } while (!neighbours.Contains(true));

                }
            }

        }
        bool[] HasNeigboursToVisit(int i, int j)
        {
            bool[] directions = new bool[4] { false, false, false, false };
            if (i - 2 > 0 && (Cell[i - 2, j] == false))
            {
                directions[0] = true;//влево
            }

            if (j - 2 > 0 && (Cell[i, j - 2] == false))
            {
                directions[1] = true;//вверх
            }

            if (i + 2 < Count && (Cell[i + 2, j] == false))
            {
                directions[2] = true;//вправо
            }

            if (j + 2 < Count && (Cell[i, j + 2] == false))
            {
                directions[3] = true;//вниз
            }

            return directions;
        }

    }
}


