using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hit_The_Dice
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || (string.IsNullOrWhiteSpace(textBox2.Text)))
            {
                MessageBox.Show("Username and password cannot be null or contain white spaces");
            }
            else
            {
                if ((textBox1.Text.Length < 6) || (textBox2.Text.Length < 6))
                {
                    MessageBox.Show("Username and password must be at least 6 characters.");
                }
                else
                {
                    Users u = new Users(textBox1.Text, textBox2.Text, 0, 0, 0, DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString());
                    Program.usersList.Add(u);
                    MessageBox.Show("Congratulations.You are now a user of: Hit The Dice.Please sign in to your new account now.");
                    this.Hide();
                    Form1 form1 = new Form1();
                    form1.ShowDialog();
                    this.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.ShowDialog();
            this.Close();
        }
    }
}
