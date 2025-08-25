using System.Numerics;

namespace OpenARPG.Entities.Components
{
    /// <summary>
    /// Component for entities that can move
    /// </summary>
    public class Movement
    {
        public float Speed { get; set; }
        public Vector3 Velocity { get; set; }
        public bool CanMove { get; set; }

        public Movement(float speed = 5.0f)
        {
            Speed = speed;
            Velocity = Vector3.Zero;
            CanMove = true;
        }

        /// <summary>
        /// Apply movement in a direction
        /// </summary>
        public void Move(Vector3 direction, float deltaTime, Transform transform)
        {
            if (!CanMove || direction == Vector3.Zero)
            {
                Velocity = Vector3.Zero;
                return;
            }

            // Calculate velocity
            Velocity = direction * Speed;
            
            // Apply movement to transform
            transform.Position += Velocity * deltaTime;
        }

        /// <summary>
        /// Stop all movement
        /// </summary>
        public void Stop()
        {
            Velocity = Vector3.Zero;
        }
    }
}
