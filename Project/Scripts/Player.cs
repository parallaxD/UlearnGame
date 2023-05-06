using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using static System.Formats.Asn1.AsnWriter;

namespace UlearnGame
{
    public class Player : Sprite
    {
        public Vector2 Direction;

        public static SpriteEffects SpriteEffect;
        public static int Health;

        private float _getHitRate = 0.5f;
        private float _lastHitTime;

        private float _shootRate = 0.5f;
        private float _lastShootTime;

        public Player(Texture2D texture, Vector2 startPosition, int speed) : base(texture, startPosition, speed) 
        {
            Health = 100;
        }

        public void Update(List<Enemy> enemies)
        {
            _lastHitTime += Globals.TotalSeconds;
            _lastShootTime += Globals.TotalSeconds;
            var dir = InputManager.GetDirection();
            Position = new(
                 Math.Clamp(Position.X + (dir.X * Speed * Globals.TotalSeconds), 0, Globals._windowWidth),
                 Math.Clamp(Position.Y + (dir.Y * Speed * Globals.TotalSeconds), 0, Globals._windowHeight)
             );

            var vecToMouse = InputManager.mousePosition - Position;
            Rotation = (float)Math.Atan2(vecToMouse.Y, vecToMouse.X);

            foreach (var enemy in enemies)
            {
                if ((Position - enemy.Position).Length() < 50 && _getHitRate < _lastHitTime)
                {
                    TakeDamage(enemy.Damage);
                    _lastHitTime = 0;
                    break;
                }
            }

            if (InputManager.isMouseClicked)
            {
                Shoot();
            }

        }

        private void Shoot()
        {
            if (_shootRate < _lastShootTime)
            {
                _lastShootTime = 0;
                ProjectileData projectileData = new ProjectileData()
                {
                    Position = Position,
                    Rotation = Rotation,
                    Speed = 300,
                    Lifespan = 3
                };
                ProjectileManager.AddProjectile(projectileData);
            }
        }

        public void Draw(SpriteBatch spriteBatch, int scale)
        {
            spriteBatch.Draw(_texture, Position, null, Color.White, 0, Origin, scale, SpriteEffect, 0f);
        }

        private void TakeDamage(int damage) => Health -= damage;

    }

}
