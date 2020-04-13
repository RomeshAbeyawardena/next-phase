using NextPhase.Contracts;
using NextPhase.Contracts.Enumerations;
using NextPhase.Contracts.Loaders;
using NextPhase.Contracts.Primitives;
using NextPhase.Shared.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextPhase.Engine
{
    public class DefaultGame : IGame
    {
        private readonly IGamePackLoader gamePackLoader;
        private readonly IGameMapLoader gameMapLoader;
        private IGameOptions gameOptions;

        private int CurrentGameId { get; set; }

        public DefaultGame(IGamePackLoader gamePackLoader, IGameMapLoader gameMapLoader)
        {
            this.gamePackLoader = gamePackLoader;
            this.gameMapLoader = gameMapLoader;
        }

        /// <inheritdoc/>
        public IRectangle GameArea { get; private set; }

        /// <inheritdoc/>
        public IEnumerable<IGameCard> Pack { get; private set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IEnumerable<IGameSquare> GameSquares { get; private set; }

        /// <inheritdoc/>
        public Task Continue(int gameId)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<IGameCard> GetCard(GameCardType type)
        {
            if(Pack == null || !Pack.Any(card => card.Type == type))
                throw new NullReferenceException($"Either no cards found or no cards of type not found");

            var card = Pack
                .FirstOrDefault(card => card.Type == type);

            Pack.Remove(card);

            return Task.FromResult(card);
        }

        /// <inheritdoc/>
        public Task<IEnumerable<IGameCard>> ShuffleCards(IEnumerable<IGameCard> gameCards)
        {
            var totalGameCards = gameCards.Count();
            var usedIndexes = new List<int>();
            var randomGenerator = new Random();
            var reorderedGameCards = new List<IGameCard>();
            var queue = new Queue<IGameCard>(gameCards);

            while(queue.TryDequeue(out var gameCard))
            { 
                var index = GetUnusedIndex(
                    usedIndexes, 
                    () => randomGenerator.Next(0, totalGameCards - 1));
                
                usedIndexes.Add(index);

                reorderedGameCards
                    .Insert(index, gameCard);
            }

            return Task.FromResult(reorderedGameCards.ToArray().AsEnumerable());
        }

        /// <inheritdoc/>
        public async Task<ITurnResult> Play(IPlayer player, IPlayerMove playedMove)
        {
            if (!await player.IsCurrentTurn)
            {
                return TurnResult.Failed(player, "Its currently not your turn.");
            }

            var gameSquare = GameSquares.SingleOrDefault(gameSquare => gameSquare.Rectangle.IsInRange(playedMove.NewPosition));

            if(gameSquare == null)
            {
                return TurnResult.Failed(player, "Invalid gameSquare");
            }

            return TurnResult.Success(player, gameSquare, "Acceptable move");
        }

        /// <inheritdoc/>
        public async Task<int> Start(IEnumerable<IPlayer> players, IGameOptions options = null)
        {
            if(options == null)
                gameOptions = GameOptions.Default;

            var pack = await gamePackLoader.Load();
            Pack = await ShuffleCards(pack);
            GameArea = options.GameArea;
            GameSquares = await gameMapLoader.Load();

            return CurrentGameId++;
        }

        /// <inheritdoc/>
        public Task Suspend(int gameId)
        {
            throw new NotImplementedException();
        }

        private int GetUnusedIndex(IEnumerable<int> usedIndexes, Func<int> getIndex)
        {
            var newIndex = getIndex();
            if(usedIndexes.Contains(newIndex))
            {
                return GetUnusedIndex(usedIndexes, getIndex);
            }

            return newIndex;
        } 
    }
}
