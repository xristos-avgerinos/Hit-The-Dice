using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hit_The_Dice
{
    public partial class Form3 : Form
    {
        int indexUser;
        int OnlineTime;
        public Form3(int i)
        {
            InitializeComponent();
            indexUser = i;
        }

        public Form3(int i,int onlinetime)
        {
            InitializeComponent();
            indexUser = i;
            OnlineTime = onlinetime;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            OnlineTime++;
            label2.Text = OnlineTime.ToString();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label4.Text = "1";
            label10.Text = Program.usersList[indexUser].HighscoreL1.ToString();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label4.Text = "2";
            label10.Text = Program.usersList[indexUser].HighscoreL2.ToString();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            label4.Text = "3";
            label10.Text = Program.usersList[indexUser].HighscoreL3.ToString();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Program.date_time_of_user != -1)
            {
                Program.usersList[Program.date_time_of_user].Lastlogin = Program.date_time;
                Program.date_time_of_user = -1;
            }
            this.Hide();
            Form1 form1 = new Form1();
            form1.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form4 form4 = new Form4(indexUser,label4.Text,OnlineTime);
            form4.ShowDialog();
            this.Close();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            
        }
        
        private void Form3_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            label9.Text = Program.usersList[indexUser].Lastlogin;
            label10.Text = Program.usersList[indexUser].HighscoreL1.ToString();
            label8.Text = Program.usersList[indexUser].Username;
        }
    }
}
