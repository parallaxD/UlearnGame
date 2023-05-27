using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UlearnGame
{
    public static class ParticleManager
    {
        private static readonly List<Particle> _particles = new();
        private static readonly List<ParticleEmitter> _particleEmitters = new();

        public static void AddParticle(Particle p)
        {
            _particles.Add(p);
        }

        public static void AddParticleEmitter(ParticleEmitter emitter)
        {
            _particleEmitters.Add(emitter);
        }
        public static void UpdateParticles()
        {
            foreach (var particle in _particles)
            {
                particle.Update();
            }

            _particles.RemoveAll(p => p.IsFinished);
        }

        public static void UpdateEmitters()
        {
            foreach (var emitter in _particleEmitters)
            {               
                emitter.Update();
            }
            _particleEmitters.RemoveAll(emitter => emitter.LifeTime <= 0);
        }
        public static void RemoveParticleEmitter(ParticleEmitter emitter)
        {
            _particleEmitters.Remove(emitter);
        }

        public static void Update()
        {
            UpdateParticles();
            UpdateEmitters();
        }

        public static void Draw()
        {
            foreach (var particle in _particles)
            {
                particle.Draw();
            }
        }
    }
}
