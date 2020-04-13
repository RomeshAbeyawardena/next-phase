using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextPhase.Contracts.Primitives
{
    public interface IPointRange
    {
        IPoint Start { get; }
        IPoint End { get; }

        bool IsInRange(IPoint position);
    }
}
