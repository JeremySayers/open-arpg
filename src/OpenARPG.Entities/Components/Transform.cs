using System.Numerics;

namespace OpenARPG.Entities.Components
{
    /// <summary>
    /// Component for position, rotation, and scale
    /// </summary>
    public class Transform
    {
        public Vector3 Position { get; set; }
        public Vector3 Rotation { get; set; }
        public Vector3 Scale { get; set; }

        public Transform()
        {
            Position = Vector3.Zero;
            Rotation = Vector3.Zero;
            Scale = Vector3.One;
        }

        public Transform(Vector3 position)
        {
            Position = position;
            Rotation = Vector3.Zero;
            Scale = Vector3.One;
        }
    }
}
