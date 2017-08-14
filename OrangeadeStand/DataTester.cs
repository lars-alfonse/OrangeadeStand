using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace OrangeadeStand
{
    public static class DataTester
    {
    static string connectionString = "SERVER = DESKTOP-2C737RL; DATABASE = OrangeadeStand; Trusted_Connection = true";
    static SqlConnection sqlconn = new SqlConnection(connectionString);
    public static void TestConnection()
        {
            using (sqlconn)
                try
                {
                    sqlconn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM SaveDATA", sqlconn);
                    int result = (int)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Failed Connection. Save Data will not be accessable during this game");
                }
                finally
                {
                    Console.WriteLine("Press Enter to Start");
                    Console.ReadLine();
                }
        }
    }
}
