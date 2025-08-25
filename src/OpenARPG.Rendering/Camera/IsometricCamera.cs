using System.Numerics;
using Raylib_cs;

namespace OpenARPG.Rendering.Camera
{
    /// <summary>
    /// Isometric camera for Diablo-style gameplay
    /// </summary>
    public class IsometricCamera
    {
        private Camera3D _camera;
        private Vector3 _targetPosition;
        private float _distance;
        private float _height;

        public Camera3D RaylibCamera => _camera;
        public Vector3 TargetPosition 
        { 
            get => _targetPosition; 
            set 
            { 
                _targetPosition = value;
                UpdateCameraPosition();
            }
        }

        public IsometricCamera()
        {
            _distance = 15.0f;
            _height = 10.0f;
            _targetPosition = Vector3.Zero;

            _camera = new Camera3D();
            _camera.Target = Vector3.Zero;
            _camera.Up = new Vector3(0.0f, 1.0f, 0.0f);
            _camera.FovY = 45.0f;
            _camera.Projection = CameraProjection.Perspective;

            UpdateCameraPosition();
        }

        /// <summary>
        /// Follow a target position (like the player)
        /// </summary>
        public void FollowTarget(Vector3 targetPosition)
        {
            TargetPosition = targetPosition;
        }

        /// <summary>
        /// Update camera position based on target
        /// </summary>
        private void UpdateCameraPosition()
        {
            // Isometric angle: camera looks down at 45-degree angle
            // Position the camera diagonally above and behind the target
            var offset = new Vector3(_distance * 0.7f, _height, _distance * 0.7f);
            _camera.Position = _targetPosition + offset;
            _camera.Target = _targetPosition;
        }

        /// <summary>
        /// Set camera distance from target
        /// </summary>
        public void SetDistance(float distance)
        {
            _distance = distance;
            UpdateCameraPosition();
        }

        /// <summary>
        /// Set camera height above target
        /// </summary>
        public void SetHeight(float height)
        {
            _height = height;
            UpdateCameraPosition();
        }
    }
}
