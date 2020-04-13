using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextPhase.Contracts.Primitives
{
    public interface ISize
    {
        int Width { get; }
        int Height { get; }
        ISize OffSet(ISize size);
    }
}
