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
            PhysicsHandler.SetPositions(this, Position);
        }

        public override void Update(GameBase game)
        {
            if (IsAlive)
            {
                //Move Laser
                PhysicsHandler.RemovePosition(this, Position);
                Position = new Position(Position.x, Position.y - 1);
                PhysicsHandler.SetPosition(this, Position);

                if (Position.y < 0)
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
                for (int i = 0; i < Height; i++)
                {
                    for (int j = 0; j < Width; j++)
                    {
                        graphics[Position.x + j, Position.y + i] = '|';
                    }
                }
            }
        }
        public void OnCollision(GameObject other)
        {
            if (other is AlienObject)
            {
                PhysicsHandler.RemovePosition(this,Position);
                other.IsActive = false;
                IsAlive = false;
                PhysicsHandler.RemovePosition(this, Position);
            }
        }
    }
}
