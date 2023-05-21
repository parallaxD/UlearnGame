using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace UlearnGame
{
    public static class PlayerManager
    {
        public static Player Player;
        public static void Initialize()
        {
            Player = new Player(Textures.PlayerTexture,
                new Vector2(Globals.WindowWidth / 2, Globals.WindowHeight / 2),
                300,
                50);
        }

        public static void Update(List<Enemy> enemies, List<Buff> buffs)
        {
            Player.Update(enemies, buffs);
        }

        public static void Draw(int scale)
        {
            Globals.SpriteBatch.Draw(Player._texture, Player.Position, null, Color.White, 0, Player.Origin, scale, Player.SpriteEffect, 0f);
        }

    }
}
