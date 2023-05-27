using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UlearnGame
{
    public struct ParticleData
    {
        private static Texture2D _defaultTexture;
        public Texture2D Texture = _defaultTexture ??= Globals.Content.Load<Texture2D>("particle");
        public float Lifespan = 2f;
        public Color ColorStart = Color.Yellow;
        public Color ColorEnd = Color.Red;
        public float OpacityStart = 1f;
        public float OpacityEnd = 0f;
        public float SizeStart = 32f;
        public float SizeEnd = 4f;
        public float Speed = 100f;
        public float Angle = 0f;

        public ParticleData()
        {
        }
    }
}
