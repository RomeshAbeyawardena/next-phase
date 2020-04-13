using NextPhase.Contracts.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextPhase.Contracts
{
    public interface IPlayerMove
    {
        /// <summary>
        /// Gets requested new position.
        /// </summary>
        IPoint NewPosition { get; }

        /// <summary>
        /// Gets a list of cards to be played during a <see cref="IPlayer">players</see> turn.
        /// </summary>
        IEnumerable<IGameCard> Cards { get; }
    }
}
