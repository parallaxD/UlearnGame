using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UlearnGame
{
    public class Enemy : Sprite
    {
        public int Health;
        public int Damage;
        public Enemy(Texture2D texture, Vector2 position, int speed, int health, int damage) : base(texture, position, speed)
        {
            Health = health;
            Damage = damage;
        }

        public void Update(Player player)
        {
            var vecToPlayer = player.Position - Position;
            Rotation = (float)Math.Atan2(vecToPlayer.Y, vecToPlayer.X);

            if (vecToPlayer.Length() > 25)
            {
                Position += Vector2.Normalize(vecToPlayer) * Speed * Globals.TotalSeconds;
            }
        }

        public void TakeDamage(int damage) => Health -= damage;
            

    }
}
