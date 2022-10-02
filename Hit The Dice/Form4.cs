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
    
    public partial class Form4 : Form
    {
        Random random;
        int countDown = 90;
        int randomImage;
        int sum_of_dice;

        string level;
        int indexUser;
        int OnlineTime;
        TimeSpan t;
        public Form4(int i,string lv,int onlinetime)
        {
            InitializeComponent();
            indexUser = i;
            level = lv;
            OnlineTime = onlinetime;
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            

            
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            t = (DateTime.UtcNow - new DateTime(1970, 1, 1));
            random = new Random();
            label13.Text = level;
            label7.Text = Program.usersList[indexUser].Username;
            
            switch (Int32.Parse(level))
            {
                case 1:
                    timer1.Interval = 1000;
                    int topscore1 = Program.usersList[0].HighscoreL1;
                    string topUser1 = Program.usersList[0].Username;
                    foreach (Users u in Program.usersList)
                    {//κανει εναν περιττο ελεγχο
                        if (u.HighscoreL1 > topscore1)
                        {
                            topscore1 = u.HighscoreL1;
                            topUser1 = u.Username;
                        }
                    }
                    label14.Text = topscore1.ToString();
                    label11.Text = topUser1;
                    label8.Text = Program.usersList[indexUser].HighscoreL1.ToString();
                    break;
                case 2:
                    timer1.Interval = 750;
                    int topscore2 = Program.usersList[0].HighscoreL2;
                    string topUser2 = Program.usersList[0].Username;
                    foreach (Users u in Program.usersList)
                    {//κανει εναν περιττο ελεγχο
                        if (u.HighscoreL2 > topscore2)
                        {
                            topscore2 = u.HighscoreL2;
                            topUser2 = u.Username;
                        }
                    }
                    label14.Text = topscore2.ToString();
                    label11.Text = topUser2;
                    label8.Text = Program.usersList[indexUser].HighscoreL2.ToString();
                    break;
                case 3:
                    timer1.Interval = 600;
                    int topscore3 = Program.usersList[0].HighscoreL3;
                    string topUser3 = Program.usersList[0].Username;
                    foreach (Users u in Program.usersList)
                    {//κανει εναν περιττο ελεγχο
                        if (u.HighscoreL3 > topscore3)
                        {
                            topscore3 = u.HighscoreL3;
                            topUser3 = u.Username;
                        }
                    }
                    label14.Text = topscore3.ToString();
                    label11.Text = topUser3;
                    label8.Text = Program.usersList[indexUser].HighscoreL3.ToString();
                    break;
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer2.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            randomImage = random.Next(1, 7);
            pictureBox1.ImageLocation = "Dice-" + randomImage.ToString() + ".png";
            int x1, y1;
            x1 = random.Next(panel1.Width - pictureBox1.Width);
            y1 = random.Next(panel1.Height - pictureBox1.Height);
            pictureBox1.Location = new Point(x1, y1);
            if (countDown == 0)
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                pictureBox1.Enabled = false;
                MessageBox.Show("game over!");
                switch (Int32.Parse(level))
                {
                    case 1:
                        if (sum_of_dice > Program.usersList[indexUser].HighscoreL1)
                        {
                            Program.usersList[indexUser].HighscoreL1 = sum_of_dice;
                        }
                        break;
                    case 2:
                        if (sum_of_dice > Program.usersList[indexUser].HighscoreL2)
                        {
                            Program.usersList[indexUser].HighscoreL2 = sum_of_dice;
                        }
                        break;
                    case 3:
                        if (sum_of_dice > Program.usersList[indexUser].HighscoreL3)
                        {
                            Program.usersList[indexUser].HighscoreL3 = sum_of_dice;
                        }
                        break;
                }

                this.Hide();
                TimeSpan tt = (DateTime.UtcNow - new DateTime(1970, 1, 1));
                int ttt = (int)(tt - t).TotalSeconds;
                Form3 form3 = new Form3(indexUser,OnlineTime + ttt);
                form3.ShowDialog();
                this.Close();
                

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            sum_of_dice += randomImage;
            label4.Text = sum_of_dice.ToString();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            countDown--;
            label3.Text = countDown.ToString();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("The purpose of the game is to hit(press) the dice as many times as you can within one and a half minutes. " +
                  "The dice digit will be added to your total score");
        }
    }
}
