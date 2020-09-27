using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_BJ_Control
{
    class Invader : Sprite     
    {
        private const int NO_SPEED_Y = 0;
        private const int NO_SPEED_X = 0;
        public Invader(PointF startPosition, PointF speed, Image image) : base(startPosition,speed, image)
        {
            //Do nothing
        }
        public void MoveDown()
        {
            float endPositionX = startPosition.X + elapsedTime * speed.X;
            float endPositionY = startPosition.Y + elapsedTime * speed.Y;
            startPosition.X = endPositionX;
            startPosition.Y = endPositionY;
            this.speed = new PointF(speed.X * -1, 10);
            sw.Restart();
        }


    }
}
