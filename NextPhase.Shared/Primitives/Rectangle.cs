using NextPhase.Contracts.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextPhase.Shared.Primitives
{
    public class Rectangle : IRectangle
    {
        public Rectangle(ISize size, IPoint location)
        {
            Size = size;
            Location = location;
        }

        public Rectangle(ISize size, int x, int y, int z)
            : this(size, new Point(x, y, z))
        {
        }

        public Rectangle(int width, int height, IPoint location)
            : this(new Size(width, height), location)
        {
        }

        private Rectangle()
        {

        }

        public IPoint Location { get; private set; }

        public ISize Size { get; private set; }

        public int Left => X;

        public int Right => Left + Width;

        public int Top => Y;

        public int Bottom => Top + Height;

        public int X => Location.X;

        public int Y => Location.Y;

        public int Z => Location.Z;

        public int Width => Size.Width;

        public int Height => Size.Height;

        public bool IsInRange(IPoint point)
        {
            return (point.X >= Left && point.X <= Right)
                && (point.Y >= Top && point.Y <= Bottom);
        }

        public static explicit operator Rectangle(int[] values){
            var rectangle = new Rectangle();

            if(values.Length < 4)
            { 
                throw new ArgumentOutOfRangeException();
            }

            rectangle.Size = new Size(values[0], values[1]);

            if(values.Length == 5)
            { 
                rectangle.Location = new Point(values[2], values[3], values[4]);
            }
            else
            {
                rectangle.Location = new Point(values[2], values[3], 0);
            }
            return rectangle;
        }

        IPoint IPoint.OffSet(IPoint point)
        {
            return Location.OffSet(point);
        }

        ISize ISize.OffSet(ISize size)
        {
            return Size.OffSet(size);
        }


        public IRectangle OffSet(ISize size, IPoint point)
        {
            return new Rectangle(Size.OffSet(size), Location.OffSet(point));
        }
    }
}
