using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace apallakttiki_ergasia_2023_thema_2
{
    public partial class Form4 : Form
    {
        Player player;
        string level;

        String connectionString = "Data source=games.db;Version=3";
        SQLiteConnection connection;

        public Form4(Player player, string level)
        {
            InitializeComponent();

            this.player = player;
            this.level = level;

            connection = new SQLiteConnection(connectionString);

            connection.Open();
            String createSQL = "Create table if not exists Games(ID integer auto increment primary key,Usrnm Text,Level Text,Score integer)";
            SQLiteCommand command = new SQLiteCommand(createSQL, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            label2.Text = player.PrintScore();

            connection.Open();
            String insertSQL = "Insert into Games(Usrnm,Level,Score) values(@username,@level,@score)";
            SQLiteCommand command = new SQLiteCommand(insertSQL, connection);
            command.Parameters.AddWithValue("username", player.username);
            command.Parameters.AddWithValue("level", level);
            command.Parameters.AddWithValue("score", player.score);
            command.ExecuteNonQuery();
            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }
    }
}
