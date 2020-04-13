using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextPhase.Contracts.Primitives
{
    public interface IRectangle : IPoint, ISize
    {
        IPoint Location { get; }
        ISize Size { get; }

        int Left { get; }
        int Right { get; }
        int Top { get; }
        int Bottom { get; }

        bool IsInRange(IPoint point);
        IRectangle OffSet(ISize size, IPoint point);
    }
}
