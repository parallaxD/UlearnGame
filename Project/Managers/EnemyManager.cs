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
        private static int _maxChortsCount = 0;
        private static int _chortsCount = 0;

        private static float _chortSpeed = 250f;
        private static float _demonSpeed = 100f;

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
            }
            Enemies.RemoveAll(enemy => enemy.Health <= 0);
            if (Enemies.Count == 0)
            {             
                _chortsCount = 0;
                WaveNumber++;
                if (WaveNumber % 2 == 0)
                {
                    _maxChortsCount++;
                    GameManager.HasPlayerSpeedBoosted = false;                   
                }
                CreateEnemyWave();               
                BuffManager.IsBuffSpawnedAtThisWave = false;
            }
        }

        public static void Draw()
        {
            foreach (var enemy in Enemies) 
                if (enemy.Texture == Textures.ChortTexture)
                {
                    enemy.Draw(Globals.SpriteBatch, 6, enemy.Rotation, SpriteEffects.None);
                }
                else
                {
                    enemy.Draw(Globals.SpriteBatch, 2, enemy.Rotation, SpriteEffects.None);
                }
        }

        public static void CreateEnemyWave()
        {
            for (int i = 0; i < WaveNumber; i++)
            {
                Vector2 randomPos = new Vector2(Globals.Random.Next(0, (int)Globals.WindowWidth), Globals.Random.Next(0, (int)Globals.WindowHeight));
                if (WaveNumber % 2 == 0 && WaveNumber != 0 && _chortsCount < _maxChortsCount)
                {
                    AddEnemy(new Enemy(Textures.ChortTexture, randomPos, _chortSpeed * Globals.EnemySpeedMultiplier, 250, 15));
                    _chortsCount++;
                    continue;
                }
                else AddEnemy(new Enemy(Textures.DemonTexture, randomPos, _demonSpeed * Globals.EnemySpeedMultiplier, 100, 5));                
            }          
        }
    }
}
