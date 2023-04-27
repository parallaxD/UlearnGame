using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UlearnGame
{
    public static class ProjectileManager
    {
        private static Texture2D _texture;
        public static List<Projectile> Projectiles { get; } = new();

        public static void Initialize()
        {
            _texture = Globals.Content.Load<Texture2D>("knight_f_idle_anim_f0");
        }

        public static void AddProjectile(ProjectileData data)
        {
            Projectiles.Add(new Projectile(_texture, data, 600));
        }
        public static void Update()
        {
            foreach (var projectile in Projectiles)
            {
                projectile.Update();
            }
            Projectiles.RemoveAll(projectile => projectile.Lifespan <= 0);
        }

        public static void Draw()
        {
            foreach (var projectile in Projectiles)
            {
                projectile.Draw(Globals.SpriteBatch, 1, projectile.Rotation);
            }
        }
    }
}
