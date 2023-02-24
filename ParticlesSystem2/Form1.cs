using System.Drawing.Imaging;
using System.Numerics;

namespace ParticlesSystem2
{
    public partial class Form1 : Form
    {
        static Bitmap bmp;
        static Graphics g;

        public List<Ball> Balls;
        public Ball newBall;
        public int numballs;
        public Random random = new Random();
        public Image backgroundImage;

        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(PCT_CANVAS.Width, PCT_CANVAS.Height);
            g = Graphics.FromImage(bmp);
            PCT_CANVAS.Image = bmp;
            timer1.Stop();
            numballs = 950;
            Balls = new List<Ball>();
            backgroundImage = Resource1.goku;
            createBalls();

        }

        private void createBalls()
        {
            for (int i = 0; i < numballs; i++)
            {
                newBall = new Ball(PCT_CANVAS.Size);
                Balls.Add(newBall);
            }
            timer1.Start();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {

            for (int i = 0; i < numballs; i++)
            {

                Balls.ElementAt(i).posXBall += Balls.ElementAt(i).velx;

                Balls.ElementAt(i).timeLive--;

                if (Balls.ElementAt(i).timeLive == 0)
                {
                    Balls.ElementAt(i).posXBall = random.Next(290, 340);
                    Balls.ElementAt(i).posYBall = random.Next(180, 330);
                    Balls.ElementAt(i).velx = random.Next(12, 30);
                    Balls.ElementAt(i).timeLive = random.Next(30, 50);
                }
            }

            drawBalls();
        }

        private void drawBalls()
        {
            g.Clear(Color.Transparent);

            g.DrawImage(backgroundImage, new Rectangle(0, 0, PCT_CANVAS.Width, PCT_CANVAS.Height));

            for (int i = 0; i < numballs; i++)
            {
                g.FillEllipse(new SolidBrush(Balls.ElementAt(i).colorB), Balls.ElementAt(i).posXBall, Balls.ElementAt(i).posYBall, Balls.ElementAt(i).sizeBallx, Balls.ElementAt(i).sizeBally);
            }
            PCT_CANVAS.Invalidate();
        }
    }
}