using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Text;
using System.Threading.Tasks;

namespace UlearnGame
{
    public class Buff
    {
        public Texture2D Texture;
        public Vector2 Position;
        public float Duration;
        public bool isActive;


        public Buff(Texture2D texture, Vector2 position)
        {
            Texture = texture;
            Position = position;
        }

        public virtual void ApplyEffect(Player player)
        {
        }
        public virtual void RemoveEffect(Player player)
        {
        }

        public void Update()
        {
                Duration -= Globals.TotalSeconds;
        }

        public void Draw()
        {
            Globals.SpriteBatch.Draw(Texture, Position, Color.White);
        }
    }
}
