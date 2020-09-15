using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using DFSMaze.Logic;

namespace DFSMaze.Extentions
{
    public static class ByteGridExtentions
    {
        public static ByteGrid GoToCell(this ByteGrid grid,ref int i,ref int j, byte dir)
        {
            var mas = grid.Cell;
            switch (dir)
            {   
                //влево
                case 0:
                    --i;
                    mas[i , j] = true;
                    grid.FullWay.Push(new Point(i, j));
                    --i;
                    mas[i, j] = true;
                    grid.FullWay.Push(new Point(i, j));
                    ++grid.VisitedCount;
                    break;
                //вверх
                case 1:
                    --j;
                    mas[i, j ] = true;
                    grid.FullWay.Push(new Point(i, j));
                    --j;
                    mas[i, j] = true;
                    grid.FullWay.Push(new Point(i, j));
                    ++grid.VisitedCount;
                    break;
                //вправо
                case 2:
                    ++i;
                    mas[i, j] = true;
                    grid.FullWay.Push(new Point(i, j));
                    ++i;
                    mas[i,j] = true;
                    grid.FullWay.Push(new Point(i, j));
                    ++grid.VisitedCount;
                    break;
                //вниз
                case 3:
                    ++j;
                    mas[i, j] = true;
                    grid.FullWay.Push(new Point(i, j));
                    ++j;
                    mas[i, j] = true;
                    grid.FullWay.Push(new Point(i, j));
                    ++grid.VisitedCount;
                    break;

            }

            grid.Cell = mas;
            return grid;
        }

        public static ByteGrid GoThrowWall(this ByteGrid grid, ref int i, ref int j, byte dir)
        {
            var mas = grid.Cell;
            switch (dir)
            {
                //влево
                case 0:
                    --i;
                    mas[i, j] = false;
                    grid.WayOut.Push(new Point(i, j));
                    --i;
                    mas[i, j] = true;
                    grid.WayOut.Push(new Point(i, j));
                    ++grid.VisitedCount;
                    break;
                //вверх
                case 1:
                    --j;
                    mas[i, j] = false;
                    grid.WayOut.Push(new Point(i, j));
                    --j;
                    mas[i, j] = true;
                    grid.WayOut.Push(new Point(i, j));
                    ++grid.VisitedCount;
                    break;
                //вправо
                case 2:
                    ++i;
                    mas[i, j] = false;
                    grid.WayOut.Push(new Point(i, j));
                    ++i;
                    mas[i, j] = true;
                    grid.WayOut.Push(new Point(i, j));
                    ++grid.VisitedCount;
                    break;
                //вниз
                case 3:
                    ++j;
                    mas[i, j] = false;
                    grid.WayOut.Push(new Point(i, j));
                    ++j;
                    mas[i, j] = true;
                    grid.WayOut.Push(new Point(i, j));
                    ++grid.VisitedCount;
                    break;

            }

            grid.Cell = mas;
            return grid;
        }

        public static void CreateMaze(this ByteGrid Maze, Point enter, Point exit)
        {
            int iEnter = enter.Y * 2 + 1;
            int jEnter = enter.X * 2 + 1;

            int iExit = exit.Y * 2 + 1;
            int jExit = exit.X * 2 + 1;
            Maze.FullWay.Push(new Point(iEnter,jEnter));
            Maze.WayOut.Push(new Point(iExit, jExit));
            Maze.Cell[iEnter, iEnter] = true;
            ++Maze.VisitedCount;
            var neighbours = HasNeigboursToVisit(Maze, iEnter, iEnter);
            Random randomizer = new Random();
            byte index;
            while (Maze.VisitedCount != Maze.CellCount)
            {
                if (neighbours.Contains(true))
                {
                    //var count = Convert.ToByte(neighbours.Count(pred => pred == true));
                    //if (count > 1)
                    //{
                    //    Maze.Way.Push(new Point(i, j));

                    //}

                    //var trueNeigbours = neighbours.Select((b, i) => b == true ? i : -1).Where(i => i != -1).ToList();
                    //index = Convert.ToByte(trueNeigbours[randomizer.Next(0, trueNeigbours.Count)]);

                    index = Convert.ToByte(randomizer.Next(0, 4));
                    while (!neighbours[index])
                    {
                        index = Convert.ToByte(randomizer.Next(0, 4));
                    }

                    Maze.GoToCell(ref iEnter, ref jEnter, index);

                    if (iEnter == iExit && jEnter == jExit)
                    {
                        Maze.WayOut1 = new Point[Maze.FullWay.Count];
                        Maze.FullWay.CopyTo(Maze.WayOut1, 0);
                    }
                    //Maze.FullWay.Push(new Point(iEnter, jEnter));
                    neighbours = HasNeigboursToVisit(Maze, iEnter, jEnter);
                }
                else
                {
                    do
                    {
                        var point = Maze.FullWay.Pop();

                        iEnter = point.X;
                        jEnter = point.Y;
                        neighbours = HasNeigboursToVisit(Maze, iEnter, jEnter);
                        if (neighbours.Contains(true))
                            Maze.FullWay.Push(point);
                        else
                            Maze.FullWay.Pop();

                    } while (!neighbours.Contains(true));

                }
            }

        }

