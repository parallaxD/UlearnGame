using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace UlearnGame
{
    public static class InputManager
    {
        private static Vector2 _direction;
        public static Vector2 mousePosition => Mouse.GetState().Position.ToVector2();

        private static MouseState prevMouseState;

        public static Vector2 GetDirection()
        {
            _direction = Vector2.Zero;
            var _keyboardState = Keyboard.GetState();
            if (_keyboardState.IsKeyDown(Keys.W)) _direction.Y--;           
            if (_keyboardState.IsKeyDown(Keys.S)) _direction.Y++;           
            if (_keyboardState.IsKeyDown(Keys.A)) _direction.X--;           
            if (_keyboardState.IsKeyDown(Keys.D)) _direction.X++;
            return _direction;
        }

        public static bool IsFireButtonPressed()
        {
            var mouseState = Mouse.GetState();
            return mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released;
        }
    }
}
