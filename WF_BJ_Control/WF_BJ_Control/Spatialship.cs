using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_Control;

namespace WF_BJ_Control
{
    class Spatialship : Sprite
    {
        const int SPEED_SPATIALSHIP = -20;
        
        public Spatialship(Point startPosition, Size size, Point speed) : base (startPosition,size,speed)
        {
            //Do nothing
        }
        public void MooveUpOrDown(int speed)
        {
            base.speed = new PointF(0, speed);
        }
        public void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                base.sw.Restart();
                MooveUpOrDown(-10);
            } 
            if (e.KeyCode == Keys.Down)
            {
                base.sw.Restart();
                MooveUpOrDown(10);
            }
        }
    }
}
