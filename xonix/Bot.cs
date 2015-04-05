using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xonix
{
    public class Bot : Point
    {
        public const char Symbol = '*';

        int deltaX = 1;
        int deltaY = 1;

        public Bot(int x, int y, int dx, int dy)
        {
            deltaX = dx;
            deltaY = dy;
            X = x;
            Y = y;
        }

        internal void Move(Field field)
        {
            if (field.GetChar(this) != Symbol)
            {
                throw new GameOverException();
            }

            field.SetChar(this, '\0');

            if (field.GetChar(X + deltaX, Y) == '#')
            {
                deltaX *= -1;
            }

            if (field.GetChar(X, Y + deltaY) == '#')
            {
                deltaY *= -1;
            }

            X += deltaX;
            Y += deltaY;

            var ch = field.GetChar(this);

            if (ch == '+' || ch == '@' )
            {
                throw new GameOverException();
            }

            field.SetChar(this, Symbol);
        }
    }

}
