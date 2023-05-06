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
        private static Texture2D _texture;

        public static void Initialize(string textureName)
        {
            _texture = Globals.Content.Load<Texture2D>(textureName);
        }

        public static void AddEnemy(Vector2 enemyPosition, int enemySpeed, int enemyHealth)
        {
            Enemies.Add(new Enemy(_texture, enemyPosition, enemySpeed, enemyHealth, 5));
        }
        public static void Update(Player player)
        {
            foreach (var enemy in Enemies)
            {
                enemy.Update(player);
            }
            Enemies.RemoveAll(enemy => enemy.Health <= 0);
        }

        public static void Draw()
        {
            foreach (var enemy in Enemies) enemy.Draw(Globals.SpriteBatch, 1, enemy.Rotation, SpriteEffects.None);
        }
    }
}
