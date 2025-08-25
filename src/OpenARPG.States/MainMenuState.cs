using Raylib_cs;
using OpenARPG.Core;
using OpenARPG.Core.States;
using OpenARPG.UI;
using static Raylib_cs.Raylib;

namespace OpenARPG.States
{
    /// <summary>
    /// Main menu state - handles the game's main menu
    /// </summary>
    public class MainMenuState : IGameState
    {
        private readonly GameStateManager _stateManager;
        private readonly IGame _game;
        private Button _playButton;
        private Button _settingsButton;
        private Button _exitButton;

        public MainMenuState(GameStateManager stateManager, IGame game)
        {
            _stateManager = stateManager;
            _game = game;
            
            // Initialize buttons
            _playButton = new Button(new Rectangle(300, 200, 200, 50), "Play");
            _settingsButton = new Button(new Rectangle(300, 270, 200, 50), "Settings");
            _exitButton = new Button(new Rectangle(300, 340, 200, 50), "Exit");
        }

        public void Enter()
        {
            // Set up button click handlers
            _playButton.OnClick += OnPlayClicked;
            _settingsButton.OnClick += OnSettingsClicked;
            _exitButton.OnClick += OnExitClicked;
        }

        public void Exit()
        {
            // Clean up button click handlers
            _playButton.OnClick -= OnPlayClicked;
            _settingsButton.OnClick -= OnSettingsClicked;
            _exitButton.OnClick -= OnExitClicked;
        }

        public void Update(float deltaTime)
        {
            _playButton.Update();
            _settingsButton.Update();
            _exitButton.Update();
        }

        public void Draw()
        {
            // Draw title
            DrawText("OpenARPG", 300, 100, 48, Color.White);
            DrawText("An Open Source Action RPG", 250, 150, 20, Color.LightGray);

            // Draw buttons
            _playButton.Draw();
            _settingsButton.Draw();
            _exitButton.Draw();

            // Draw version info
            DrawText("v0.1.0-alpha", 10, GetScreenHeight() - 25, 16, Color.Gray);
        }

        private void OnPlayClicked()
        {
            // Change to gameplay state
            _stateManager.ChangeState("Gameplay");
        }

        private void OnSettingsClicked()
        {
            // TODO: Change to settings state when implemented
            // _stateManager.ChangeState("Settings");
            System.Console.WriteLine("Settings button clicked");
        }

        private void OnExitClicked()
        {
            // Exit the game
            _game.Exit();
        }
    }
}
