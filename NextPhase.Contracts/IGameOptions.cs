using NextPhase.Contracts.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextPhase.Contracts
{
    public interface IGameOptions
    {
        IRectangle GameArea { get; }
    }
}
