namespace ConsoleTetris.Display
{
    using System;
    using System.Collections.Generic;

    using ConsoleTetris.Controllers;
    using ConsoleTetris.Interfaces;

    public class ConsoleDisplay : IDisplay
    {
        private int windowHeight;

        private int windowWidth;

        public ConsoleDisplay(int windowHeight, int windowWidth)
        {
            this.WindowHeight = windowHeight;
            this.WindowWidth = windowWidth;
            Console.WindowHeight = this.WindowHeight;
            Console.WindowWidth = this.WindowWidth;
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
        }

        public int WindowHeight
        {
            get
            {
                return this.windowHeight;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The height must be greater than 0!");
                }

                this.windowHeight = value;
            }
        }

        public int WindowWidth
        {
            get
            {
                return this.windowWidth;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The width must be greater than 0!");
                }

                this.windowWidth = value;
            }
        }

        public void Draw(IFigure figure, IList<IBrick> stillBricks, PointsHandler score)
        {
            Console.Clear();
            this.DrawBase();
            this.DrawScore(score);
            this.DrawBricks(stillBricks);
            this.DrawBricks(figure.Bricks);
            
        }

        private void DrawScore(PointsHandler score)
        {
            Console.SetCursorPosition(0, this.WindowHeight - 1);
            Console.Write(score.ToString());
        }

        private void DrawBricks(IList<IBrick> bricksCollection)
        {
            foreach (var brick in bricksCollection)
            {
                Console.SetCursorPosition(brick.Position.Col, brick.Position.Row);
                Console.Write(brick.Layout);
            }
        }

        private void DrawBase()
        {
            for (int i = 0; i < this.WindowWidth; i++)
            {
                Console.SetCursorPosition(i, this.WindowHeight - 2);
                Console.Write('-');
            }
        }
    }
}
