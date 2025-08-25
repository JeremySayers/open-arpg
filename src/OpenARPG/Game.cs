using Raylib_cs;
using OpenARPG.Core;
using OpenARPG.Core.States;
using OpenARPG.States;
using static Raylib_cs.Raylib;

namespace OpenARPG
{
    /// <summary>
    /// Main game class that manages the game loop and state management
    /// </summary>
    public class Game : IGame
    {
        private const int ScreenWidth = 800;
        private const int ScreenHeight = 480;
        private const int TargetFPS = 60;

        private readonly GameStateManager _stateManager;
        private bool _isRunning;

        public Game()
        {
            _stateManager = new GameStateManager();
            _isRunning = false;
        }

        /// <summary>
        /// Initialize the game window and register states
        /// </summary>
        public void Initialize()
        {
            InitWindow(ScreenWidth, ScreenHeight, "OpenARPG");
            SetTargetFPS(TargetFPS);

            // Register game states
            RegisterStates();

            // Start with main menu
            _stateManager.ChangeState("MainMenu");
            _isRunning = true;
        }

        /// <summary>
        /// Register all game states
        /// </summary>
        private void RegisterStates()
        {
            _stateManager.RegisterState("MainMenu", new MainMenuState(_stateManager, this));
            _stateManager.RegisterState("Gameplay", new GameplayState(_stateManager, this));
            // Future states can be registered here
            // _stateManager.RegisterState("Pause", new PauseState(_stateManager));
        }

        /// <summary>
        /// Main game loop
        /// </summary>
        public void Run()
        {
            while (_isRunning && !WindowShouldClose())
            {
                float deltaTime = GetFrameTime();
                
                Update(deltaTime);
                Draw();
            }

            Shutdown();
        }

        /// <summary>
        /// Update game logic
        /// </summary>
        private void Update(float deltaTime)
        {
            _stateManager.Update(deltaTime);
        }

        /// <summary>
        /// Render the game
        /// </summary>
        private void Draw()
        {
            BeginDrawing();
            ClearBackground(Color.DarkBlue);

            _stateManager.Draw();

            EndDrawing();
        }

        /// <summary>
        /// Cleanup and shutdown
        /// </summary>
        private void Shutdown()
        {
            CloseWindow();
        }

        /// <summary>
        /// Stop the game loop
        /// </summary>
        public void Exit()
        {
            _isRunning = false;
        }
    }
}
