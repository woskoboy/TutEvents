using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balls
{
    class Ball { 
    /* тип события - EventHandler, означает присутствие двух параметров: 
	объекта sender - это ссылка на объект, вызвавший событие и
	e — ссылка на объект EventArgs, 
        а также то, что это событие не возвращает значение */
        public event EventHandler BallInPlay;
        public void OnBallInPlay(BallEventArgs e) {
        /* BallInPlay копируется в переменную ballInPlay,
        кот-я гарантированно не имеет значения null
        и используется для вызова события*/
            EventHandler ballInPlay = BallInPlay; 
            if (BallInPlay != null) // закреплен ли за событием обработчик
                ballInPlay(this, e); // вызов события
        }
    }
    class BallEventArgs : EventArgs {
        // Класс данных события
        public int Distance { get; private set; }
        public int Trajectory { get; private set; }
        public BallEventArgs(int trajectory, int distance){
            this.Trajectory = trajectory;
            this.Distance = distance;
        }  
    }
}
