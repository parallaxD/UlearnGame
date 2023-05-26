using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace UlearnGame
{
    public class Player : Sprite
    {
        public float DefaultSpeed;

        public float MaxSpeed = 700;

        public Vector2 Direction;

        public static SpriteEffects SpriteEffect;

        public int Health;
        public int MaxHealth = 100;

        public int killsCount;
        public static bool IsDead { get; private set; }

        public static bool IsBuffed { get; private set; }
        public static Buff LastTakenBuff { get; private set; }

        public int Damage;

        private float _getHitRate = 0.5f;
        private float _lastHitTime;

        public float MaxShootRate = 0.4f;
        public float currentShootRate = 0.4f;
        public float MinShootRate = 0.1f;
        private float _lastShootTime;


        public Player(Texture2D texture, Vector2 startPosition, int speed, int damage) : base(texture, speed, startPosition) 
        {
            DefaultSpeed = speed;
            Speed = speed;
            killsCount = 0;
            Damage = damage;
            Health = 100;
        }

        public void Update(List<Enemy> enemies, List<Buff> buffsAtScene, List<Buff> activeBuffs)
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

            foreach (var buff in buffsAtScene)
            {
                if ((Position - buff.Position).Length() < 40)
                {
                    activeBuffs.Add(buff);
                    TakeBuff(buff);
                    IsBuffed = true;
                    LastTakenBuff = buff;
                    break;
                }
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
            if (currentShootRate < _lastShootTime)
            {
                SoundManager.PlayAttackSound();
                _lastShootTime = 0;
                ProjectileData projectileData = new ProjectileData()
                {
                    
                    Position = Position,
                    Rotation = Rotation,
                    Speed = 600,
                    Lifespan = 3
                };
                ProjectileManager.AddProjectile(projectileData, Damage);
            }
        }

        private void TakeDamage(int damage) => Health -= damage;

        private void TakeBuff(Buff buff)
        {
            buff.ApplyEffect(this);
        }

    }

}
