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
            this._hpHealCount = hpHealCount;
        }

        public override void ApplyEffect()
        {
            if (Player.Health + _hpHealCount > Player.MaxHealth)
            {
                Player.Health = Player.MaxHealth;
            }
            else
            {
                Player.Health += _hpHealCount;
            }
        }
    }
}
