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
            _spaceship = new SpaceshipObject(this,new Position(20,10));
            _aliens = new AlienObject[10];
            for (int i = 0; i < _aliens.Length; i++)
            {
                _aliens[i] = new AlienObject(this);
            }
            _lasers = new LaserObject[5];
            for (int i = 0; i < _lasers.Length; i++)
            {
                //_lasers[i] = new LaserObject(this, );
            }
        }

        protected override void Update()
        {
            // Move the spaceship
            if (InputHandler.Key == ConsoleKey.LeftArrow)
            {
                _spaceship.Move(-1, 0);
            }
            else if (InputHandler.Key == ConsoleKey.RightArrow)
            {
                _spaceship.Move(1, 0);
            }
            // Fire a laser
            else if (InputHandler.Key == ConsoleKey.Spacebar)
            {
                //_spaceship.FireLaser();
            }

            // Move the aliens
            foreach (AlienObject alien in _aliens)
            {
                alien.Move();
            }

            // Move the lasers
            foreach (LaserObject laser in _lasers)
            {
                //laser.Move();
            }
        }
    }
}