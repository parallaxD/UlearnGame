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
        private Background _background;
        public static bool HasPlayerSpeedBoosted = false;
        public GameManager()
        {
            _background = new Background();
            SoundManager.Initialize();
            PlayerManager.Initialize();
            ProjectileManager.Initialize("fireball");
            UIManager.Initialize(PlayerManager.Player);
        }
        public void Update()
        {
            PlayerManager.Update(EnemyManager.Enemies, BuffManager.BuffsAtScene, BuffManager.ActiveBuffs);
            ParticleManager.Update();
            ProjectileManager.Update(EnemyManager.Enemies);
            EnemyManager.Update(PlayerManager.Player);
            BuffManager.Update(PlayerManager.Player);
            UIManager.Update(PlayerManager.Player);
            InputManager.Update();
        }
        public void Draw()
        {
            Globals.SpriteBatch.Begin();
            _background.Draw();
            ParticleManager.Draw();
            UIManager.Draw();
            BuffManager.Draw();
            ProjectileManager.Draw();
            EnemyManager.Draw();
            PlayerManager.Draw(2);
            Globals.SpriteBatch.End();
        }
    }
}
