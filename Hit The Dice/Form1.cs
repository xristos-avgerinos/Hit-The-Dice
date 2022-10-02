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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2();
            form2.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || (string.IsNullOrWhiteSpace(textBox2.Text)))
            {
                MessageBox.Show("Your username and password cannot be null or contain white spaces");
            }
            else
            {
                bool found = false;
                int i = 0;
                
                foreach (Users u in Program.usersList)
                {    
                    if (u.Username.Equals(textBox1.Text) && u.Password.Equals(textBox2.Text))
                    {
                        found = true;
                        break;
                    }
                  i++;
                }
                
                if (found == true)
                {
                    if(Program.date_time_of_user == -1)
                    {
                        Program.date_time = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
                        Program.date_time_of_user = i;
                    }
                    this.Hide();
                    Form3 form3 = new Form3(i);
                    form3.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Your account username or password is incorrect. Please try again.If you are new user please create an account.");
                }
            }
        }
    }
}
