using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace OrangeadeStand
{
    class Program
    {
        static string connectionString = "SERVER = DESKTOP-2C737RL; DATABASE = OrangeadeStand; Trusted_Connection = true";
        static SqlConnection sqlconn = new SqlConnection(connectionString);
        static void Main(string[] args)
        {
            using (sqlconn)
                try
                {
                    sqlconn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM SaveDATA", sqlconn);
                    int result = (int)cmd.ExecuteScalar();
                    Console.WriteLine(result);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Failled Connection. Save Data will not be accessable during this game");
                }
                finally
                {
                    Console.WriteLine("Press Enter to Start");
                    Console.ReadLine();
                }

            Game game = new Game();
            game.RunGame();
        }
    }
}
