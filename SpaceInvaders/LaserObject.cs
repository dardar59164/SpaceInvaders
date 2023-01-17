using ConsoleEngine.Physics;
using ConsoleEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    public class LaserObject : GameObject, ICollidable
    {
        public Position Position { get; private set; }
        public int Width { get; }
        public int Height { get; }
        public bool IsAlive { get; set; }
        public LaserObject(GameBase game, Position position) : base(game)
        {
            IsAlive = true;
            PhysicsHandler.SetPosition(this, Position);
        }

        public override void Update(GameBase game)
        {
            if (IsAlive)
            {
                //Move Laser
                Shoot(Position.x, Position.y);

                if (Position.y <= 0)
                {
                    IsAlive = false;
                    PhysicsHandler.RemovePosition(this, Position);
                }
            }
        }

        public override void Display(ref char[,] graphics)
        {
            if (IsAlive)
            {
                graphics[Position.x, Position.y] = '|';
            }
        }
        public void OnCollision(GameObject other)
        {
            if (other is AlienObject)
            {
                IsAlive = false;
                PhysicsHandler.RemovePosition(this, Position);
            }
        }

        //Move Laser from Player
        public virtual void Shoot(int x, int y)
        {
            if (IsAlive)
            {
                PhysicsHandler.RemovePosition(this, Position);
                Position = new Position(x, Position.y - 1);
                PhysicsHandler.SetPosition(this, Position);
            }
        }
    }
}
