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
        public static Texture2D DemonTexture => Globals.Content.Load<Texture2D>("big_demon_idle_anim_f0");
        public static Texture2D HealBottleTexture => Globals.Content.Load<Texture2D>("healBottle");
        public static Texture2D PowerBottleTexture => Globals.Content.Load<Texture2D>("powerBottle");
        public static Texture2D FountainTexture => Globals.Content.Load<Texture2D>("fountain");
        public static Texture2D SpeedBottleTexture => Globals.Content.Load<Texture2D>("speedBottle");
        public static Texture2D ChortTexture => Globals.Content.Load<Texture2D>("chort");


    }
}
