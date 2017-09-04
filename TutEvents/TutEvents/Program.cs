using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balls
{
    class Program
    {
        static void Main(string[] args)
        {
            Ball ball = new Ball();
            Pitcher p = new Pitcher(ball);
            ball.OnBallInPlay(new BallEventArgs(60, 80));
        }
    }
}

