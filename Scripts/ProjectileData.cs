using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Text;
using System.Threading.Tasks;

namespace UlearnGame
{
    public sealed class ProjectileData
    {
        public Vector2 Position { get; set; }
        public float Lifespan { get; set; }
        public int Speed { get; set; }
        public float Rotation { get; set; }
    }
}
