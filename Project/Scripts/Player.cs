using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace UlearnGame
{
    public class Player : Sprite
    {
        public Vector2 Direction;

        public static SpriteEffects SpriteEffect;

        public static int Health;
        public static int MaxHealth = 100;

        public static int killsCount;
        public static bool IsDead { get; private set; }

        public static bool IsBuffed { get; private set; }
        public static Buff LastTakenBuff { get; private set; }
        private float _buffDuration;

        public int Damage;

        private float _getHitRate = 0.5f;
        private float _lastHitTime;

        public static float MaxShootRate = 0.4f;
        public static float CurrentShootRate = 0.4f;
        public static float MinShootRate = 0.1f;
        private float _lastShootTime;


        public Player(Texture2D texture, Vector2 startPosition, int speed, int damage) : base(texture, speed, startPosition) 
        {
            killsCount = 0;
            Damage = damage;
            Health = 100;
        }

        public void Update(List<Enemy> enemies, List<Buff> buffs)
        {
            _lastHitTime += Globals.TotalSeconds;
            _lastShootTime += Globals.TotalSeconds;
            var dir = InputManager.GetDirection();
            Position = new(
                 Math.Clamp(Position.X + (dir.X * Speed * Globals.TotalSeconds), 0, Globals.WindowWidth),
                 Math.Clamp(Position.Y + (dir.Y * Speed * Globals.TotalSeconds), 0, Globals.WindowHeight)
             );

            var vecToMouse = InputManager.mousePosition - Position;
            Rotation = (float)Math.Atan2(vecToMouse.Y, vecToMouse.X);

            foreach (var buff in buffs)
            {
                if ((Position - buff.Position).Length() < 40)
                {
                    _buffDuration = buff.Duration;
                    TakeBuff(buff);
                    IsBuffed = true;
                    LastTakenBuff = buff;
                    break;
                }
            }

            _buffDuration -= Globals.TotalSeconds;
            if (_buffDuration <= 0)
            {
                CurrentShootRate = MaxShootRate;
            }

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
            if (CurrentShootRate < _lastShootTime)
            {
                _lastShootTime = 0;
                ProjectileData projectileData = new ProjectileData()
                {
                    
                    Position = Position,
                    Rotation = Rotation,
                    Speed = 300,
                    Lifespan = 3
                };
                ProjectileManager.AddProjectile(projectileData, Damage);
            }
        }

        private void TakeDamage(int damage) => Health -= damage;

        private void TakeBuff(Buff buff)
        {
            buff.ApplyEffect();
        }

    }

}
