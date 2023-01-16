﻿using ConsoleEngine;
using ConsoleEngine.Physics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SIGame game = new SIGame(40, 20);
            game.Run();
        }
    }
}