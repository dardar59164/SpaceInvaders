using ConsoleEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    internal class SIGame : GameBase
    {
        public SIGame(int width, int height) : base(width, height)
        {
            Framerate = 60;
        }
    }
}
