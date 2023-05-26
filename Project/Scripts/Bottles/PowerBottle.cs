using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UlearnGame
{
    public class PowerBottle: Buff
    {
        public PowerBottle(Texture2D texture, Vector2 position) : base(texture, position)
        {
            Duration = 5f;
        }

        public override void ApplyEffect(Player player)
        {
            player.currentShootRate = player.MinShootRate;
        }
        public override void RemoveEffect(Player player)
        {
            player.currentShootRate = player.MaxShootRate;
        }
    }
}
