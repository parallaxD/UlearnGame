using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UlearnGame
{
    public class Projectile : Sprite
    {
        public Vector2 Direction { get; set; }
        public float Lifespan { get; set; }

        public int Damage { get; set; }
        public Projectile(Texture2D texture, ProjectileData data, int speed, int damage) : base(texture, 300, data.Position)
        {
            Damage = damage;
            Speed = data.Speed;
            Rotation = data.Rotation;
            Direction = new Vector2((float)Math.Cos(Rotation), (float)Math.Sin(Rotation));
            Lifespan = data.Lifespan;
            Damage = damage;
        }
        public void Update()
        {
            Position += Direction * Speed * Globals.TotalSeconds;
            Lifespan -= Globals.TotalSeconds;
        }

        public void Destroy()
        {
            Lifespan = 0;
        }
    }
}
