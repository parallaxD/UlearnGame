using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UlearnGame
{
    public static class Textures
    {
        public static Texture2D PlayerTexture => Globals.Content.Load<Texture2D>("wizzard_f_idle_anim_f0");
        public static Texture2D EnemyTexture => Globals.Content.Load<Texture2D>("big_demon_idle_anim_f0");
        public static Texture2D HealBottleTexture => Globals.Content.Load<Texture2D>("healBottle");
        public static Texture2D PowerBottleTexture => Globals.Content.Load<Texture2D>("powerBottle");
    }
}
