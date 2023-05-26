using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace UlearnGame
{
    public interface IEmitter
    {
        Vector2 EmitPosition { get; }
    }
}
