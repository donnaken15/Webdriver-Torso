using System;
using System.Drawing;
using System.Windows.Forms;

namespace Webdriver_Torso
{
    class Program
    {
        static Form prog;

        static Size size = new Size(640, 360);

        static Point textpos = new Point(8, 332);

        static Random rand = new Random();

        static ushort frame;

        static PictureBox display = new PictureBox();

        static Rectangle newbox
        {
            get
            {
                return new Rectangle(
                    rand.Next(0, 540), rand.Next(0, 240), rand.Next(0, 540), rand.Next(0, 240));
            }
        }

        static Font font = new Font("Courier New", 8, FontStyle.Bold);

        [MTAThread]
        static void Main()
        {
            prog = new Form();
            prog.ShowIcon = false;
            prog.MaximizeBox = false;
            prog.MinimizeBox = false;
            prog.Text = "Webdriver Torso Simulation";
            prog.FormBorderStyle = FormBorderStyle.FixedSingle;
            prog.ClientSize = size;
            prog.StartPosition = FormStartPosition.CenterScreen;
            prog.BackColor = Color.White;
            prog.Controls.Add(display);
            display.Dock = DockStyle.Fill;
            prog.Show();
            while (prog.Visible)
            {
                display.Image = new Bitmap(640, 360);
                using (Graphics g = display.CreateGraphics())
                {
                    g.FillRectangle(Brushes.Blue, newbox);
                    g.FillRectangle(Brushes.Red, newbox);
                    g.DrawString("aqua.flv - Slide " + frame.ToString("0000"), font, Brushes.Black, textpos);
                }
                Console.Beep(rand.Next(400, 2000), 1000);
                Application.DoEvents();
                frame++;
                if (frame >= 10000)
                    frame = 0;
            }
        }
    }
}
