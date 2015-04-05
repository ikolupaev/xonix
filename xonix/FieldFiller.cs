using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xonix
{
    class FieldFiller
    {
        int botsFilled = 0;

        Field field;

        public FieldFiller(Field field)
        {
            this.field = field;
        }

        public void Fill()
        {
            var cellsToUndo = new List<Point>();

            var blank = FindFirstBlank();
            while (blank != null)
            {
                botsFilled = 0;
                var filled = new List<Point>();

                Flood(blank, filled);

                if (botsFilled > 0)
                {
                    cellsToUndo.AddRange(filled);
                }

                blank = FindFirstBlank();
            }

            foreach (var item in cellsToUndo)
            {
                field.SetChar(item, '\0');
            }

            RemoveFoorprint();
        }

        private void Flood(Point startPoint, List<Point> filled)
        {
            if (field.IsBot(startPoint))
            {
                botsFilled++;
            }

            if (!field.IsBlank(startPoint))
            {
                return;
            }

            field.SetChar(startPoint, '#');

            filled.Add(startPoint);

            var x = startPoint.X;
            var y = startPoint.Y;

            Flood(new Point(x + 1, y), filled);
            Flood(new Point(x - 1, y), filled);
            Flood(new Point(x, y + 1), filled);
            Flood(new Point(x, y - 1), filled);
        }

        private Point FindFirstBlank()
        {
            for (int y = 0; y < Console.WindowHeight - 1; y++)
            {
                for (int x = 0; x < Console.WindowWidth - 1; x++)
                {
                    var ch = field.GetChar(x, y);

                    if ( ch == '\0' )
                    {
                        return new Point { X = x, Y = y };
                    }
                }
            }

            return null;
        }

        private void RemoveFoorprint()
        {
            for (int y = 0; y < Console.WindowHeight - 1; y++)
            {
                for (int x = 0; x < Console.WindowWidth - 1; x++)
                {
                    if (field.GetChar(x, y) == '+')
                    {
                        field.SetChar(x, y, '#');
                    }
                }
            }
        }
    }
}
