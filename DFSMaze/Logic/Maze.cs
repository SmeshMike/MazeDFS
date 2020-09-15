using System;
using System.Collections.Generic;
using System.Drawing;
using DFSMaze.Extentions;

namespace DFSMaze.Logic
{

    public class ByteGrid
    {
        public bool[,] Cell;

        public uint Count;
        public uint CellCount;
        public uint VisitedCount;
        public Stack<Point> WayOut;
        public Point[] WayOut1;
        public Stack<Point> FullWay;
        public ByteGrid(uint n)
        {
            WayOut = new Stack<Point>();
            
            FullWay = new Stack<Point>();
            VisitedCount = 0;
            CellCount = n*n;
            Count = 2 * n +1;
            Cell = new bool[Count, Count];
            for (int i = 0; i < Count; ++i)
            {
                for (int j = 0; j < Count; ++j)
                {
                    //if ((i % 2 != 0 && j % 2 != 0) && (i < 2 * n && j < 2 * n))
                           //если ячейка нечетная по x и y и при этом находится в пределах стен лабиринт

                    Cell[i, j] = false;
                }
            }
        }






    }
}    

