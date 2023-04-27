using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace UlearnGame
{
    public class Player : Sprite
    {
        public Vector2 Direction;

        public Player(Texture2D texture, Vector2 startPosition, int speed) : base(texture, startPosition, speed) 
        {            
        }

        public void Update()
        {
            Direction = InputManager.GetDirection();

            Position += Direction * Speed * Globals.TotalSeconds;

            var vecToMouse = InputManager.mousePosition - Position;
            Rotation = (float)Math.Atan2(vecToMouse.Y, vecToMouse.X);

            if (InputManager.isMouseClicked)
            {
                Shoot();
            }
        }

        private void Shoot()
        {
            ProjectileData projectileData = new ProjectileData()
            {
                Position = Position,
                Rotation = Rotation,
                Speed = 300,
                Lifespan = 3
            };
            ProjectileManager.AddProjectile(projectileData);    
        }

        public override void Draw(SpriteBatch spriteBatch, float scale, float rotation)
        {
            base.Draw(spriteBatch, scale, 0);
        }

    }

}
