using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextPhase.Contracts.Loaders
{
    public interface IGameMapLoader
    {
        Task<IEnumerable<IGameSquare>> Load();
    }
}
