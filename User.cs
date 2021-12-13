using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace BlappyFirb
{
    class User
    {
        public int difficulty { get; set; }
        public string nickname { get; set; }
        public int highScore { get; set; }
        public User(string nickname, int highScore, int difficulty)
        {
            this.nickname = nickname;
            this.highScore = highScore;
            this.difficulty = difficulty;
        }
    }
}
