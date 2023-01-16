namespace ConsoleEngine.Input
{
    /// <summary>
    /// Classe gérant les Inputs dans la console
    /// </summary>
    public class InputHandler : GameObject
    {
        /// <summary>
        /// La dernière touche appuyée
        /// </summary>
        public static ConsoleKey Key { get; private set; }
        public static bool HasKey => Key != 0;

        public InputHandler(GameBase game) : base(game) { }

        public override void Update(GameBase game)
        {
            Key = 0;

            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo k = Console.ReadKey(true);
                Key = k.Key;
            }
        }
    }
}