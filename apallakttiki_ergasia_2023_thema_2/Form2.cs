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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace apallakttiki_ergasia_2023_thema_2
{
    public partial class Form2 : Form
    {
        int level;
        string username;

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                username = textBox1.Text;

                if (checkBox1.Checked == true)
                {
                    level = 1;
                    this.Hide();
                    Form3 form3 = new Form3(level, username);
                    form3.Show();
                }
                else if (checkBox2.Checked == true)
                {
                    level = 2;
                    this.Hide();
                    Form3 form3 = new Form3(level, username);
                    form3.Show();
                }
                else if (checkBox3.Checked == true)
                {
                    level = 3;
                    this.Hide();
                    Form3 form3 = new Form3(level, username);
                    form3.Show();
                }
                else
                {
                    MessageBox.Show("Please select a difficulty level!");
                }
            }
            else
            {
                MessageBox.Show("Please enter a username!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                checkBox2.Checked = false;
                checkBox3.Checked = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                checkBox1.Checked = false;
                checkBox3.Checked = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
            }
        }
    }
}
