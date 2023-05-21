using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UlearnGame;

namespace UlearnGame
{
    public class GameManager
    {

        public GameManager()
        {
            PlayerManager.Initialize();
            ProjectileManager.Initialize("fireball");
            UIManager.Initialize();
        }
        public void Update()
        {
            PlayerManager.Update(EnemyManager.Enemies, BuffManager.Buffs);
            BuffManager.Update();
            UIManager.Update();
            ProjectileManager.Update(EnemyManager.Enemies);
            InputManager.Update();
            EnemyManager.Update(PlayerManager.Player);
        }
        public void Draw()
        {
            Globals.SpriteBatch.Begin();
            UIManager.Draw();
            BuffManager.Draw();
            ProjectileManager.Draw();
            EnemyManager.Draw();
            PlayerManager.Draw(2);
            Globals.SpriteBatch.End();
        }
    }
}
