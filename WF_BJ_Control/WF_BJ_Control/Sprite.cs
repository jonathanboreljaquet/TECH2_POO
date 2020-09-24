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
        protected float elapsedTime;
        protected PointF startPosition;
        protected PointF speed;
        protected readonly Stopwatch sw;

        public PointF Location
        {
            get 
            {
                elapsedTime = sw.ElapsedMilliseconds / 1000f;
                return new PointF(startPosition.X + elapsedTime * speed.X, startPosition.Y + elapsedTime * speed.Y);
            }

        }
        public Image Image { get; private set; }

        public Sprite(PointF startPosition, PointF speed, Image image)
        {
            this.startPosition = startPosition;
            this.speed = speed;
            this.Image = image;
            sw = new Stopwatch();
            sw.Start();
        }
        public void Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(Image, Location);
        }
        

    }
}
