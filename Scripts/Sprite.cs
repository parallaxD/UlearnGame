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
        public Texture2D _texture { get; private set; }

        //public static SpriteEffects SpriteEffect { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Origin { get; private set; }

        public float Rotation { get; set; }

        public int Speed { get; set; }

        public Sprite(Texture2D texture, Vector2 position, int speed)
        {
            _texture = texture;
            Speed = speed;
            Position = position;
            Rotation = Rotation;
            Origin = new(texture.Width / 2, texture.Height / 2);
        }

        public virtual void Draw(SpriteBatch spriteBatch, float scale, float rotation, SpriteEffects spriteEffect)
        {
            spriteBatch.Draw(_texture, Position, null, Color.White, rotation, Origin, scale, spriteEffect, 0f);
        }


    }
}
