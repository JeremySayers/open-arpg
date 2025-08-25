using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace OpenARPG.Core.Input
{
    /// <summary>
    /// Central input management system
    /// </summary>
    public class InputManager
    {
        private static InputManager? _instance;
        public static InputManager Instance => _instance ??= new InputManager();

        private InputManager() { }

        /// <summary>
        /// Get normalized movement input vector for isometric view
        /// </summary>
        public Vector3 GetMovementInput()
        {
            var movement = Vector3.Zero;

            // For isometric view, we need to transform WASD to match the camera angle
            // The camera is positioned diagonally, so we adjust the movement vectors
            if (IsActionHeld(ActionType.MoveUp))    movement += new Vector3(-1, 0, -1);   // Up-right in world space
            if (IsActionHeld(ActionType.MoveDown))  movement += new Vector3(1, 0, 1);   // Down-left in world space
            if (IsActionHeld(ActionType.MoveLeft))  movement += new Vector3(-1, 0, 1);  // Up-left in world space
            if (IsActionHeld(ActionType.MoveRight)) movement += new Vector3(1, 0, -1);    // Down-right in world space

            // Normalize diagonal movement
            if (movement != Vector3.Zero)
            {
                movement = Vector3.Normalize(movement);
            }

            return movement;
        }

        /// <summary>
        /// Check if an action is currently being held
        /// </summary>
        public bool IsActionHeld(ActionType action)
        {
            return action switch
            {
                ActionType.MoveUp => IsKeyDown(KeyboardKey.W),
                ActionType.MoveDown => IsKeyDown(KeyboardKey.S),
                ActionType.MoveLeft => IsKeyDown(KeyboardKey.A),
                ActionType.MoveRight => IsKeyDown(KeyboardKey.D),
                ActionType.Attack => IsMouseButtonDown(MouseButton.Left),
                ActionType.UseSkill1 => IsKeyDown(KeyboardKey.One),
                ActionType.UseSkill2 => IsKeyDown(KeyboardKey.Two),
                ActionType.UseSkill3 => IsKeyDown(KeyboardKey.Three),
                ActionType.UseSkill4 => IsKeyDown(KeyboardKey.Four),
                ActionType.OpenInventory => IsKeyDown(KeyboardKey.I),
                ActionType.OpenCharacterSheet => IsKeyDown(KeyboardKey.C),
                ActionType.Pause => IsKeyDown(KeyboardKey.Escape),
                ActionType.Interact => IsKeyDown(KeyboardKey.E),
                _ => false
            };
        }

        /// <summary>
        /// Check if an action was just pressed this frame
        /// </summary>
        public bool IsActionPressed(ActionType action)
        {
            return action switch
            {
                ActionType.Attack => IsMouseButtonPressed(MouseButton.Left),
                ActionType.UseSkill1 => IsKeyPressed(KeyboardKey.One),
                ActionType.UseSkill2 => IsKeyPressed(KeyboardKey.Two),
                ActionType.UseSkill3 => IsKeyPressed(KeyboardKey.Three),
                ActionType.UseSkill4 => IsKeyPressed(KeyboardKey.Four),
                ActionType.OpenInventory => IsKeyPressed(KeyboardKey.I),
                ActionType.OpenCharacterSheet => IsKeyPressed(KeyboardKey.C),
                ActionType.Pause => IsKeyPressed(KeyboardKey.Escape),
                ActionType.Interact => IsKeyPressed(KeyboardKey.E),
                _ => false
            };
        }

        /// <summary>
        /// Get mouse position in world coordinates (for clicking/targeting)
        /// </summary>
        public Vector2 GetMousePosition()
        {
            return Raylib.GetMousePosition();
        }
    }
}
