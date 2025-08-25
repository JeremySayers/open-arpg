using System.Numerics;
using Raylib_cs;
using OpenARPG.Core;
using OpenARPG.Core.Input;
using OpenARPG.Core.States;
using OpenARPG.Entities;
using OpenARPG.Rendering;
using OpenARPG.Rendering.Camera;
using static Raylib_cs.Raylib;

namespace OpenARPG.States
{
    /// <summary>
    /// Gameplay state - handles the 3D game world
    /// </summary>
    public class GameplayState : IGameState
    {
        private readonly GameStateManager _stateManager;
        private readonly IGame _game;
        
        private Player _player = null!;
        private IsometricCamera _camera = null!;
        private ModelRenderer _modelRenderer;

        public GameplayState(GameStateManager stateManager, IGame game)
        {
            _stateManager = stateManager;
            _game = game;
            
            _modelRenderer = new ModelRenderer();
        }

        public void Enter()
        {
            // Initialize rendering systems
            _modelRenderer.Initialize();
            
            // Create the player at origin
            _player = new Player(new Vector3(0, 0, 0));
            
            // Set up the isometric camera
            _camera = new IsometricCamera();
            _camera.FollowTarget(_player.Transform.Position);
            
            Console.WriteLine("Entered gameplay state - 3D world loaded");
        }

        public void Exit()
        {
            _modelRenderer.Cleanup();
            Console.WriteLine("Exited gameplay state");
        }

        public void Update(float deltaTime)
        {
            // Handle state-level input (like returning to menu)
            if (InputManager.Instance.IsActionPressed(ActionType.Pause))
            {
                _stateManager.ChangeState("MainMenu");
                return;
            }

            // Update entities - they handle their own input/logic
            _player.Update(deltaTime);
            
            // Update camera to follow player
            _camera.FollowTarget(_player.Transform.Position);
        }

        public void Draw()
        {
            // Begin 3D mode
            BeginMode3D(_camera.RaylibCamera);

            // Draw a simple ground plane
            DrawPlane(Vector3.Zero, new Vector2(50, 50), Color.Gray);
            
            // Draw a grid for reference
            DrawGrid(20, 5.0f);

            // Render the player
            _modelRenderer.RenderEntity(_player);

            // End 3D mode
            EndMode3D();

            // Draw UI overlay
            DrawText("3D Gameplay State", 10, 10, 20, Color.White);
            DrawText("WASD to move, ESC to return to menu", 10, 40, 16, Color.LightGray);
            DrawText($"Player Position: {_player.Transform.Position:F1}", 10, 70, 16, Color.LightGray);
        }
    }
}
