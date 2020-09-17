using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime;
using System.Threading;
using System.Windows.Forms;

namespace WF_BJ_Control
{
    public class Sprite
    {
        private const int NO_SPEED_Y = 0;
        private PointF startPosition;
        private PointF speed; 

        public PointF Location
        {
            get 
            {
                startPosition = new PointF(startPosition.X + speed.X, startPosition.Y + speed.Y);
                return startPosition;
            }

        }
        public Image Image { get; private set; }

        public Sprite(Point startPosition,Point speed, Image image)
        {
            this.startPosition = startPosition;
            this.speed = speed;
            this.Image = image;
        }
        public void Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(Image, Location);
        }
        public void MooveLeft(int speed)
        {
            this.speed = new PointF(speed * -1, NO_SPEED_Y);
        }
        public void MooveRight(int speed)
        {
            this.speed = new PointF(speed, NO_SPEED_Y);
        }

    }
}
