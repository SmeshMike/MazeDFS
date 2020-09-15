﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DFSMaze.Logic;
using DFSMaze.Extentions;

namespace DFSMaze
{
    public partial class MazeForm : Form
    {
        public MazeForm()
        {
            InitializeComponent();

        }

        private ByteGrid byteGrid;
        private Point enter;
        private Point exit;
        private Bitmap bitmap;
        private int zoom;
        private void runButton_Click(object sender, EventArgs e)
        {
            timeLabel.Text = "";
            var size = Convert.ToInt32(nTextBox.Text);
            enter = new Point(Convert.ToInt32(xEnterTextBox.Text), Convert.ToInt32(yEnterTextBox.Text));
            exit = new Point(Convert.ToInt32(xExitTextBox.Text), Convert.ToInt32(yExitTextBox.Text));
            byteGrid = new ByteGrid(Convert.ToUInt32(nTextBox.Text));

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            byteGrid.CreateMaze(enter, exit);


            //foreach (var point in byteGrid.Way)
            //{
            //    pointLabel.Text += $"\n {point.X},{point.Y}";
            //}


            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;

            var text = $"Время\nгенерации:\n{ts.Minutes:00}:{ts.Seconds:00}.{ts.Milliseconds:000000}";

            stopWatch.Reset();

            stopWatch.Start();

            zoom = 1;
            bitmap = new Bitmap((2 * size + 1) * zoom, (2 * size + 1) * zoom);

            for (int i = 0; i < (2 * size + 1); i +=1)
            {
                for (int j = 0; j < (2 * size + 1) ; j +=  1)
                {
                    if (!byteGrid.Cell[i, j])
                    {
                        //DrawCube(zoom, bitmap, i, j, Color.Black);
                        bitmap.SetPixel(i, j, Color.Black);
                    }
                    else 
                    {
                        //DrawCube(zoom, bitmap, i, j, Color.CornflowerBlue);
                        bitmap.SetPixel(i, j, Color.CornflowerBlue);
                    }

                }
            }

            //if (((i % 2 != 0 && j % 2 != 0) && (i < 2 * size && j < 2 * size)))

            foreach (var point in byteGrid.WayOut1)
            {
                //DrawCube(zoom, bitmap, point.X, point.Y, Color.Red);
                bitmap.SetPixel(point.X , point.Y, Color.Red);
            }

            DrawCube(zoom, bitmap, enter.X * 2 + 1, enter.Y * 2 + 1, Color.Green);
            DrawCube(zoom, bitmap, exit.X * 2 + 1, exit.Y * 2 + 1, Color.Green);
            

            stopWatch.Stop();
            ts = stopWatch.Elapsed;
            text += $"\n\n\nВремя\nотрисовки:\n{ts.Minutes:00}:{ts.Seconds:00}.{ts.Milliseconds:000000}";
            timeLabel.Text += text;
            pictureBox.Image = bitmap;
            pictureBox.Show();



            //byteGrid.FindWayOut(enter, exit);

            //foreach (var point in byteGrid.Way)
            //{
            //    if((point.X==enter.X * 2 + 1 && point.Y == enter.Y * 2 + 1) || (point.X == exit.X * 2 + 1 && point.Y == exit.Y * 2 + 1))
            //    {
            //        DrawCube(zoom, bitmap, point.X, point.Y, Color.Green);
                    
            //    }
            //    else
            //    {
            //        DrawCube(zoom, bitmap, point.X, point.Y, Color.Red);
            //    }
            //    //pointLabel.Text += $"\n {point.X},{point.Y}";
                
            //}

            //pictureBox.Image = bitmap;
            //pictureBox.Show();
        }


        public void DrawCube(int zoom, Bitmap bitmap, int x, int y, Color color)
        {
            for (int i = 0; i < zoom; i++)
            {
                for (int j = 0; j < zoom; j++)
                {
                    bitmap.SetPixel(x*zoom+i,y*zoom+j, color);
                }   
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {


        }
    }
}