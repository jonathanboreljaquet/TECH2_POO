﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Remoting.Channels;
using System.Windows.Forms;

namespace WF_Control
{
    class Scene : Control
    {
        private const int FPS = 60;
        private const int START_POSITION_X = 400;
        private const int START_POSITION_Y = 200;
        private const int MINIMUM_SIZE = 5;
        private const int MAXIMUM_SIZE = 8;
        private const int MINIMUM_SPEED = -100;
        private const int MAXIMUM_SPEED = 100;

        private Bitmap bitmap = null;
        private Graphics g = null;
        private readonly Sprite sprite = null;
        private Timer t;

        private readonly List<Sprite> particles;
        private readonly Random rnd;

        public Scene() : base()
        {          
            rnd = new Random();
            particles = new List<Sprite>();
            DoubleBuffered = true;
            t = new Timer
            {
                Interval = 1000/ FPS,
                Enabled = true
            };
            t.Tick += T_Tick;

            for (int i = 0; i < 500; i++)
            {
                Point startPostion = new Point(START_POSITION_X, START_POSITION_Y);
                Point speed = new Point(rnd.Next(MINIMUM_SPEED, MAXIMUM_SPEED), rnd.Next(MINIMUM_SPEED, MAXIMUM_SPEED));
                int randomSize = rnd.Next(MINIMUM_SIZE, MAXIMUM_SIZE);
                Size size = new Size(randomSize, randomSize);
                sprite = new Sprite(startPostion,size,speed);
                particles.Add(sprite);
                Paint += sprite.Paint;
            }
            
            
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
