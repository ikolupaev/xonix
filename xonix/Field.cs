using System;

namespace Xonix
{
    public class Field
    {
        char[,] field;

        public void Fill()
        {
            var filler = new FieldFiller(this);
            filler.Fill();
        }

        public void SetChar(Point point, char ch)
        {
            SetChar(point.X, point.Y, ch);
        }

        public void SetChar(int x, int y, char ch)
        {
            field[x, y] = ch;
            Console.SetCursorPosition(x, y);
            Console.Write(ch);
            Console.SetCursorPosition(x, y);
        }

        public char GetChar(int x, int y)
        {
            return field[x, y];
        }

        public char GetChar(Point point)
        {
            return GetChar(point.X, point.Y);
        }

        public bool IsBlank(int x, int y)
        {
            return IsBlank(new Point(x, y));
        }

        public bool IsBlank(Point point)
        {
            var ch = GetChar(point);
            return ch == '\0';
        }

        public bool IsBot(Point point)
        {
            return GetChar(point.X, point.Y) == '*';
        }

        public Field(int width, int height)
        {
            Console.WindowWidth = width;
            Console.WindowHeight = height;

            field = new char[width, height];

            for (int x = 0; x < width - 1; x++)
            {
                SetChar(x, 0, '#');
                SetChar(x, 1, '#');

                SetChar(x, height - 2, '#');
                SetChar(x, height - 1, '#');
            }

            for (int y = 2; y < Console.WindowHeight - 2; y++)
            {
                SetChar(0, y, '#');
                SetChar(1, y, '#');

                SetChar(Console.WindowWidth - 3, y, '#');
                SetChar(Console.WindowWidth - 2, y, '#');
            }
        }
    }
}