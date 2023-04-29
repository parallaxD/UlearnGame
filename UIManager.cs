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
        public static void Initialize()
        {
            _heartTexture = Globals.Content.Load<Texture2D>("heart");
            _arialFont = Globals.Content.Load<SpriteFont>("arialFont");
            _playerHealthString = $": {Player.health}";            
        }

        public static void Draw()
        {
            Globals.SpriteBatch.Draw(_heartTexture, new Rectangle(5, 5, 40, 40), Color.White);
            Globals.SpriteBatch.DrawString(_arialFont, _playerHealthString, new Vector2(40, 10), Color.White);
        }
    }
}
