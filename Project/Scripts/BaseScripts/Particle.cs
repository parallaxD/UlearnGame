using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UlearnGame
{
    public class Particle
    {
        private ParticleData _data;
        private Vector2 _position;
        private float _lifespanLeft;
        private float _lifespanAmount;
        private Color _color;
        private float _opacity;
        public bool IsFinished = false;
        private float _scale;
        private Vector2 _origin;
        private Vector2 _direction;

        public Particle(Vector2 pos, ParticleData data)
        {
            _data = data;
            _lifespanLeft = data.Lifespan;
            _lifespanAmount = 1f;
            _position = pos;
            _color = data.ColorStart;
            _opacity = data.OpacityStart;
            _origin = new(_data.Texture.Width / 2, _data.Texture.Height / 2);
            if (data.Speed != 0)
            {
                _data.Angle = MathHelper.ToRadians(_data.Angle);
                _direction = new Vector2((float)Math.Sin(_data.Angle), -(float)Math.Cos(_data.Angle));
            }
            else
            {
                _direction = Vector2.Zero;
            }
        }

        public void Update()
        {
            _lifespanLeft -= Globals.TotalSeconds;
            if (_lifespanLeft <= 0f)
            {
                IsFinished = true;
                return;
            }

            _lifespanAmount = MathHelper.Clamp(_lifespanLeft / _data.Lifespan, 0, 1);
            _color = Color.Lerp(_data.ColorEnd, _data.ColorStart, _lifespanAmount);
            _opacity = MathHelper.Clamp(MathHelper.Lerp(_data.OpacityEnd, _data.OpacityStart, _lifespanAmount), 0, 1);
            _scale = MathHelper.Lerp(_data.SizeEnd, _data.SizeStart, _lifespanAmount) / _data.Texture.Width;
            _position += _direction * _data.Speed * Globals.TotalSeconds;
        }

        public void Draw()
        {
            Globals.SpriteBatch.Draw(_data.Texture, _position, null, _color * _opacity, 0f, _origin, _scale, SpriteEffects.None, 1f);
        }
    }
}
