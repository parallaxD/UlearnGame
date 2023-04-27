using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UlearnGame
{
    public static class Globals
    {
        public static float TotalSeconds;
        public static ContentManager Content { get; set; }
        public static SpriteBatch SpriteBatch { get; set; }
        public static float _windowWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
        public static float _windowHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

        public static void Update(GameTime gameTime)
        {
            TotalSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}
