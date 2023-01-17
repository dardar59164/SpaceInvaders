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
        public AlienObject(GameBase game) : base(game)
        {
            IsAlive = true;
            Position = new Position(0,0);
            PhysicsHandler.SetPositions(this, Position);
        }

        public override void Update(GameBase game)
        {
            if (IsAlive)
            {
                //Move Alien
                PhysicsHandler.RemovePosition(this, Position);
                Position = new Position(Position.x, Position.y + 1);
                PhysicsHandler.SetPosition(this, Position);

                if (Position.y > 19)
                {
                    End();
                }
                Thread.Sleep(1000);
            }
        }

        public override void Display(ref char[,] graphics)
        {
            if (IsAlive)
            {
                for (int i = 0; i < 20; i++)
                {
                    for (int j = 0; j < 40; j++)
                    {
                        graphics[Position.x + j, Position.y + i] = 'A';
                    }
                }
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
            PhysicsHandler.RemovePosition(this, Position);
            Position = new Position(Position.x - 1, Position.y);
            PhysicsHandler.SetPosition(this, Position);
        }
    }
}
