using OpenARPG.Entities.Components;

namespace OpenARPG.Entities
{
    /// <summary>
    /// Base class for all game entities
    /// </summary>
    public abstract class Entity
    {
        public Transform Transform { get; protected set; }
        public Renderable? Renderable { get; protected set; }

        protected Entity()
        {
            Transform = new Transform();
        }

        /// <summary>
        /// Update the entity
        /// </summary>
        /// <param name="deltaTime">Time since last frame</param>
        public virtual void Update(float deltaTime)
        {
            // Base implementation - override in derived classes
        }
    }
}
