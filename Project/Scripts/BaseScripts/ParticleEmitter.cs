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
        private ParticleEmitterData _data;

        private float _intervalLeft;

        private IEmitter _emitter;

        public float LifeTime;

        public ParticleEmitter(IEmitter emitter, ParticleEmitterData data)
        {
            _emitter = emitter;
            _data = data;
            _intervalLeft = data.Interval;
            LifeTime = 1f;
        }

        private void Emit(Vector2 pos)
        {
            ParticleData data = _data.ParticleData;
            data.Lifespan = Globals.RandomFloat(_data.LifespanMin, _data.LifespanMax);
            data.Speed = Globals.RandomFloat(_data.SpeedMin, _data.SpeedMax);
            data.Angle = Globals.RandomFloat(_data.Angle - _data.AngleVariance, _data.Angle + _data.AngleVariance);

            Particle p = new(pos, data);
            ParticleManager.AddParticle(p);

        }



        public void Update()
        {           
            _intervalLeft -= Globals.TotalSeconds;
            LifeTime -= Globals.TotalSeconds;           
            while (_intervalLeft <= 0f)
            {
                _intervalLeft += _data.Interval;
                var pos = _emitter.EmitPosition;
                for (int i = 0; i < _data.EmitCount; i++)
                {
                    Emit(pos);
                }
            }
        }
    }
}
