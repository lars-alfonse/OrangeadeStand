using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeadeStand
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTester.TestConnection();
            Game game = new Game();
            game.RunGame();
        }
    }
}
