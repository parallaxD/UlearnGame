
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UlearnGame
{
    public class Background
    {
        private readonly Point _mapTileSize = new((int)Globals.WindowWidth / 15, (int)Globals.WindowHeight / 15);
        private readonly Sprite[,] _tiles;

        public Background()
        {
            _tiles = new Sprite[_mapTileSize.X, _mapTileSize.Y];

            List<Texture2D> backgroundSprites = new(5);
            for (int i = 1; i < 6; i++) backgroundSprites.Add(Globals.Content.Load<Texture2D>($"floor_{i}"));

            Point TileSize = new(backgroundSprites[0].Width, backgroundSprites[0].Height);
            Random random = new();
            for (int y = 0; y < _mapTileSize.Y; y++)
            {
                for (int x = 0; x < _mapTileSize.X; x++)
                {
                    int r = random.Next(0, backgroundSprites.Count);
                    _tiles[x, y] = new(backgroundSprites[r], 0, new((x + 0.5f) * TileSize.X, (y + 0.5f) * TileSize.Y));
                }
            }
        }

        public void Draw()
        {
            for (int y = 0; y < _mapTileSize.Y; y++)
            {
                for (int x = 0; x < _mapTileSize.X; x++)
                {
                    _tiles[x, y].Draw(Globals.SpriteBatch, 1, 0, SpriteEffects.None);
                }
            }
            Globals.SpriteBatch.Draw(Textures.FountainTexture, new Vector2(Globals.WindowWidth / 2, Textures.FountainTexture.Height), null, Color.White, 0, new Vector2(Textures.FountainTexture.Width / 2, Textures.FountainTexture.Height / 2), 2, SpriteEffects.None, 0);
            Globals.SpriteBatch.Draw(Textures.FountainTexture, new Vector2(Textures.FountainTexture.Width, Globals.WindowHeight / 2), null, Color.White, 0, new Vector2(Textures.FountainTexture.Width / 2, Textures.FountainTexture.Height / 2), 2, SpriteEffects.None, 0);
            Globals.SpriteBatch.Draw(Textures.FountainTexture, new Vector2(Globals.WindowWidth - Textures.FountainTexture.Width, Globals.WindowHeight / 2), null, Color.White, 0, new Vector2(Textures.FountainTexture.Width / 2, Textures.FountainTexture.Height / 2), 2, SpriteEffects.None, 0);
            Globals.SpriteBatch.Draw(Textures.FountainTexture, new Vector2(Globals.WindowWidth / 2, Globals.WindowHeight - Textures.FountainTexture.Height), null, Color.White, 0, new Vector2(Textures.FountainTexture.Width / 2, Textures.FountainTexture.Height / 2), 2, SpriteEffects.None, 0);
        }
    }
}
