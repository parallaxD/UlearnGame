using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UlearnGame
{
    public class TextManager
    {
        SpriteFont font { get; set; }
        
        public void SetFont(SpriteFont font)
        {
            this.font = font;
        }
    }
}
