using NextPhase.Contracts;
using NextPhase.Contracts.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextPhase.Engine
{
    public class TurnResult : ITurnResult
    {
        private TurnResult(IPlayer player, IGameSquare gameSquare = default)
        {
            Player = player;
            GameSquare = gameSquare;
        } 

        public static ITurnResult Success(IPlayer player, IGameSquare gameSquare, string validationMessage)
        {
            return new TurnResult(player, gameSquare) { IsMoveValid = true, ValidationMessage = validationMessage };
        }

        public static ITurnResult Failed(IPlayer player, string validationMessage)
        {
            return new TurnResult(player) { IsMoveValid = false, ValidationMessage = validationMessage };
        }

        public bool IsMoveValid { get; private set; }

        public long PointsAccrued { get; }

        public IPoint Position { get; }

        public IGameSquare GameSquare { get; }

        public IPlayer Player { get; }

        public string ValidationMessage { get; private set; }
    }
}
