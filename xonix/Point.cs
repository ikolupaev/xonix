
namespace Xonix
{
    public class Point
    {
        public Point()
        {
        }

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public bool IsEqual(int x, int y)
        {
            return x == X && y == Y;
        }

        public int X { get; set; }
        public int Y { get; set; }
    }
}