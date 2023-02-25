using System.Drawing.Drawing2D;
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
        public Image texture;

        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(PCT_CANVAS.Width, PCT_CANVAS.Height);
            g = Graphics.FromImage(bmp);
            PCT_CANVAS.Image = bmp;
            timer1.Stop();
            numballs = 200;
            Balls = new List<Ball>();
            backgroundImage = Resource1.goku;
            texture = Resource1.hame3;
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
            g.Clear(Color.Transparent);

            for (int i = 0; i < numballs; i++)
            {

                Balls.ElementAt(i).timeLive--;
                Balls.ElementAt(i).posXBall += Balls.ElementAt(i).velx;
                Balls.ElementAt(i).posYBall += Balls.ElementAt(i).vely;

                // Check if the ball hits the right wall
                if (Balls.ElementAt(i).posXBall + Balls.ElementAt(i).sizeBallx >= PCT_CANVAS.Width)
                {
                    Balls.ElementAt(i).velx = -Balls.ElementAt(i).velx;
                    int value1 = -20;
                    int value2 = 20;

                    int randomValue = random.Next(2);
                    Balls.ElementAt(i).vely = randomValue == 0 ? value1 : value2;

                    Balls.ElementAt(i).posXBall = PCT_CANVAS.Width - Balls.ElementAt(i).sizeBallx - 1;
                }


                if (Balls.ElementAt(i).timeLive == 0)
                {
                    Balls.ElementAt(i).posXBall = random.Next(290, 340);
                    Balls.ElementAt(i).posYBall = random.Next(180, 330);
                    Balls.ElementAt(i).velx = random.Next(10, 30);
                    Balls.ElementAt(i).timeLive = random.Next(10, 20);
                    Balls.ElementAt(i).vely = 0;
                }
               
            }
            drawBalls();
        }

        private void drawBalls()
        {

            g.DrawImage(backgroundImage, new Rectangle(0, 0, PCT_CANVAS.Width, PCT_CANVAS.Height));

            for (int i = 0; i < numballs; i++)
            {
                Color textureColor = ((Bitmap)texture).GetPixel((int)Balls.ElementAt(i).posXBall, (int)Balls.ElementAt(i).posYBall);

                // Calculate the alpha value
                int alpha = textureColor.A;

                // Create a new color with the same red, green, and blue values as the texture color,
                // but with an alpha value proportional to the texture alpha value
                Color ballColor = Color.FromArgb(alpha, textureColor.R, textureColor.G, textureColor.B);

                // Draw the ball
                SolidBrush brush = new SolidBrush(ballColor);
                g.FillEllipse(brush, Balls.ElementAt(i).posXBall, Balls.ElementAt(i).posYBall, Balls.ElementAt(i).sizeBallx, Balls.ElementAt(i).sizeBally);
            }

            PCT_CANVAS.Invalidate();
        }
    }
}