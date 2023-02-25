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

        public Ball(Size size)
        {
            Random r = new Random();
            sizeBallx = r.Next(8, 30);
            sizeBally = r.Next(4, 6);
            posXBall = r.Next(290, 550);
            posYBall = r.Next(180, 330);
            velx = r.Next(10, 30);
            vely = 0;
            timeLive = r.Next(5, 12);
        }
    }
}
