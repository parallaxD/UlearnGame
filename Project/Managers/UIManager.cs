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
        private static string _killsCountString;

        public static void Initialize(Player player)
        {
            _heartTexture = Globals.Content.Load<Texture2D>("heart");
            _arialFont = Globals.Content.Load<SpriteFont>("arialFont");
            _playerHealthString = $": {player.Health}";
            _killsCountString = $"Чертей убито : {player.killsCount}";
        }

        public static void Update(Player player)
        {
            _playerHealthString = $": {player.Health}";
            _killsCountString = $"Chertey   ubito : {player.killsCount}";
        }
        public static void Draw()
        {
            Globals.SpriteBatch.Draw(_heartTexture, new Vector2(10, 10), Color.White);
            Globals.SpriteBatch.DrawString(_arialFont, _playerHealthString, new Vector2(38, 7), Color.White);
            Globals.SpriteBatch.DrawString(_arialFont, _killsCountString, new Vector2(20, 40), Color.White);
        }
    }
}
