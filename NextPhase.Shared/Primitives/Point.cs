using NextPhase.Contracts.Primitives;
using NextPhase.Shared.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextPhase.Shared.Primitives
{
    public class Point : IPoint
    {
        public Point(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public int X { get; }

        public int Y { get; }

        public int Z { get; }

        public IPoint OffSet(IPoint point)
        {
            return new Point(X + point.X, Y + point.Y, Z + point.Z);
        }
    }
}
