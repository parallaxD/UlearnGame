using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UlearnGame
{
    public class Bullet
    {
        private float _speed;
        GraphicsDevice graphicsDevice;
        public Texture2D _bulletTexture { get; private set; }

        public Vector2 _position;
        public Vector2 _direction;

        public Bullet(Texture2D bulletTexture, Vector2 position, Vector2 direction, float speed)
        {
            _bulletTexture = bulletTexture;
            _position = position;
            _direction = direction;
            _speed = speed;
        }

        public void Update(GameTime gameTime)
        {
            _position += _direction * _speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D texture)
        {
            spriteBatch.Draw(texture, _position, Color.White);
        }
    }
}
