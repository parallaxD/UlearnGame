﻿using Microsoft.Xna.Framework.Graphics;
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

        public static void Initialize(string textureName)
        {
            _texture = Globals.Content.Load<Texture2D>(textureName);
        }

        public static void AddProjectile(ProjectileData data, int damage)
        {
            Projectiles.Add(new Projectile(_texture, data, data.Speed, damage));
        }
        public static void Update(List<Enemy> enemies)
        {
            foreach (var projectile in Projectiles)
            {
                projectile.Update();
                foreach (var enemy in enemies)
                {
                    if (enemy.Health <= 0) continue;
                    if ((projectile.Position - enemy.Position).Length() < 32)
                    {
                        enemy.TakeDamage(projectile.Damage);
                        projectile.Destroy();
                        break;
                    }
                }
            }
            Projectiles.RemoveAll(projectile => projectile.Lifespan <= 0);
        }

        public static void Draw()
        {
            foreach (var projectile in Projectiles) projectile.Draw(Globals.SpriteBatch, 0.1f, projectile.Rotation, SpriteEffects.None);
        }
    }
}
