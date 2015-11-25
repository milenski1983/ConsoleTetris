namespace ConsoleTetris.Models
{
    using System;
    using System.Collections.Generic;

    using ConsoleTetris.Interfaces;

    public abstract class Figure : IFigure
    {
        protected static readonly int MidField = Console.BufferWidth / 2;

        protected Figure(IBrick[] bricks)
        {
            this.IsFallin = true;
            this.Angle = 0;
            this.Bricks = new List<IBrick>(bricks);
        }

        public IList<IBrick> Bricks { get; private set; }

        public bool IsFallin { get; set; }

        public int Angle { get; private set; }

        public virtual void Rotate()
        {
            this.Angle += 90;
            if (this.Angle == 360)
            {
                this.Angle = 0;
            }
        }
    }
}
