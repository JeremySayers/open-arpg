using System;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace OpenARPG.UI
{
    /// <summary>
    /// A very small button – draws a rectangle + label, handles click.
    /// </summary>
    public sealed class Button
    {
        public Rectangle Bounds { get; }
        public string Text { get; }
        public event Action? OnClick;

        // Visual state
        private bool _hovered;
        private bool _pressed;

        // Appearance
        private readonly Color _bgNormal = Color.LightGray;
        private readonly Color _bgHover  = Color.DarkGray;
        private readonly Color _bgPress  = Color.Gray;
        private readonly Color _textColor = Color.Black;

        public Button(Rectangle bounds, string text)
        {
            Bounds = bounds;
            Text   = text;
        }

        /// <summary>Call in your main update loop.</summary>
        public void Update()
        {
            var mouse = GetMousePosition();

            _hovered = CheckCollisionPointRec(mouse, Bounds);

            // Pressed logic – we only fire OnClick when the mouse goes up
            if (_hovered && IsMouseButtonDown(MouseButton.Left))
                _pressed = true;
            else if (_pressed && IsMouseButtonReleased(MouseButton.Left))
            {
                if (_hovered) OnClick?.Invoke();
                _pressed = false;
            }
            else
                _pressed = false;
        }

        /// <summary>Call in your main draw loop.</summary>
        public void Draw()
        {
            var bg = _bgNormal;
            if (_pressed)      bg = _bgPress;
            else if (_hovered) bg = _bgHover;

            DrawRectangleRec(Bounds, bg);
            DrawText(Text,
                     (int)(Bounds.X + Bounds.Width / 2 - MeasureText(Text, 20) / 2),
                     (int)(Bounds.Y + Bounds.Height / 2 - 10),
                     20, _textColor);
        }
    }
}