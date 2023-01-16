namespace ConsoleEngine
{
    /// <summary>
    /// Classe de base pour tout objet existant dans le jeu
    /// </summary>
    public class GameObject
    {
        /// <summary>
        /// Est-ce que l'objet est actif dans le jeu?
        /// </summary>
        public virtual bool IsActive { get; set; } = true;
        /// <summary>
        /// Est-ce que l'objet est visible dans le jeu?
        /// </summary>
        public virtual bool IsVisible { get; set; } = true;

        public GameObject(GameBase game)
        {
            //Chaque GameObject s'enregistre auprès du jeu
            game.RegisterGameObject(this);
        }

        /// <summary>
        /// Appelé une fois par "frame"
        /// </summary>
        /// <param name="game"></param>
        public virtual void Update(GameBase game) { }

        /// <summary>
        /// Définit comment afficher l'objet
        /// </summary>
        /// <param name="graphics"></param>
        public virtual void Display(ref char[,] graphics) { }
    }
}
