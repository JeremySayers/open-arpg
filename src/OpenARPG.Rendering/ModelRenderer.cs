using System.Numerics;
using Raylib_cs;
using OpenARPG.Entities;
using OpenARPG.Entities.Components;
using static Raylib_cs.Raylib;

namespace OpenARPG.Rendering
{
    /// <summary>
    /// Handles rendering of 3D models for entities
    /// </summary>
    public class ModelRenderer
    {
        private Model _cubeModel;
        private bool _initialized = false;

        public void Initialize()
        {
            if (_initialized) return;

            // Create a simple cube mesh for testing
            _cubeModel = LoadModelFromMesh(GenMeshCube(2.0f, 2.0f, 2.0f));
            _initialized = true;
        }

        public void Cleanup()
        {
            if (_initialized)
            {
                UnloadModel(_cubeModel);
                _initialized = false;
            }
        }

        /// <summary>
        /// Render an entity with a 3D model
        /// </summary>
        public void RenderEntity(Entity entity)
        {
            if (!_initialized || entity.Renderable == null || !entity.Renderable.IsVisible)
                return;

            var transform = entity.Transform;
            var renderable = entity.Renderable;

            // Use the entity's model if available, otherwise use default cube
            var modelToRender = renderable.Model ?? _cubeModel;

            // Convert transform to Raylib format
            var position = transform.Position;
            var rotation = transform.Rotation;
            var scale = transform.Scale.X; // Use X component for uniform scaling

            // Draw the model
            DrawModelEx(modelToRender, position, new Vector3(0, 1, 0), rotation.Y, 
                       new Vector3(scale, scale, scale), renderable.Tint);
        }

        /// <summary>
        /// Render multiple entities
        /// </summary>
        public void RenderEntities(IEnumerable<Entity> entities)
        {
            foreach (var entity in entities)
            {
                RenderEntity(entity);
            }
        }
    }
}
