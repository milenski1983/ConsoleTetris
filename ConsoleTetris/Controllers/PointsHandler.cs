namespace ConsoleTetris.Controllers
{
    using System;

    public class PointsHandler
    {
        private RowsHandler rowsHandler;

        public PointsHandler(RowsHandler rowsHandler)
        {
            this.Score = 0;
            this.rowsHandler = rowsHandler;

            this.rowsHandler.RemoveRow += this.OnRowRemoved;
        }

        public int Score { get; private set; }

        public override string ToString()
        {
            return string.Format("Your score: {0}", this.Score);
        }

        private void OnRowRemoved(object sender, EventArgs args)
        {
            this.Score += 10;
        }
    }
}
