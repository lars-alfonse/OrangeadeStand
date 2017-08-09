using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeadeStand
{
    abstract class UserInterface
    {
        private string playerInput;
        protected List<string> userOptions;
        protected Game game = new Game();

        public string PlayerInput
        {
            get
            {
                return playerInput;
            }
            set
            {
                if(value == "help" || value == "Help")
                {
                    GetHelp();
                    playerInput = "reset";
                }
                playerInput = value;
            }
        }
        protected abstract void GetUserInput();
        protected void GetHelp()
        {
            Console.WriteLine("Any command can be inputed as it's number, full name, or in the case of multiple words, you are allowed to enter the first word. \n");
        }
    }
}
