using NextPhase.Contracts.Enumerations;
using NextPhase.Contracts.Primitives;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextPhase.Contracts
{
    public interface IGame
    {
        /// <summary>
        /// Gets the game area.
        /// </summary>
        IRectangle GameArea { get; }

        /// <summary>
        /// Gets a list of playable game squares.
        /// </summary>
        IEnumerable<IGameSquare> GameSquares { get; }

        /// <summary>
        /// Gets a list of available game cards in the <see cref="Pack">pack</see>.<see cref="Pack">pack</see>.
        /// </summary>
        IEnumerable<IGameCard> Pack { get; }

        /// <summary>
        /// Gets a random <see cref="IGameCard">card</see> and removes it from the <see cref="Pack">pack</see>.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        Task<IGameCard> GetCard(GameCardType type);

        /// <summary>
        /// Shuffles <see cref="IGameCard">cards</see> in the <see cref="Pack">pack</see>.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<IGameCard>>ShuffleCards(IEnumerable<IGameCard> cards);

        /// <summary>
        /// Invokes a players turn.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="playedMove"></param>
        /// <returns></returns>
        Task<ITurnResult> Play(IPlayer player, IPlayerMove playedMove);

        /// <summary>
        /// Starts with a game with a set list of players and options.
        /// </summary>
        /// <param name="players"></param>
        /// <param name="options"></param>
        /// <returns>Returns an unique id for the new game</returns>
        Task<int> Start(IEnumerable<IPlayer> players, IGameOptions options = default);

        Task Suspend(int gameId);

        Task Continue(int gameId);

    }
}
