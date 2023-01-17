using ConsoleEngine;
using ConsoleEngine.Input;
using ConsoleEngine.Physics;
using SpaceInvaders;
using System;
using System.Linq;

namespace SpaceInvaders
{
    public class SpaceInvadersGame : GameBase
    {
        private SpaceshipObject _spaceship;
        private AlienObject[] _aliens;
        private LaserObject[] _lasers;

        public SpaceInvadersGame() : base(40, 20)
        {
            Framerate = 60;
            _spaceship = new SpaceshipObject(this,new Position(Width/2,Height/2));
            _aliens = new AlienObject[15];
            for (int i = 0; i < _aliens.Length; i++)
            {
                _aliens[i] = new AlienObject(this,new Position(1 + i,0));
            }
        }
    }
}