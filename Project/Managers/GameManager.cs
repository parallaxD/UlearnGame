using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UlearnGame
{
    public class GameManager
    {
        private Player _player;

        public GameManager()
        {
            _player = new Player(Globals.Content.Load<Texture2D>("wizzard_f_idle_anim_f0"),
                new Vector2(Globals._windowWidth / 2, Globals._windowHeight / 2),
                300);

            ProjectileManager.Initialize("knight_f_idle_anim_f0");
            EnemyManager.Initialize("big_demon_idle_anim_f0");
            EnemyManager.AddEnemy(new Vector2(1000, 500), 50, 100);
            UIManager.Initialize();
        }
        public void Update()
        {
            _player.Update(EnemyManager.Enemies);
            UIManager.Update();
            ProjectileManager.Update(EnemyManager.Enemies);
            InputManager.Update();
            EnemyManager.Update(_player);
        }
        public void Draw()
        {
            UIManager.Draw();
            ProjectileManager.Draw();
            EnemyManager.Draw();
            _player.Draw(Globals.SpriteBatch, 2);
        }
    }
}
