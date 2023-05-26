using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace UlearnGame
{
    public class ParticleEmitter
    {
        private readonly ParticleEmitterData _data;
        private float _intervalLeft;
        private readonly IEmitter _emitter;

        public float LifeTime;

        public ParticleEmitter(IEmitter emitter, ParticleEmitterData data)
        {
            _emitter = emitter;
            _data = data;
            _intervalLeft = data.interval;
            LifeTime = 1f;
        }

        private void Emit(Vector2 pos)
        {
            ParticleData data = _data.particleData;
            data.lifespan = Globals.RandomFloat(_data.lifespanMin, _data.lifespanMax);
            data.speed = Globals.RandomFloat(_data.speedMin, _data.speedMax);
            data.angle = Globals.RandomFloat(_data.angle - _data.angleVariance, _data.angle + _data.angleVariance);

            Particle p = new(pos, data);
            ParticleManager.AddParticle(p);

        }



        public void Update()
        {           
            _intervalLeft -= Globals.TotalSeconds;
            LifeTime -= Globals.TotalSeconds;           
            while (_intervalLeft <= 0f)
            {
                _intervalLeft += _data.interval;
                var pos = _emitter.EmitPosition;
                for (int i = 0; i < _data.emitCount; i++)
                {
                    Emit(pos);
                }
            }
        }
    }
}
