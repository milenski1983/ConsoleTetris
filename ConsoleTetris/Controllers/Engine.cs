namespace ConsoleTetris.Controllers
{
    using System.Collections.Generic;

    using ConsoleTetris.Interfaces;
    using ConsoleTetris.Models;

    public class Engine : IEngine
    {
        private IFigure figure;

        private IList<IBrick> stillBricks;

        private bool isRunning;

        private IDisplay display;

        private IUpdater updater;

        public Engine(IDisplay display, IUpdater updater)
        {
            this.display = display;
            this.updater = updater;
            this.stillBricks = new List<IBrick>();
            this.isRunning = true;
        } 

        public void Run()
        {
            PointsHandler score = new PointsHandler(this.updater.RowsHandler);
            while (this.isRunning)
            {
                if (this.figure == null || !this.figure.IsFallin)
                {
                    this.figure = FigureFactory.CreateFigure();
                }

                this.display.Draw(this.figure, this.stillBricks, score);
                this.isRunning = this.updater.Update(this.figure, this.stillBricks, this.isRunning);
            }
        }
    }
}
