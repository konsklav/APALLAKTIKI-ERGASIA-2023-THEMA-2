using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apallakttiki_ergasia_2023_thema_2
{
    public class Player
    {
        public string username;
        public int score;

        public Player(string username, int score)
        {
            this.username = username;
            this.score = score;
        }

        public string PrintScore()
        {
            string result = "Your Score: " + score.ToString();

            return result;
        }
    }
}
