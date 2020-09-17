using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_BJ_Control
{
    class Invader : Sprite,IDisposable      
    {
        public Invader(Point startPosition, Point speed, Image image) : base(startPosition,speed, image)
        {
            //Do nothing
        }

        public void Dispose()
        {
            
        }
    }
}
