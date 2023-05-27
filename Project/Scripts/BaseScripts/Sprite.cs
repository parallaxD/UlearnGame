using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace UlearnGame
{
    public class Sprite
    {
        public Texture2D Texture { get; set; }

        public Vector2 Position { get; set; }
        public Vector2 Origin { get; private set; }

        public float Rotation { get; set; }

        public float Speed { get; set; }

        public Sprite(Texture2D texture, float speed, Vector2 position)
        {
            Texture = texture;
            Speed = speed;
            Position = position;
            Rotation = Rotation;
            Origin = new(texture.Width / 2, texture.Height / 2);
        }

        public virtual void Draw(SpriteBatch spriteBatch, float scale, float rotation, SpriteEffects spriteEffect)
        {
            spriteBatch.Draw(Texture, Position, null, Color.White, rotation, Origin, scale, spriteEffect, 0f);
        }


    }
}
