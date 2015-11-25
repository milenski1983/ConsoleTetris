namespace ConsoleTetris.Interfaces
{
    using System.Collections.Generic;

    public interface IFigure
    {
        IList<IBrick> Bricks { get; }

        bool IsFallin { get; set; }

        int Angle { get; }

        void Rotate();
    }
}
