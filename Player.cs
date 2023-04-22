using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Numerics;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace UlearnGame
{
    public class Player : Sprite
    {
        private float _speed;
        public Vector2 Direction;

        public Player(Texture2D texture, float speed) : base(texture) 
        {
            _speed = speed;       
        }

        public void Update(GameTime gameTime)
        {
            Direction = InputManager.GetDirection();
            
            Position += Direction * _speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            //var toMouse = InputManager.mousePosition - _position;

            //_rotation = (float)Math.Atan2(toMouse.Y, toMouse.X);

            //if (InputManager.IsFireButtonPressed())
            //{
            //    Shoot();
            //}          
        }
    }
}
