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
            DataTester.TestConnection();
            Game game = new Game();
            game.RunGame();
        }
    }
}
