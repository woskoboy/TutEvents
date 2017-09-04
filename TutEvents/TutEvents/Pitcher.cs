using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balls
{
    class Pitcher {
        public Pitcher(Ball ball){ 
        // навешиваем обработчик Ball_BallInPlay на событие BallInPlay
            ball.BallInPlay += new EventHandler(Ball_BallInPlay);
        }
        private void Ball_BallInPlay(object sender, EventArgs e){
            if (e is BallEventArgs){
                BallEventArgs ballEventArgs = e as BallEventArgs;
                if ((ballEventArgs.Distance < 95) && (ballEventArgs.Trajectory < 80)) 
                    CatchBall(); else CoverFirstBase();
            }
        }
        private void CoverFirstBase(){Console.WriteLine("Cover First Base! ");}
        private void CatchBall(){Console.WriteLine("Ball was caught! ");}
    }
}
