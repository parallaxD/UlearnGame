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
            ProjectileManager.Initialize();
            _player = new Player(Globals.Content.Load<Texture2D>("wizzard_f_idle_anim_f0"),
                new Vector2(Globals._windowWidth / 2, Globals._windowHeight / 2), 
                300);
        }
        public void Update()
        {
            _player.Update();
            ProjectileManager.Update();
            InputManager.Update();
        }
        public void Draw()
        {
            ProjectileManager.Draw();
            _player.Draw(Globals.SpriteBatch, 2, 0);
        }
    }
}
