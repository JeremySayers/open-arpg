using System.Numerics;
using OpenARPG.Core.Input;
using OpenARPG.Entities.Components;

namespace OpenARPG.Entities
{
    /// <summary>
    /// Player entity
    /// </summary>
    public class Player : Entity
    {
        public Movement Movement { get; private set; }

        public Player(Vector3 startPosition)
        {
            Transform.Position = startPosition;
            
            // Set up components
            Movement = new Movement(speed: 8.0f);
            Renderable = new Renderable();
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);
            
            // Handle player input
            HandleInput(deltaTime);
        }

        /// <summary>
        /// Handle player input and movement
        /// </summary>
        private void HandleInput(float deltaTime)
        {
            var inputManager = InputManager.Instance;
            
            // Get movement input
            var movementInput = inputManager.GetMovementInput();
            
            // Apply movement
            Movement.Move(movementInput, deltaTime, Transform);

            // Handle other actions
            if (inputManager.IsActionPressed(ActionType.Attack))
            {
                PerformAttack();
            }
            
            // Add more actions as needed
        }

        /// <summary>
        /// Perform an attack action
        /// </summary>
        private void PerformAttack()
        {
            // TODO: Implement attack logic
            System.Console.WriteLine("Player attacks!");
        }
    }
}
