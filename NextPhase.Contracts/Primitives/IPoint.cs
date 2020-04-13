using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextPhase.Contracts.Primitives
{
    public interface IPoint
    {
        IPoint OffSet(IPoint point);
        
        int X { get; }

        int Y { get; }

        int Z { get; }
    }
}