        public static void FindWayOut(this ByteGrid Maze, Point enter, Point exit)
        {
            Maze.WayOut.Clear();
            Maze.FullWay.Clear();

            int iEnter = enter.Y * 2 + 1;
            int jEnter = enter.X * 2 + 1;

            int iExit = exit.Y * 2 + 1;
            int jExit = exit.X * 2 + 1;

            for (int i = 0; i < Maze.Count; ++i)
            {
                for (int j = 0; j < Maze.Count; ++j)
                {
                    if ((i % 2 != 0 && j % 2 != 0) && (i < Maze.Count -1 && j < Maze.Count - 1))
                    //если ячейка нечетная по x и y и при этом находится в пределах стен лабиринт

                    Maze.Cell[i, j] = false;
                }
            }

            Maze.WayOut.Push(new Point(iEnter, jEnter));

            Maze.Cell[iEnter, jEnter] = true;

            var neighbours = HasNoWalls(Maze, iEnter, jEnter);
            Random randomizer = new Random();
            byte index;
            while (iEnter != iExit || jEnter!= jExit)
            {
                if (neighbours.Contains(true))
                {


                    index = Convert.ToByte(randomizer.Next(0, 4));
                    while (!neighbours[index])
                    {
                        index = Convert.ToByte(randomizer.Next(0, 4));
                    }

                    Maze.GoThrowWall(ref iEnter, ref jEnter, index);

                    
                    neighbours = HasNoWalls(Maze, iEnter, jEnter);
                }
                else
                {
                    do
                    {
                        var point = Maze.WayOut.Pop();
                        

                        iEnter = point.X;
                        jEnter = point.Y;
                        neighbours = HasNoWalls(Maze, iEnter, jEnter);
                        if (neighbours.Contains(true))
                            Maze.WayOut.Push(point);
                        else
                            Maze.WayOut.Pop();
                        
                    } while (!neighbours.Contains(true));

                }
            }
        }

        static bool[] HasNeigboursToVisit(ByteGrid grid, int i, int j)
        {
            bool[] directions = new bool[4] { false, false, false, false };
            if (i - 2 > 0 && (grid.Cell[i - 2, j] == false))
            {
                directions[0] = true;//влево
            }

            if (j - 2 > 0 && (grid.Cell[i, j - 2] == false))
            {
                directions[1] = true;//вверх
            }

            if (i + 2 < grid.Count && (grid.Cell[i + 2, j] == false))
            {
                directions[2] = true;//вправо
            }

            if (j + 2 < grid.Count && (grid.Cell[i, j + 2] == false))
            {
                directions[3] = true;//вниз
            }

            return directions;
        }

        static bool[] HasNoWalls(ByteGrid grid, int i, int j)
        {
            bool[] directions = new bool[4] { false, false, false, false };
            if (i - 1 > 0 && (grid.Cell[i - 1, j]))
            {
                directions[0] = true;//влево
            }

            if (j - 1 > 0 && (grid.Cell[i, j - 1]))
            {
                directions[1] = true;//вверх
            }

            if (i + 1 < grid.Count && (grid.Cell[i + 1, j] ))
            {
                directions[2] = true;//вправо
            }

            if (j + 1 < grid.Count && (grid.Cell[i, j + 1]))
            {
                directions[3] = true;//вниз
            }

            return directions;
        }
    }
}

