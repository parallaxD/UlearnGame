using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UlearnGame
{
    public static class UIManager
    {
        private static SpriteFont _arialFont;
        private static Texture2D _heartTexture;

        private static string _playerHealthString;
        private static string _killCountString;

        public static void Initialize()
        {
            _heartTexture = Globals.Content.Load<Texture2D>("heart");
            _arialFont = Globals.Content.Load<SpriteFont>("arialFont");
            _playerHealthString = $": {Player.Health}";
            _killCountString = $"Чертей убито : {Player.killsCount}";
        }

        public static void Update()
        {
            _playerHealthString = $": {Player.Health}";
            _killCountString = $"Чертей убито : {Player.killsCount}";
        }
        public static void Draw()
        {
            Globals.SpriteBatch.Draw(_heartTexture, new Vector2(10, 10), Color.White);
            Globals.SpriteBatch.DrawString(_arialFont, _playerHealthString, new Vector2(38, 11), Color.White);
            Globals.SpriteBatch.DrawString(_arialFont, _killCountString, new Vector2(38, 20), Color.White);
        }
    }
}
