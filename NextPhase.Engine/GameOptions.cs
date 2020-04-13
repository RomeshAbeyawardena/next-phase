using NextPhase.Contracts;
using NextPhase.Contracts.Primitives;
using NextPhase.Shared.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextPhase.Engine
{
    public class GameOptions : IGameOptions
    {
        public static IGameOptions Default => new GameOptions((Rectangle) new[] {2000, 1000, 0, 0});
        public GameOptions(IRectangle gameArea)
        {
            GameArea = gameArea;
        }

        public IRectangle GameArea { get; }
    }
}
