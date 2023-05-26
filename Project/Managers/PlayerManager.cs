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

        public static void Update(List<Enemy> enemies, List<Buff> buffsAtScene, List<Buff> activeBuffs)
        {
            Player.Update(enemies, buffsAtScene, activeBuffs);
            if (EnemyManager.WaveNumber % 2 == 0 && !GameManager.HasPlayerSpeedBoosted && Player.Speed <= Player.MaxSpeed)
            {
                Player.Speed = Player.Speed * Globals.PlayerSpeedMultiplier;
                Player.DefaultSpeed = Player.Speed;
                GameManager.HasPlayerSpeedBoosted = true;
            }
            if (Player.Health <= 0)
            {              
            }
        }

        public static void Draw(int scale)
        {
            Globals.SpriteBatch.Draw(Player._texture, Player.Position, null, Color.White, 0, Player.Origin, scale, Player.SpriteEffect, 0f);
        }

    }
}
