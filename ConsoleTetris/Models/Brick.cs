namespace ConsoleTetris.Models
{
    using System;

    using ConsoleTetris.Interfaces;

    public class Brick : IBrick, IEquatable<Brick>
    {
        private readonly char layout = '*';

        public Brick(Position position)
        {
            this.Position = position;
        }

        public char Layout
        {
            get
            {
                return this.layout;
            }
        }

        public Position Position { get; set; }

        public bool Equals(Brick other)
        {
            if (this == null || other == null)
            {
                return false;
            }

            if (this.Position.Row == other.Position.Row && this.Position.Col == other.Position.Col)
            {
                return true;
            }

            return false;
        }
    }
}
