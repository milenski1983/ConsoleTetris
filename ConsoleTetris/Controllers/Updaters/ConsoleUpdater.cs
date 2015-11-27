namespace ConsoleTetris.Controllers.Updaters
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    using ConsoleTetris.Interfaces;
    using ConsoleTetris.Utilities;

    public class ConsoleUpdater : IUpdater
    {
        private ConsoleKeyInfo key;

        private RowsHandler rowsHandler;

        private int bottomRow;

        private int rowWidth;

        public ConsoleUpdater(int highestRow, int rowWidth, RowsHandler rowsHandler)
        {
            this.HighestRow = highestRow;
            this.rowsHandler = rowsHandler;
            this.bottomRow = this.HighestRow;
            this.rowWidth = rowWidth;
        }

        public int HighestRow { get; set; }

        public RowsHandler RowsHandler
        {
            get
            {
                return this.rowsHandler;
            }
        }

        public bool Update(IFigure figure, IList<IBrick> stillBricks, bool isRunning)
        {
            Thread.Sleep(Settings.SleepTime / 2);
            if (Console.KeyAvailable)
            {
                this.key = Console.ReadKey(true);
                switch (this.key.Key)
                {
                    case ConsoleKey.Escape:
                        isRunning = false;
                        break;
                    case ConsoleKey.LeftArrow:
                        this.MoveFigureASide(figure, stillBricks, -1);
                        break;
                    case ConsoleKey.RightArrow:
                        this.MoveFigureASide(figure, stillBricks, 1);
                        break;
                    case ConsoleKey.UpArrow:
                        this.RotateFigure(figure);
                        break;
                    case ConsoleKey.P:
                        this.PauseGame();
                        break;
                    default:
                        break;
                }
            }

            while (Console.KeyAvailable)
            {
                this.key = Console.ReadKey(true);
            }

            foreach (var brick in figure.Bricks)
            {
                if (!figure.IsFallin)
                {
                    break;
                }

                if (brick.Position.Row == Console.BufferHeight - 2)
                {
                    figure.IsFallin = false;
                    break;
                }

                foreach (var stillBrick in stillBricks)
                {
                    if (brick.Position.Row + 1 == stillBrick.Position.Row && brick.Position.Col == stillBrick.Position.Col)
                    {
                        figure.IsFallin = false;
                        break;
                    }
                }
            }

            if (figure.IsFallin)
            {
                this.MoveFigureDown(figure);
                if (this.key.Key != ConsoleKey.DownArrow)
                {
                    Thread.Sleep(Settings.SleepTime / 2);
                }
            }
            else
            {
                this.AddBricksToList(figure, stillBricks);
                this.HighestRow = this.rowsHandler.FullRowCheck(stillBricks, this.bottomRow, this.HighestRow, this.rowWidth);
                this.HighestRow = this.GetTheTopRow(figure);
            }
            
            return isRunning;
        }

        private void PauseGame()
        {
            this.key = Console.ReadKey(true);
            while (this.key.Key != ConsoleKey.P)
            {
                this.key = Console.ReadKey(true);
            }
        }

        private int GetTheTopRow(IFigure figure)
        {
            int highestRow = this.HighestRow;
            foreach (var brick in figure.Bricks)
            {
                if (brick.Position.Row < highestRow)
                {
                    highestRow = brick.Position.Row;
                }   
            }

            return highestRow;
        }

        private void AddBricksToList(IFigure figure, IList<IBrick> stillBricks)
        {
            foreach (var brick in figure.Bricks)
            {
                stillBricks.Add(brick);
            }
        }

        private void MoveFigureDown(IFigure figure)
        {
            for (int i = 0; i < figure.Bricks.Count; i++)
            {
                figure.Bricks[i].Position.Row++;
            }
        }

        private void RotateFigure(IFigure figure)
        {
            figure.Rotate();
        }

        private void MoveFigureASide(IFigure figure, IList<IBrick> stillBricks, int step)
        {
            bool canMoveASide = this.CheckIfCanMoveASide(figure, stillBricks, step);
            if (canMoveASide)
            {
                for (int i = 0; i < figure.Bricks.Count; i++)
                {
                    figure.Bricks[i].Position.Col += step;
                }
            }
        }

        private bool CheckIfCanMoveASide(IFigure figure, IList<IBrick> stillBricks, int step)
        {
            int sideBarriere = 0;
            int sideStep = 1;
            if (step > 0)
            {
                sideBarriere = Console.BufferWidth - 1;
                sideStep = -1;
            }
            
            foreach (var brick in figure.Bricks)
            {
                if (brick.Position.Col == sideBarriere)
                {
                    return false;
                }

                for (int i = stillBricks.Count - 1; i >= 0; i--)
                {
                    if (brick.Position.Col == stillBricks[i].Position.Col + sideStep && brick.Position.Row == stillBricks[i].Position.Row)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
