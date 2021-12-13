using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Controls;

namespace BlappyFirb
{
    class Trap
    {
        public int XPosition;
        public int UpperPosition { get; private set; }
        public int DownPosition { get; private set; }
        public Image UpperTrap { get; private set; }
        public Image DownTrap { get; private set; }

        Random rand;

        public Trap(int difficulty)
        {
            rand = new Random();
            UpperTrap = new Image();
            DownTrap = new Image();
            var gap = difficulty == 0 ? 150 : difficulty == 1 ? 100 : difficulty == 2 ? 80 : 150;

            XPosition = 900;
            UpperPosition = rand.Next(-200, -20);

            UpperTrap.Source = new BitmapImage(new Uri("assets/pipe.png", UriKind.Relative));
            UpperTrap.RenderTransformOrigin = new System.Windows.Point(0.5, 0.5);
            UpperTrap.RenderTransform = new RotateTransform(180);
            UpperTrap.Width = 80;
            UpperTrap.Height = 350;
            UpperTrap.Stretch = Stretch.Fill;

            DownPosition = UpperPosition + 300 + gap;
            DownTrap.Source = new BitmapImage(new Uri("assets/pipe.png", UriKind.Relative));
            DownTrap.Width = 80;
            DownTrap.Height = 350;
            UpperTrap.Stretch = Stretch.Fill;

        }
        public void Move()
        {
            XPosition -= 5;
        }
    }
}
