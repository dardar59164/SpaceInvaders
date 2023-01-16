namespace ConsoleEngine.Physics
{
    public class PhysicsHandler
    {
        /// <summary>
        /// La largeur de la zone de jeu
        /// </summary>
        protected int _width;
        /// <summary>
        /// La hauteur de la zone de jeu
        /// </summary>
        protected int _height;
        /// <summary>
        /// La grille des objets, chaque case contenant une référence vers le GameObject qui s'y trouve
        /// </summary>
        protected GameObject[,] _collisionMap;

        /// <summary>
        /// Une référence vers l'instance unique (Singleton) du PhysicsHandler
        /// </summary>
        protected static PhysicsHandler _instance;

        public PhysicsHandler(int width, int height)
        {
            _instance = this;

            _width = width;
            _height = height;

            _collisionMap = new GameObject[_width, _height];
        }

        /// <summary>
        /// Retire le GameObject passé à la position donnée. Si l'objet ne s'y trouves pas, ne fait rien. 
        /// </summary>
        /// <param name="gameObject">Le GameObject à retirer</param>
        /// <param name="position">La position à laquelle retirer le GameObject</param>
        public static void RemovePosition(GameObject gameObject, Position position)
        {
            if (_instance._collisionMap[position.x, position.y] == gameObject)
                _instance._collisionMap[position.x, position.y] = null;
        }

        /// <summary>
        /// Retire le GameObject passé à la position donnée. Si l'objet ne s'y trouves pas, ne fait rien. 
        /// </summary>
        /// <param name="gameObject">Le GameObject à retirer</param>
        /// <param name="positions">Les positions auxquelles retirer le GameObject</param>
        public static void RemovePositions(GameObject gameObject, params Position[] positions)
        {
            foreach (Position position in positions)
            {
                RemovePosition(gameObject, position);
            }
        }

        /// <summary>
        /// Place le GameObject donné à la position donnée. Si un objet s'y trouves deja,
        /// appelle la fonction OnCollision de l'objet passé et de l'objet collisionné, si l'interface existe.
        /// </summary>
        /// <param name="gameObject">Le GameObject à placer</param>
        /// <param name="position">La position à laquelle placer l'objet</param>
        public static void SetPosition(GameObject gameObject, Position position)
        {
            int x = position.x;
            int y = position.y;
            if (x < 0 || y < 0 || x >= _instance._width || y >= _instance._height)
            {
                return;
            }
            GameObject other = _instance._collisionMap[position.x, position.y];
            if (other != null)
            {
                if (other is ICollidable oc)
                    oc.OnCollision(gameObject);

                if (gameObject is ICollidable gc)
                    gc.OnCollision(other);
            }

            _instance._collisionMap[position.x, position.y] = gameObject;
        }

        /// <summary>
        /// Place le GameObject donné à la position donnée. Si un objet s'y trouves deja,
        /// appelle la fonction OnCollision de l'objet passé et de l'objet collisionné, si l'interface existe.
        /// </summary>
        /// <param name="gameObject">Le GameObject à placer</param>
        /// <param name="positions">Les positions auxquelles placer l'objet</param>
        public static void SetPositions(GameObject gameObject, params Position[] positions)
        {
            foreach (Position position in positions)
            {
                SetPosition(gameObject, position);
            }
        }

        /// <summary>
        /// Retourne vrai si un objet se trouve à la position donnée, et retourne le GameObject en question
        /// </summary>
        /// <param name="x">La position X à sonder</param>
        /// <param name="y">La position Y à sonder</param>
        /// <param name="gameObject">La valeur de retour contenant le GameObject à la position donnée, si il y en a un</param>
        /// <returns>Vrai si un objet est à la position donnée, faux sinon</returns>
        public static bool GetGameObjectAtPosition(int x, int y, out GameObject gameObject)
        {
            if (x < 0 || y < 0 || x >= _instance._width || y >= _instance._height)
            {
                gameObject = null;
                return true;
            }

            gameObject = _instance._collisionMap[x, y];
            return gameObject != null;
        }

        /// <summary>
        /// Retourne vrai si un objet se trouve à la position donnée, et retourne le GameObject en question
        /// </summary>
        /// <param name="pos">La position à sonder</param>
        /// <param name="gameObject">La valeur de retour contenant le GameObject à la position donnée, si il y en a un</param>
        /// <returns>Vrai si un objet est à la position donnée, faux sinon</returns>
        public static bool GetGameObjectAtPosition(Position pos, out GameObject gameObject)
        {
            return GetGameObjectAtPosition(pos.x, pos.y, out gameObject);
        }
    }
}
