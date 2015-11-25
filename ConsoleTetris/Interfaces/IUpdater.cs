namespace ConsoleTetris.Interfaces
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Security.Cryptography.X509Certificates;

    using ConsoleTetris.Controllers;

    public interface IUpdater
    {
        RowsHandler RowsHandler { get; }

        bool Update(IFigure figure, IList<IBrick> stillBricks, bool isRunning);
    }
}
