using NextPhase.Contracts.Enumerations;
using NextPhase.Contracts.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextPhase.Contracts
{
    /// <summary>
    /// Represents a game square a <see cref="IPlayer">player</see> can land on.
    /// </summary>
    public interface IGameSquare
    {
        /// <summary>
        /// Get the <see cref="IRectangle">rectangle</see> of this <see cref="IGameSquare">game square</see>
        /// </summary>
        IRectangle Rectangle { get; }

        /// <summary>
        /// Gets the <see cref="GameSquareType">game square type</see> of this <see cref="IGameSquare">game square</see>
        /// </summary>
        GameSquareType Type { get; }

        /// <summary>
        /// Gets the game card type that the <see cref="IPlayer">player</see> should pick up on this turn.
        /// </summary>
        GameCardType GameCardType { get; }
    }
}
