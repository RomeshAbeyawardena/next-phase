using NextPhase.Contracts.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextPhase.Shared.Primitives
{
    public class Size : ISize
    {
        public Size(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public int Width { get; }

        public int Height { get; }

        public ISize OffSet(ISize size)
        {
            return new Size(Width + size.Width, Height + size.Height);
        }
    }
}
