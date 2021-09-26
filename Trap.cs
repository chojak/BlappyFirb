using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Media;

namespace BlappyFirb
{
    class Trap
    {
        public int XPosition;
        public int UpperPosition { get; private set; }
        public int DownPosition { get; private set; }
        public Rectangle UpperTrap { get; private set; }
        public Rectangle DownTrap { get; private set; }

        Random rand;

        public Trap()
        {
            rand = new Random();
            UpperTrap = new Rectangle();
            DownTrap = new Rectangle();

            XPosition = 900;
            UpperPosition = rand.Next(50, 330);
            DownPosition = UpperPosition + 120;

            UpperTrap.Fill = Brushes.Green;
            UpperTrap.Width = 50;
            UpperTrap.Height = UpperPosition;

            DownTrap.Fill = Brushes.Green;
            DownTrap.Width = 50;
            DownTrap.Height = 500 - DownPosition;
        }
        public void Move()
        {
            XPosition -= 5;
        }
    }
}
