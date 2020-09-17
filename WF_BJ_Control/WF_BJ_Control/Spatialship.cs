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
        const int SPEED_SPATIALSHIP = 3;
        
        public Spatialship(Point startPosition,Point speed, Image image) : base (startPosition,speed, image)
        {
            //Do nothing
        }
        public void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                MooveLeft(SPEED_SPATIALSHIP);
            } 
            if (e.KeyCode == Keys.Right)
            {
                MooveRight(SPEED_SPATIALSHIP);
            }
        }
    }
}
