using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticlesSystem2
{
    public class Ball
    {
        public float sizeBallx;
        public float sizeBally;
        public float posXBall;
        public float posYBall;
        public float velx, vely;
        public Color colorB;
        public int timeLive;
        public Image texture;

        public Ball(Size size)
        {
            Random r = new Random();
            sizeBallx = r.Next(20, 60);
            sizeBally = r.Next(2, 4);
            posXBall = r.Next(290, 440);
            posYBall = r.Next(180, 330);
            velx = r.Next(5, 50);
            vely = 0;
            texture = Resource1.fire;
            colorB = Color.FromArgb(r.Next(256), 0, 0, r.Next(256));
            timeLive = r.Next(10, 50);
        }
    }
}
