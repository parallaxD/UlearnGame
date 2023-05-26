using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UlearnGame.Scripts
{
    public class SpeedBottle : Buff
    {
        public SpeedBottle(Texture2D texture, Vector2 position) : base(texture, position)
        {
            Duration = 8f;
        }

        public override void ApplyEffect(Player player)
        {
            player.Speed *= 2;
        }
        public override void RemoveEffect(Player player)
        {
            player.Speed = player.DefaultSpeed;
        }
    }
}
