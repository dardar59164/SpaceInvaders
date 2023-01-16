namespace ConsoleEngine.Physics
{
    /// <summary>
    /// Interface pour les objets nécessitant un callback lors d'une collision
    /// </summary>
    public interface ICollidable
    {
        /// <summary>
        /// Fonction appellée lorsque le GameObject implémentant l'intreface entre en collision avec un autre GameObject
        /// </summary>
        /// <param name="other"></param>
        public void OnCollision(GameObject other);
    }
}
