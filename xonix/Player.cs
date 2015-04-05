using System;

namespace Xonix
{
    public class Player : Point
    {
        public Player()
        {
        }

        bool unstableMode;

        char footprint = '#';

        int deltaX = 0;
        int deltaY = 0;

        internal void Die()
        {
            deltaX = 0;
            deltaY = 0;
            unstableMode = false;
        }

        public void ChangeDirection(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    deltaY = -1;
                    deltaX = 0;
                    break;
                case ConsoleKey.DownArrow:
                    deltaY = 1;
                    deltaX = 0;
                    break;
                case ConsoleKey.LeftArrow:
                    deltaX = -1;
                    deltaY = 0;
                    break;
                case ConsoleKey.RightArrow:
                    deltaX = 1;
                    deltaY = 0;
                    break;
            }
        }

        internal void Move(Field field)
        {
            if (unstableMode)
            {
                field.SetChar( this, '+');
            }
            else
            {
                field.SetChar(this, footprint);
            }

            X += deltaX;
            Y += deltaY;

            footprint = field.GetChar(this);

            if (footprint == '\0')
            {
                unstableMode = true;
            }

            if (unstableMode)
            {
                if (footprint == '+')
                {
                    throw new GameOverException();
                }
                else if (footprint == '#')
                {
                    Stop();
                    field.Fill();
                }
            }

            field.SetChar(this, '@');
        }

        internal void Stop()
        {
            deltaX = 0;
            deltaY = 0;
            unstableMode = false;
        }
    }
}