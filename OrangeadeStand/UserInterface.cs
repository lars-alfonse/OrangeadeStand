﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeadeStand
{
    abstract class UserInterface
    {
        private string playerInput;

        public abstract void getUserInput();
    }
}
