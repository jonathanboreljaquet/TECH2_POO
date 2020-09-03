using System;
using System.Drawing;
using System.Runtime.Remoting.Channels;
using System.Windows.Forms;

namespace WF_Control
{
    class Scene : Control
    {
        private const int FPS = 60;
        private Bitmap bitmap = null;
        private Graphics g = null;
        private readonly Sprite sprite = null;
        private Timer t;


        public Scene() : base()
        {
            t = new Timer
            {
                Interval = 1000/ FPS,
                Enabled = true
            };
            t.Tick += T_Tick;
            DoubleBuffered = true;
            sprite = new Sprite(new Point(10, 10), new Point(200, 200));
            Paint += sprite.Paint;
            
        }

        private void T_Tick(object sender, EventArgs e)
        {
            Invalidate();
           
        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            // Initialize bitmap and g if null
            bitmap ??= new Bitmap(Size.Width, Size.Height);
            g ??= Graphics.FromImage(bitmap);

            PaintEventArgs p = new PaintEventArgs(g, e.ClipRectangle);
            
            p.Graphics.FillRectangle(Brushes.Blue, new Rectangle(10, 10, 50, 50));
            p.Graphics.Clear(BackColor);
            base.OnPaint(p);
            e.Graphics.DrawImage(bitmap, new Point(0, 0));
        }
    }
}
