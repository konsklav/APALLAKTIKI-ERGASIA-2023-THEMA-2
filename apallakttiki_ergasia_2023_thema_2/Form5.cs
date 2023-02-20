using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace apallakttiki_ergasia_2023_thema_2
{
    public partial class Form5 : Form
    {
        List<string> usernames = new List<string>();
        List<string> levels = new List<string>();
        List<int> scores = new List<int>();
        String connectionString = "Data source=games.db;Version=3";
        SQLiteConnection connection;

        public Form5()
        {
            InitializeComponent();
            connection = new SQLiteConnection(connectionString);
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            connection.Open();
            String selectSQL = "Select * from Games";
            SQLiteCommand command = new SQLiteCommand(selectSQL, connection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                usernames.Add(reader.GetString(1));
                levels.Add(reader.GetString(2));
                scores.Add(reader.GetInt32(3));
            }
            connection.Close();

            for (int i = 0; i < scores.Count - 1; i++)
            {
                for (int j = 0; j < scores.Count - i - 1; j++)
                {
                    if (scores[j] < scores[j+1])
                    { 
                        int tmp_score = scores[j];
                        scores[j] = scores[j+1];
                        scores[j+1] = tmp_score;

                        string tmp_username = usernames[j];
                        usernames[j] = usernames[j+1];
                        usernames[j+1] = tmp_username;

                        string tmp_level = levels[j];
                        levels[j] = levels[j + 1];
                        levels[j + 1] = tmp_level;
                    }
                }           
            }

            int count = 0;

            if(scores.Count < 10)
            {
                count = scores.Count;
            }
            else
            {
                count = 10;
            }

            for (int i = 0; i < count; i++)
            {
                richTextBox1.Text += (i + 1).ToString() + ") Username: " + usernames[i] + ", Score: " + scores[i].ToString() + ", Level: " + levels[i] + "\r\n"; 
            }

            int easy = 0;
            int medium = 0;
            int hard = 0;

            string easy_usrnm = "";
            string medium_usrnm = "";
            string hard_usrnm = "";

            for (int i = 0; i < scores.Count; i++)
            {
                if (scores[i] > hard && levels[i] == "Hard")
                {
                    hard = scores[i];
                    hard_usrnm = usernames[i];
                }
                else if (scores[i] > medium && levels[i] == "Medium")
                {
                    medium = scores[i];
                    medium_usrnm = usernames[i];
                }
                else if (scores[i] > easy && levels[i] == "Easy")
                {
                    easy = scores[i];
                    easy_usrnm = usernames[i];
                }
            }

            richTextBox2.Text = "Easy: " + easy.ToString() + " (" + easy_usrnm + ")" + "\r\nMedium: " + medium.ToString() + " (" + medium_usrnm + ")" + "\r\nHard: " + hard.ToString() + " (" + hard_usrnm + ")";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }
    }
}
