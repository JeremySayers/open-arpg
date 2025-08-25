using System.Collections.Generic;

namespace OpenARPG.Core.States
{
    /// <summary>
    /// Manages game states and transitions between them
    /// </summary>
    public class GameStateManager
    {
        private readonly Dictionary<string, IGameState> _states;
        private IGameState? _currentState;
        private string? _currentStateName;

        public GameStateManager()
        {
            _states = new Dictionary<string, IGameState>();
        }

        /// <summary>
        /// Register a state with a name
        /// </summary>
        public void RegisterState(string name, IGameState state)
        {
            _states[name] = state;
        }

        /// <summary>
        /// Change to a different state
        /// </summary>
        public void ChangeState(string stateName)
        {
            if (!_states.ContainsKey(stateName))
            {
                throw new ArgumentException($"State '{stateName}' is not registered");
            }

            // Exit current state
            _currentState?.Exit();

            // Switch to new state
            _currentState = _states[stateName];
            _currentStateName = stateName;
            _currentState.Enter();
        }

        /// <summary>
        /// Get the name of the current state
        /// </summary>
        public string? CurrentStateName => _currentStateName;

        /// <summary>
        /// Update the current state
        /// </summary>
        public void Update(float deltaTime)
        {
            _currentState?.Update(deltaTime);
        }

        /// <summary>
        /// Draw the current state
        /// </summary>
        public void Draw()
        {
            _currentState?.Draw();
        }
    }
}
