using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_BJ_Control
{
    class Spatialship : Sprite
    {
        private const int NO_SPEED_Y = 0;
        
        public Spatialship(PointF startPosition, PointF speed, Image image) : base (startPosition,speed, image)
        {

            //Do nothing
        }
        public void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                ChangeDirection();
            } 
        }
        public void ShootRocket()
        {
            
        }
        public void ChangeDirection()
        {
            float endPositionX = startPosition.X + elapsedTime * speed.X;
            startPosition.X = endPositionX;
            this.speed = new PointF(speed.X * -1, NO_SPEED_Y);
            sw.Restart();
        }
    }
}
