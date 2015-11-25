namespace ConsoleTetris.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using ConsoleTetris.Events;
    using ConsoleTetris.Interfaces;

    public class RowsHandler
    {
        public event RemoveRowEventHandler RemoveRow;

        public int FullRowCheck(IList<IBrick> stillBricks, int bottomRow, int topRow, int fullRowLength) 
        {
            for (int currentRow = topRow; currentRow <= bottomRow; currentRow++)
            {
                IList<IBrick> bricksFromCurrentRow = new List<IBrick>();
                foreach (var stillBrick in stillBricks)
                {
                    if (stillBrick.Position.Row == currentRow)
                    {
                        bricksFromCurrentRow.Add(stillBrick);
                    }
                }

                //var bricksFromCurrentRow = stillBricks
                //    .Where(brick => brick.Position.Row == currentRow)
                //    .Select(brick => brick);

                if (bricksFromCurrentRow.Count() == fullRowLength)
                {
                    foreach (var brick in bricksFromCurrentRow)
                    {
                        stillBricks.Remove(brick);
                    }

                    foreach (var stillBrick in stillBricks)
                    {
                        if (stillBrick.Position.Row < currentRow)
                        {
                            stillBrick.Position.Row++;
                        }
                    }

                    topRow++;
                    currentRow--;
                    this.RemoveRow(this, EventArgs.Empty);
                }
            }

            return topRow;
        }
    }
}
