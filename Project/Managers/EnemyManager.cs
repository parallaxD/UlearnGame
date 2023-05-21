using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UlearnGame
{
    public static class EnemyManager
    {
        public static List<Enemy> Enemies { get; } = new List<Enemy>();
        public static int WaveNumber { get; private set; }

        public static void AddEnemy(Enemy enemy)
        {
            Enemies.Add(enemy);
        }
        public static void Update(Player player)
        {
            foreach (var enemy in Enemies)
            {
                enemy.Update(player);
                if (enemy.Health <= 0)
                {
                    Player.killsCount++;
                }
            }
            Enemies.RemoveAll(enemy => enemy.Health <= 0);
            if (Enemies.Count == 0)
            {
                WaveNumber++;
                CreateEnemyWave();
                BuffManager.IsBuffSpawnedAtThisWave = false;
            }
        }

        public static void Draw()
        {
            foreach (var enemy in Enemies) enemy.Draw(Globals.SpriteBatch, 1, enemy.Rotation, SpriteEffects.None);
        }

        public static void CreateEnemyWave()
        {
            for (int i = 0; i < WaveNumber; i++)
            {
                Vector2 randomPos = new Vector2(Globals.Random.Next(0, (int)Globals.WindowWidth), Globals.Random.Next(0, (int)Globals.WindowHeight));
                AddEnemy(new Enemy(Textures.EnemyTexture, randomPos, 50, 100, 5));
            }
        }
    }
}
