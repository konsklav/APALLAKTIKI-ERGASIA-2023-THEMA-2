using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace apallakttiki_ergasia_2023_thema_2
{
    public partial class Form3 : Form
    {
        Level level;
        Player player;
        Random r;
        int game_level;
        int time;
        string username;
        int score = 0;
        

        public Form3()
        {
            InitializeComponent();
        }
         
        public Form3(int game_level, string username)
        {
            InitializeComponent();
            this.game_level = game_level;
            this.username = username;
        }
 
        private void Form3_Load(object sender, EventArgs e)
        {
            if (game_level == 1)
            {
                level = new Level("Easy", 60, 1400, 100, 100, "easy.png", Color.LightSkyBlue);
            }
            else if(game_level == 2)
            {
                level = new Level("Medium", 45, 1200, 85, 85, "medium.png", Color.CornflowerBlue);
            }
            else if (game_level == 3)
            {
                level = new Level("Hard", 30, 1000, 70, 70, "hard.png", Color.RoyalBlue);
            }

            panel1.BackColor = level.color;
            timer1.Interval = level.interval;
            pictureBox1.Width = level.value_x;
            pictureBox1.Height = level.value_y;
            pictureBox1.ImageLocation = level.p.ImageLocation;
            this.time = level.time;
            r = new Random();
            label3.Text = "Username: " + username;
            label4.Text = level.PrintLevel();

            timer1.Enabled = true;
            timer2.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {   
            pictureBox1.Location = new Point(r.Next(panel1.Width - pictureBox1.Width), r.Next(panel1.Height - pictureBox1.Height));
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (time > 0)
            {
                label1.Text = "Time left: " + time--.ToString() + " seconds";
            }
            else
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                
                this.Hide();
                player = new Player(username, score);
                Form4 form4 = new Form4(player, level.level);
                form4.Show();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            score += 100;
            label2.Text = "Score: " + score.ToString();
        }
    }
}
