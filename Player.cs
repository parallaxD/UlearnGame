using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Numerics;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace UlearnGame
{
    public class Player
    {
        public Texture2D _texture { get; private set; }
        public Vector2 _position;
        private float _speed;
        private float _rotation;
        private Vector2 _origin;
        private Vector2 _direction;
        private SpriteBatch _spriteBatch;
        public Player(Texture2D texture, Vector2 position, float currentSpeed)
        {
            _texture = texture;
            _position = position;
            _speed = currentSpeed;
            _origin = new(_texture.Width / 2, _texture.Height / 2);
        }

        public void Update(GameTime gameTime)
        {
            _position += InputManager.GetDirection() * _speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            var toMouse = InputManager.mousePosition - _position;

            _rotation = (float)Math.Atan2(toMouse.Y, toMouse.X);

            if (InputManager.IsFireButtonPressed())
            {
                Shoot();
            }
            
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, null, Color.White, _rotation, _origin, 2, SpriteEffects.None, 1);
        }

        public void Shoot()
        {
            Bullet bullet = new Bullet(_position, _direction, 100f);
        }
    }
}
