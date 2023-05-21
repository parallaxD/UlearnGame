using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace UlearnGame
{
    public static class BuffManager
    {

        private static float _maxBottleCount = 2;

        public static bool IsBuffSpawnedAtThisWave;
        public static List<Buff> Buffs { get; } = new();

        public static void Update()
        {
            if (EnemyManager.WaveNumber % 3 == 0 && EnemyManager.WaveNumber != 0 && !IsBuffSpawnedAtThisWave)
            {
                var randomPos = new Vector2(Globals.Random.Next(50, 500), Globals.Random.Next(50, 500));
                if (Player.Health <= 90 && Buffs.Count(buff => buff is HealBottle) < _maxBottleCount)
                {
                    HealBottle healBottle = new HealBottle(Textures.HealBottleTexture, randomPos, 20);
                    Buffs.Add(healBottle);
                    IsBuffSpawnedAtThisWave = true;
                }
                else
                {
                    PowerBottle powerBottle = new PowerBottle(Textures.PowerBottleTexture, randomPos);
                    Buffs.Add(powerBottle);
                    IsBuffSpawnedAtThisWave = true;
                }
            }
            if (Player.IsBuffed)
            {
                Buffs.Remove(Player.LastTakenBuff);
            }
        }

        public static void Draw()
        {
            foreach (var buff in Buffs)
            {
                buff.Draw();
            }
        }
    }
}
