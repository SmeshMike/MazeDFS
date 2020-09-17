using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DFSMaze.Logic;
using System.Windows.Media.Imaging;

namespace DFSMaze
{
    public partial class MazeForm : Form
    {
        public MazeForm()
        {
            InitializeComponent();

        }

        private static ByteGrid byteGrid;
        private Point enter;
        private Point exit;
        private Bitmap bitmap;
        private int zoom;
        private void runButton_Click(object sender, EventArgs e)
        {
            timeLabel.Text = "";
            var size = Convert.ToInt32(nTextBox.Text);
            var size2 = (size*2+1) * (size * 2 + 1);
            enter = new Point(Convert.ToInt32(xEnterTextBox.Text), Convert.ToInt32(yEnterTextBox.Text));
            exit = new Point(Convert.ToInt32(xExitTextBox.Text), Convert.ToInt32(yExitTextBox.Text));
            byteGrid = new ByteGrid(Convert.ToUInt32(nTextBox.Text));

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            byteGrid.CreateMaze(enter, exit);

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;

            var text = $"Время\nгенерации:\n{ts.Minutes:00}:{ts.Seconds:00}.{ts.Milliseconds:000000}";

            stopWatch.Reset();

            stopWatch.Start();

            zoom = 1;



            bitmap = new Bitmap((2 * size + 1) * zoom, (2 * size + 1) * zoom);
            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);

            BitmapData bmpData = bitmap.LockBits(rect, ImageLockMode.ReadWrite, bitmap.PixelFormat);

            var ptr = bmpData.Scan0;

            int bytes = Math.Abs(bmpData.Stride) * bitmap.Height ;
            int[] tmp = new int[bytes];
            //Math.Abs(bmpData.Stride)
            System.Runtime.InteropServices.Marshal.Copy(ptr, tmp, 0, bytes);

            //Parallel.For(0, tmp.Length, delegate(int i) { tmp[i] = 500000; });
            DrawIntoBitmap(tmp, 0, size, 0, size);


            System.Runtime.InteropServices.Marshal.Copy(tmp, 0, ptr, bytes);
            bitmap.UnlockBits(bmpData);

            foreach (var point in byteGrid.WayOut1)
            {
                //DrawCube(zoom, bitmap, point.X, point.Y, Color.CornflowerBlue);
                bitmap.SetPixel(point.X , point.Y, Color.CornflowerBlue);
            }

            bitmap.SetPixel(enter.X * 2 + 1, enter.Y * 2 + 1, Color.Red);
            bitmap.SetPixel(exit.X * 2 + 1, exit.Y * 2 + 1, Color.Red);

            //Draw(size);


            SavePicture();


            stopWatch.Stop();
            ts = stopWatch.Elapsed;
            text += $"\n\n\nВремя\nотрисовки:\n{ts.Minutes:00}:{ts.Seconds:00}.{ts.Milliseconds:000000}";
            timeLabel.Text += text;

            async void Draw(int size1)
            {
                //var t1 = Task.Run(() => DrawIntoBitmap(tmp, 0, size1, 0, size1));
                //await Task.WhenAll(t1, t2);
            }
        }


        private static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }

        private static void DrawIntoBitmap(int[] bitmap, int iStart, int iStop, int jStart, int jStop)
        {
            Parallel.For(2 * iStart + 1, 2 * iStop + 1, (i) =>
            {
                Parallel.For(2 * jStart + 1, 2 * jStop + 1, (j) =>
                {
                    if (!byteGrid.Cell[i, j])
                    {
                        //DrawCube(zoom, bitmap, i, j, Color.Black);
                        //bitmap.SetPixel(i, j, Color.Red);
                        bitmap[j * (2 * iStop + 1) + i] = Color.Black.ToArgb();
                    }
                    else
                    {
                        //DrawCube(zoom, bitmap, i, j, Color.AliceBlue);
                        //bitmap.SetPixel(i, j, Color.AliceBlue);
                        bitmap[j * (2 * iStop + 1) + i] = Color.AliceBlue.ToArgb();
                    }
                });

            });
        }



        private void SavePicture()
        {
            ImageCodecInfo myImageCodecInfo = GetEncoderInfo("image/jpeg");

            var myEncoder = System.Drawing.Imaging.Encoder.Quality;
            var myEncoderParameter = new EncoderParameter(myEncoder, 25L);
            EncoderParameters myEncoderParameters = new EncoderParameters();
            myEncoderParameters.Param[0] = myEncoderParameter;

            myEncoderParameter = new EncoderParameter(myEncoder, 100L);
            myEncoderParameters.Param[0] = myEncoderParameter;
            bitmap.Save("Shapes100.jpg", myImageCodecInfo, myEncoderParameters);
        }
    }
}
