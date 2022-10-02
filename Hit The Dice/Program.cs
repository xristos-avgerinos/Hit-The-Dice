using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hit_The_Dice
{
    
    static class Program
    {
       
        public static List<Users> usersList = new List<Users>();
        public static string date_time;
        public static int date_time_of_user = -1;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream("file.txt", FileMode.Open, FileAccess.Read);
                usersList = (List<Users>)formatter.Deserialize(stream);
                stream.Close();
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            if (Application.OpenForms.Count == 0)
            {
                if(date_time_of_user != -1)
                {
                    usersList[date_time_of_user].Lastlogin = date_time;
                }
                try
                {
                    IFormatter formatter = new BinaryFormatter();
                    Stream stream = new FileStream("file.txt", FileMode.OpenOrCreate, FileAccess.Write);
                    formatter.Serialize(stream, usersList);
                    stream.Close();
                }
                catch (FileNotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (IOException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
