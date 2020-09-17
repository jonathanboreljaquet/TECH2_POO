using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Remoting.Channels;
using System.Windows.Forms;

namespace WF_BJ_Control
{
    class Scene : Control
    {
        private const int FPS = 60;
        private const int START_POSITION_SPATIALSHIP_X = 420;
        private const int START_POSITION_SPATIALSHIP_Y = 420;
        private const int MINIMUM_SIZE_PARTICULE = 5;
        private const int MAXIMUM_SIZE_PARTICULE = 8;
        private const int MINIMUM_SPEED = -100;
        private const int MAXIMUM_SPEED = 100;

        private Bitmap bitmap = null;
        private Graphics g = null;
        private readonly Spatialship spatialship = null;
        private readonly Invader invader = null;
        private Timer t;


        public Scene() : base()
        {          
            DoubleBuffered = true;
            t = new Timer
            {
                Interval = 1000/ FPS,
                Enabled = true
            };
            t.Tick += T_Tick;

            Point startPostionShip = new Point(START_POSITION_SPATIALSHIP_X, START_POSITION_SPATIALSHIP_Y);
            Point speedShip = new Point(0, 0);
            spatialship = new Spatialship(startPostionShip, speedShip, Properties.Resources.cannon);
            KeyDown += spatialship.OnKeyDown;
            Paint += spatialship.Paint;

            Point startPostionInvader = new Point(0, 200);
            Point speedInvader = new Point(1, 0);
            invader = new Invader(startPostionInvader, speedInvader, Properties.Resources.invader);
            Paint += invader.Paint;

        }
        private void T_Tick(object sender, EventArgs e)
        {
            
            if (spatialship.Location.X > this.Width - spatialship.Image.Width)
            {
                spatialship.MooveLeft(3);
            }
            if (spatialship.Location.X < 0)
            {
                spatialship.MooveRight(3);
            }
            if (invader.Location.X >300)
            {
                invader.Dispose();
            }
            Invalidate();
           
        }
        /// <summary>
        /// Allows to consider directional arrows as Input key
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool IsInputKey(Keys keyData)
        {
            if (keyData == Keys.Up)
            {
                return true;
            }
            if (keyData == Keys.Down)
            {
                return true;
            }
            if (keyData == Keys.Right)
            {
                return true;
            }
            if (keyData == Keys.Left)
            {
                return true;
            }
            return base.IsInputKey(keyData);
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
