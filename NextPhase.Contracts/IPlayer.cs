using NextPhase.Contracts.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

namespace NextPhase.Contracts
{
    public interface IPlayer
    {
        /// <summary>
        /// Gets the current position of this <see cref="IPlayer">player</see>.
        /// </summary>
        ISubject<IPoint> Position { get; }

        /// <summary>
        /// Gets the current <see cref="IGame">game</see> the current <see cref="IPlayer">player</see> is a member of.
        /// </summary>
        IGame Game { get; }

        /// <summary>
        /// Gets a value to determine whether it's the current <see cref="IPlayer">players</see> turn.
        /// </summary>
        Task<bool> IsCurrentTurn { get; }

        /// <summary>
        /// Get the current <see cref="IPlayer">players</see> score.
        /// </summary>
        long Score { get; }

        /// <summary>
        /// <para>Get the current <see cref="IPlayer">players</see> remaining moves in this turn.</para>
        /// <para>Returns -1 if its not this <see cref="IPlayer">players</see> turn.</para>
        /// </summary>
        int Moves { get; }

        /// <summary>
        /// Returns a list of <see cref="IGameCard">game cards</see> available to use, throughout a game.
        /// </summary>
        IEnumerable<IGameCard> GameCards { get; }

        /// <summary>
        /// Sets available moves count for this <see cref="IPlayer">players</see> current turn
        /// </summary>
        /// <param name="moves">Number of moves to set</param>
        /// <returns></returns>
        Task SetMoves(int moves);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="playerMove"></param>
        /// <returns></returns>
        Task<ITurnResult> PlayTurn(IPlayerMove playerMove);
    }
}
