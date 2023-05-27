using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UlearnGame
{
    public class Enemy : Sprite, IEmitter
    {
        public int Health;
        public int Damage;

        public Vector2 StartPosition;

        public Vector2 EmitPosition => Position;

        public Enemy(Texture2D texture, Vector2 startPosition, float speed, int health, int damage) : base(texture, speed * Globals.PlayerSpeedMultiplier, startPosition)
        {
            StartPosition = startPosition;
            Health = health;
            Damage = damage;
        }

        public void Update(Player player)
        {
            if (Health <= 0)
            {
                if (Texture == Textures.ChortTexture)
                {
                    SoundManager.PlayChortDieSound();
                }
                else
                {
                    SoundManager.PlayDemonDieSound();
                }

                ParticleEmitterData emitterData = new ParticleEmitterData();
                emitterData.ParticleData.ColorStart = Color.Red;              
                emitterData.ParticleData.ColorEnd = Color.Red;
                emitterData.ParticleData.OpacityStart = 1f;
                emitterData.ParticleData.OpacityEnd = 0f;
                emitterData.ParticleData.SizeStart = 16f;
                emitterData.ParticleData.SizeEnd = 2f;
                emitterData.AngleVariance = 360f;
                emitterData.LifespanMin = 0.5f;
                emitterData.LifespanMax = 1.0f;
                emitterData.Interval = 0.05f;
                emitterData.EmitCount = 10;

                ParticleEmitter emitter = new ParticleEmitter(this, emitterData);
                ParticleManager.AddParticleEmitter(emitter);


                player.KillsCount++;
            }
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
