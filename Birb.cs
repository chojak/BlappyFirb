using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace BlappyFirb
{
    public class Birb
    {
        public int YPosition { get; private set; }
        public int XPosition;
        public Rectangle Rectangle { get; private set; }
        int gravitySpeed;
        public Birb(int size, int XPosition, int YPosition)
        {   
            this.YPosition = YPosition;
            this.XPosition = XPosition;
            Rectangle = new Rectangle();
            Rectangle.Fill = Brushes.Red;
            Rectangle.Width = size;
            Rectangle.Height = size;
        }
        public void Jump()
        {
            gravitySpeed = -10;
        }
        public void Fly()
        {
            if (YPosition < -20)
                YPosition = -20;
            else
                YPosition += gravitySpeed;

            if(gravitySpeed < 20)
                gravitySpeed += 1;
        }
    }
}
