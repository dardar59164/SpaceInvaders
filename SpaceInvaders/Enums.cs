namespace SnakeGameConsole
{
    public enum Direction
    {
        None,
        Left,
        Right
    }

    public static class DirectionExtension
    {
        public static Direction ToDirection(this ConsoleKey key)
        {
            Direction dir;
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                case ConsoleKey.Q:
                    dir = Direction.Left;
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    dir = Direction.Right;
                    break;
                default:
                    dir = Direction.None;
                    break;
            }
            return dir;
        }
    }
}