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
        public bool IsAlive { get; set; }
        public LaserObject(GameBase game, Position position) : base(game)
        {
            IsAlive = true;
            IsActive = false;
            PhysicsHandler.SetPosition(this, Position);
        }

        public override void Update(GameBase game)
        {
            if (IsActive && Position.y >= 0)
            {
                //Move Laser
                Move(0, -1);

                if (Position.y <= 0 || Position.y >= GameBase.Height - 1)
                {
                    IsActive = false;
                    IsAlive = false;
                    PhysicsHandler.RemovePosition(this, Position);
                }
            }
        }

        public override void Display(ref char[,] graphics)
        {
            if (IsActive && IsAlive)
            {
                graphics[Position.x, Position.y] = '|';
            }
        }
        public void OnCollision(GameObject other)
        {
            if (other is AlienObject)
            {
                IsAlive = false;
                IsActive= false;
                PhysicsHandler.RemovePosition(this, Position);
            }
        }

        //Move Laser from Player
        public virtual void Shoot(int x, int y)
        {
            PhysicsHandler.RemovePosition(this, Position);
            Position = new Position(x, y-1);
            PhysicsHandler.SetPosition(this, Position);
            IsActive = true;
        }
        public void Move(int x, int y)
        {
            PhysicsHandler.RemovePosition(this, Position);
            Position = new Position(x, Position.y + y);
            PhysicsHandler.SetPosition(this, Position);
        }
    }
}
