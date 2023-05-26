using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace UlearnGame
{
    public static class InputManager
    {
        private static Vector2 _direction;
        public static Vector2 mousePosition => Mouse.GetState().Position.ToVector2();

        private static MouseState _prevMouseState;

        public static Rectangle MouseRectangle { get; private set; }

        public static bool isMouseClicked { get; private set; }

        public static Vector2 GetDirection()
        {
            
            _direction = Vector2.Zero;
            var _keyboardState = Keyboard.GetState();
            if (_keyboardState.IsKeyDown(Keys.W)) _direction.Y--;           
            if (_keyboardState.IsKeyDown(Keys.S)) _direction.Y++;
            if (_keyboardState.IsKeyDown(Keys.A))
            {
                _direction.X--;
                Player.SpriteEffect = SpriteEffects.FlipHorizontally;
            }
            if (_keyboardState.IsKeyDown(Keys.D))
            {
                _direction.X++;
                Player.SpriteEffect = SpriteEffects.None;
            }
            return _direction;
        }

        public static void Update()
        {
            isMouseClicked = (Mouse.GetState().LeftButton == ButtonState.Pressed) && (_prevMouseState.LeftButton == ButtonState.Pressed);
            _prevMouseState = Mouse.GetState();

            var mouseState = Mouse.GetState();

            MouseRectangle = new Rectangle(mouseState.X, mouseState.Y, 1, 1);
        }
    }
}
