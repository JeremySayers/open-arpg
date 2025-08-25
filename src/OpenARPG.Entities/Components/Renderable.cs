using Raylib_cs;

namespace OpenARPG.Entities.Components
{
    /// <summary>
    /// Component for entities that can be rendered in 3D
    /// </summary>
    public class Renderable
    {
        public Model? Model { get; set; }
        public string? ModelPath { get; set; }
        public Color Tint { get; set; }
        public bool IsVisible { get; set; }

        public Renderable()
        {
            Tint = Color.White;
            IsVisible = true;
        }

        public Renderable(string modelPath) : this()
        {
            ModelPath = modelPath;
        }
    }
}
