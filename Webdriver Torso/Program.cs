using System;
using System.Drawing;
using System.Windows.Forms;

namespace Webdriver_Torso
{
    class Program
    {
        static Form prog;

        static Size size = new Size(640, 360);

        static Point textpos = new Point(8,332);

        static Random rand = new Random();

        static ushort frame;

        static PictureBox display = new PictureBox();

        static Rectangle newbox
        {
            get
            {
                return new Rectangle(
                    rand.Next(0, 640), rand.Next(0, 360), rand.Next(0, 640), rand.Next(0, 360));
            }
        }

        static Font font = new Font("Courier New", 8, FontStyle.Bold);

        static void Main(string[] args)
        {
            prog = new Form();
            prog.ClientSize = size;
            prog.BackColor = Color.White;
            prog.Controls.Add(display);
            display.Dock = DockStyle.Fill;
            prog.Show();
            while(true) {
                display.Image = new Bitmap(size.Width, size.Height);
                using (Graphics g = display.CreateGraphics())
                {
                    g.FillRectangle(Brushes.Blue, newbox);
                    g.FillRectangle(Brushes.Red, newbox);
                    g.DrawString("aqua.flv - Slide " + frame.ToString("0000"), font, Brushes.Black, textpos);
                    g.Dispose();
                }
                GC.Collect();
                Console.Beep(rand.Next(400,2000), 1000);
                prog.Refresh();
                prog.Update();
                Application.DoEvents();
                frame++;
                if (frame >= 10000)
                    frame = 0;
                if (prog.IsDisposed || prog.Visible == false)
                    break;
            }
        }
    }
}
