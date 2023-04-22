using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UlearnGame
{
    public class Sprite
    {
        private Texture2D _texture;

        public static SpriteEffects SpriteEffect { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Origin { get; private set; }

        public float RotationVelocity;
        public float LinearVelocity;

        public Sprite(Texture2D texture)
        {
            _texture = texture;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Position, null, Color.White, 0, Origin, 1, SpriteEffect, 0f);
        }

    }
}
