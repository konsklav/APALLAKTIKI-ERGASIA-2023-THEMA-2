using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace apallakttiki_ergasia_2023_thema_2
{
    public class Level
    {
        public string level;
        public int time, interval;
        public int value_x, value_y;
        public PictureBox p;
        public Color color;

        public Level(string level, int time, int interval,int value_x, int value_y, string image, Color color)
        {
            this.time = time;
            this.level = level;
            this.interval = interval;   
            this.value_x = value_x; 
            this.value_y = value_y;
            p = new PictureBox();
            p.ImageLocation  = image;
            this.color = color;
        }

        public string PrintLevel()
        {
            string result = "Level: " + level;
            return result;
        }
    }
}
