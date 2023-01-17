using ConsoleEngine.Input;
using ConsoleEngine.Physics;

namespace ConsoleEngine
{
    public abstract class GameBase
    {
        /// <summary>
        /// Définit le caractère par défaut à l'écran. Peut être écrasé
        /// </summary>
        protected char Blank = ' ';
        /// <summary>
        /// Définit la fréquence du jeu en image par seconde. Peut être écrasé
        /// </summary>
        public int Framerate { get; protected set; } = 60;

        /// <summary>
        /// Indique si le jeu est en cours, ou s'il doit s'arrêter
        /// </summary>
        protected static bool IsRunning { get; private set; } = true;
        /// <summary>
        /// La largeur de la zone d'affichage
        /// </summary>
        public static int Width { get; private set; }
        /// <summary>
        /// La hauteur de la zone d'affichage
        /// </summary>
        public static int Height { get; private set; }

        public static int FrameCount { get; private set; } = 0;

        /// <summary>
        /// Le tableau à deux dimensions contenant l'ensemble des caractères à afficher dans la console
        /// </summary>
        protected char[,] _graphics;
        /// <summary>
        /// La liste des GameObject contenus dans le jeu
        /// </summary>
        protected List<GameObject> _gameObjects = new();
        /// <summary>
        /// L'instance de l'objet gérant les collisions
        /// </summary>
        protected PhysicsHandler _physics;
        /// <summary>
        /// L'instance de l'objet gérant les Inputs
        /// </summary>
        protected InputHandler _input;

        public GameBase(int width, int height)
        {
            Console.CursorVisible = false;
            Width = width;
            Height = height;
            _graphics = new char[Width, Height];
            ClearBuffer();

            _physics = new(Width, Height);

            _input = new InputHandler(this);
        }

        /// <summary>
        /// Fonction à appeler pour lancer le jeu
        /// </summary>
        public void Run()
        {
            while (IsRunning)
            {
                Update();
                Draw();
                Thread.Sleep(1000 / Framerate);
            }
        }

        /// <summary>
        /// Arrête le jeu
        /// </summary>
        public static void End()
        {
            IsRunning = false;
        }

        /// <summary>
        /// Enregistre dans le jeu le GameObject passé en paramètre
        /// </summary>
        /// <param name="gameObject"></param>
        public void RegisterGameObject(GameObject gameObject)
        {
            _gameObjects.Add(gameObject);
        }

        /// <summary>
        /// Update tous les GameObject actifs, et affiche les GameObject visibles dans l'objet _graphics
        /// </summary>
        protected virtual void Update()
        {
            foreach (GameObject gameObject in _gameObjects)
            {
                if (gameObject.IsActive)
                {
                    gameObject.Update(this);
                }
            }

            //La touche Escape arrête automatiquement le jeu
            if (InputHandler.Key == ConsoleKey.Escape)
                End();

            FrameCount++;
        }

        /// <summary>
        /// Affiche le contenu de l'objet _graphics dans la console, puis le vide
        /// </summary>
        protected virtual void Draw()
        {
            ClearScreen();
            foreach (GameObject gameObject in _gameObjects)
            {
                if (gameObject.IsActive && gameObject.IsVisible)
                {
                    gameObject.Display(ref _graphics);
                }
            }

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Console.Write(_graphics[j, i]);
                }
                Console.WriteLine();
            }

            ClearBuffer();
        }

        /// <summary>
        /// réinitialise la position du curseur
        /// </summary>
        private static void ClearScreen()
        {
            Console.SetCursorPosition(0, 0);
        }

        /// <summary>
        /// Remet tous les caractères dans _graphics au caractère vide
        /// </summary>
        private void ClearBuffer()
        {
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    _graphics[i, j] = Blank;
                }
            }
        }
    }
}
