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

        public static float WindowWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
        public static float WindowHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
        public static Random Random => new Random();

        public static int mouseX;
        public static int mouseY;

        public static float EnemySpeedMultiplier = 1.02f;
        public static float PlayerSpeedMultiplier = 1.1f;

        public static void Update(GameTime gameTime)
        {
            mouseX = Mouse.GetState().X;
            mouseY = Mouse.GetState().Y;
            TotalSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
        public static float RandomFloat(float min, float max)
        {
            return (float)(Random.NextDouble() * (max - min)) + min;
        }
    }
}
