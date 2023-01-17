using ConsoleEngine.Input;
using ConsoleEngine.Physics;
using ConsoleEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    public class SpaceshipObject : GameObject, ICollidable
    {
        public int Lives { get; set; } = 3;
        public Position Position { get; set; }

        public SpaceshipObject(GameBase game, Position position) : base(game)
        {
            Position = position;
            PhysicsHandler.SetPosition(this, Position);
        }

        public override void Update(GameBase game)
        {
            // Movement handling
            if ((InputHandler.Key == ConsoleKey.LeftArrow) && Position.x - 1 > 0)
            {
                Move(Position.x - 1, Position.y);
            }
            if ((InputHandler.Key == ConsoleKey.RightArrow) && Position.x + 1 < 40)
            {
                Move(Position.x + 1, Position.y);
            }
            // shooting handling
            if (InputHandler.Key == ConsoleKey.Spacebar)
            {
                new LaserObject(game, new Position(Position.x,Position.y - 1));
            }
        }

        public override void Display(ref char[,] graphics)
        {
            graphics[Position.x, Position.y] = '^';
            graphics[Position.x - 1, Position.y] = '<';
            graphics[Position.x + 1, Position.y] = '>';
        }

        public void OnCollision(GameObject other)
        {
            if (other is AlienObject)
            {
                Lives--;
                if (Lives == 0)
                {
                    IsActive = false;
                    Console.Clear();
                    Console.WriteLine("Game Over");
                }
            }
        }

        public void Move(int x, int y)
        {
            PhysicsHandler.RemovePosition(this, Position);
            Position = new Position(Position.x + x, Position.y + y);
            PhysicsHandler.SetPosition(this, Position);
        }
    }
}
