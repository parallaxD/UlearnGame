using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Text;
using System.Threading.Tasks;

namespace UlearnGame
{
    public class HealBottle : Buff
    {
        private int _hpHealCount { get; set; }
        public HealBottle(Texture2D texture, Vector2 position, int hpHealCount) : base(texture, position)
        {
            _hpHealCount = hpHealCount;
        }

        public override void ApplyEffect(Player player)
        {
            if (player.Health + _hpHealCount > player.MaxHealth)
            {
                player.Health = player.MaxHealth;
            }
            else
            {
                player.Health += _hpHealCount;
            }
        }
    }
}
