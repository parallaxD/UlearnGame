using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using UlearnGame.Scripts;

namespace UlearnGame
{
    public static class BuffManager
    {
        private static float _maxBottleCount = 1;

        public static bool IsBuffSpawnedAtThisWave;
        public static List<Buff> BuffsAtScene { get; private set; } = new();
        public static List<Buff> ActiveBuffs { get; private set; } = new();

        public static void Update(Player player)
        {
            if (EnemyManager.WaveNumber % 3 == 0 && EnemyManager.WaveNumber != 0 && !IsBuffSpawnedAtThisWave)
            {
                var randomPos = new Vector2(Globals.Random.Next(50, 500), Globals.Random.Next(50, 500));
                if (player.Health <= 90 && BuffsAtScene.Count(buff => buff is HealBottle) < _maxBottleCount)
                {
                    HealBottle healBottle = new HealBottle(Textures.HealBottleTexture, randomPos, 20);
                    BuffsAtScene.Add(healBottle);
                }
                else if (EnemyManager.WaveNumber % 2 == 0 && EnemyManager.WaveNumber != 0 && !IsBuffSpawnedAtThisWave)
                {
                    SpeedBottle speedBottle = new SpeedBottle(Textures.SpeedBottleTexture, randomPos);
                    BuffsAtScene.Add(speedBottle);
                    IsBuffSpawnedAtThisWave = true;
                }
                else
                {
                    PowerBottle powerBottle = new PowerBottle(Textures.PowerBottleTexture, randomPos);
                    BuffsAtScene.Add(powerBottle);     
                    IsBuffSpawnedAtThisWave = true;
                }
            }
            if (Player.IsBuffed)
            {
                BuffsAtScene.Remove(Player.LastTakenBuff);
            }
            foreach (var buff in ActiveBuffs)
            {
                buff.Update();
                if (buff.Duration <= 0)
                {
                    buff.RemoveEffect(player);
                    ActiveBuffs.Remove(buff);
                    break;
                }
            }

        }

        public static void Draw()
        {
            foreach (var buff in BuffsAtScene)
            {
                buff.Draw();
            }
        }
    }
}
