namespace ConsoleTetris.Interfaces
{
    using System.Collections.Generic;

    using ConsoleTetris.Controllers;

    public interface IDisplay
    {
        void DisplayWelcomeScreen();

        int MenuVisualization();

        void DisplayManual();

        void DisplayMessage(string message);

        void Draw(IFigure figure, IList<IBrick> stillBricks, PointsHandler score);
    }
}
