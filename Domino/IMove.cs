using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino
{
    internal interface IMove
    {
        event EventHandler Click;
    }
}
