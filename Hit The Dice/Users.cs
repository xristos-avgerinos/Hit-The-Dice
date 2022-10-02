using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hit_The_Dice
{
    [Serializable]
    class Users
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int HighscoreL1 { get; set; }
        public int HighscoreL2 { get; set; }
        public int HighscoreL3 { get; set; }
        public string Lastlogin { get; set; }
        
        //δημιουργια constuctor περνωντας ως ορισματα τις ιδιοτητες του καθε ζωου επειδη ολα τα ζωα εχουν τις συγκεκριμενες ιδιοτητες
        public Users(string username, string password, int highscoreL1, int highscoreL2, int highscoreL3, string lastlogin)
        {
            this.Username = username;
            this.Password = password;
            this.HighscoreL1 = highscoreL1;
            this.HighscoreL2 = highscoreL2;
            this.HighscoreL3 = highscoreL3;
            this.Lastlogin = lastlogin;
        }
       
    }
}
