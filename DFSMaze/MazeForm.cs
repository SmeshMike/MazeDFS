using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;
using System.Windows.Forms;
using DFSMaze.Logic;

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
            zoom = 8000 / size;
            var size2 = size*2+1;
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


            bitmap = new Bitmap(size2, size2);
            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);

            BitmapData bmpData = bitmap.LockBits(rect, ImageLockMode.ReadWrite, bitmap.PixelFormat);

            var ptr = bmpData.Scan0;

            int bytes = bitmap.Width * bitmap.Height ;
            int[] tmp = new int[bytes];


            System.Runtime.InteropServices.Marshal.Copy(ptr, tmp, 0, bytes);

            DrawIntoBitmap(tmp, size2);


            Parallel.ForEach(byteGrid.WayOut1, (point) =>
            {
                tmp[point.Y * size2 + point.X] = Color.CornflowerBlue.ToArgb();
            });

            System.Runtime.InteropServices.Marshal.Copy(tmp, 0, ptr, bytes);
            bitmap.UnlockBits(bmpData);

            bitmap.SetPixel(enter.X * 2 + 1, enter.Y * 2 + 1, Color.Red);
            bitmap.SetPixel(exit.X * 2 + 1, exit.Y * 2 + 1, Color.Red);

            SavePicture();


            stopWatch.Stop();
            ts = stopWatch.Elapsed;
            text += $"\n\n\nВремя\nотрисовки:\n{ts.Minutes:00}:{ts.Seconds:00}.{ts.Milliseconds:000000}";
            timeLabel.Text += text;
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

        private static void DrawIntoBitmap(int[] bitmap, int size2)
        {
            Parallel.For(0, size2, (i) =>
            {
                Parallel.For(0, size2, (j) =>
                {
                    if (!byteGrid.Cell[i, j])
                    {
                        //DrawCube(zoom, bitmap, i, j, Color.Black);
                        //bitmap.SetPixel(i, j, Color.Red);
                        bitmap[j * size2 + i] = Color.Black.ToArgb();
                    }
                    else
                    {
                        //DrawCube(zoom, bitmap, i, j, Color.AliceBlue);
                        //bitmap.SetPixel(i, j, Color.AliceBlue);
                        bitmap[j * size2 + i] = Color.AliceBlue.ToArgb();
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
