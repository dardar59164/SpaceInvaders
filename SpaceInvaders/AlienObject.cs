using ConsoleEngine.Physics;
using ConsoleEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    public class AlienObject : GameObject, ICollidable
    {
        public Position Position { get; private set; }
        public bool IsAlive { get; set; }
        public AlienObject(GameBase game, Position position) : base(game)
        {
            IsAlive = true;
            Position = position;
            PhysicsHandler.SetPosition(this, Position);
        }

        public override void Update(GameBase game)
        {
            if (IsAlive && GameBase.FrameCount % 30 == 0)
            {
                //Move Alien
                Move();

                if (Position.y >= 19)
                {
                    End();
                }
            }
        }

        public override void Display(ref char[,] graphics)
        {
            if (IsAlive)
            {
                graphics[Position.x, Position.y] = 'A';
            }
        }

        public void OnCollision(GameObject other)
        {
            if (other is SpaceshipObject)
            {
                IsAlive = false;
                PhysicsHandler.RemovePosition(this, Position);
            }
        }

        public static void End()
        {
            GameBase.End();
        }

        public void Move()
        {
            if (IsAlive && Position.x >= GameBase.Width - 1)
            {
                PhysicsHandler.RemovePosition(this, Position);
                Position = new Position(1, Position.y + 1);
                PhysicsHandler.SetPosition(this, Position);
            }
            else
            {
                PhysicsHandler.RemovePosition(this, Position);
                Position = new Position(Position.x + 1, Position.y);
                PhysicsHandler.SetPosition(this, Position);
            }
            
        }
    }
}
