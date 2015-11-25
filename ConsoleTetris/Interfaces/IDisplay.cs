namespace ConsoleTetris.Interfaces
{
    using System.Collections.Generic;

    using ConsoleTetris.Controllers;

    public interface IDisplay
    {
        void Draw(IFigure figure, IList<IBrick> stillBricks, PointsHandler score);
    }
}
