namespace OpenARPG.Core.States
{
    /// <summary>
    /// Interface for all game states (MainMenu, Gameplay, Pause, etc.)
    /// </summary>
    public interface IGameState
    {
        /// <summary>
        /// Called when this state becomes active
        /// </summary>
        void Enter();

        /// <summary>
        /// Called when this state is no longer active
        /// </summary>
        void Exit();

        /// <summary>
        /// Update logic for this state
        /// </summary>
        /// <param name="deltaTime">Time since last frame in seconds</param>
        void Update(float deltaTime);

        /// <summary>
        /// Render logic for this state
        /// </summary>
        void Draw();
    }
}
