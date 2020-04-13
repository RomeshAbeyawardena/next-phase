using NextPhase.Contracts.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextPhase.Contracts
{
    /// <summary>
    /// Represents the result of a turn.
    /// </summary>
    public interface ITurnResult
    {
        /// <summary>
        /// Gets a value to determine whether the turn was valid.
        /// </summary>
        bool IsMoveValid { get; }

        /// <summary>
        /// Gets the validation message used to display information to the player
        /// </summary>
        string ValidationMessage { get; }

        /// <summary>
        /// Gets the player points accrued during this turn.
        /// </summary>
        long PointsAccrued { get; }

        /// <summary>
        /// Gets the absolute position of the current player's token.
        /// </summary>
        IPoint Position { get; } 

        /// <summary>
        /// Gets the game square the current player's token landed on.
        /// </summary>
        IGameSquare GameSquare { get; }

        /// <summary>
        /// Gets the player.
        /// </summary>
        IPlayer Player { get; }
    }
}
