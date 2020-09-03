using System.Diagnostics;
using System.Drawing;
using System.Runtime;
using System.Windows.Forms;

namespace WF_Control
{
    class Sprite
    {
        private readonly Stopwatch sw;
        private PointF startPosition;
        private PointF speed;

        public PointF Location
        {
            get 
            {
                float elapsedTime = sw.ElapsedMilliseconds / 1000f;
                return new PointF(startPosition.X + elapsedTime * speed.X, startPosition.Y + elapsedTime * speed.Y); 
            }
            
        }

        public Sprite(Point startPosition,Point speed)
        {
            this.startPosition = startPosition;
            this.speed = speed;
            sw = new Stopwatch();
            sw.Start();
        }

        

        public void Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.Azure, new Rectangle(Point.Round(Location),new Size(20,20)));
        }

    }
}
