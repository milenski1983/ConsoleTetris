namespace ConsoleTetris.Exceptions
{
    using System;

    public class InvalidChoiceException : Exception
    {
        public InvalidChoiceException(string message)
            : base(message)
        {
        }

        public InvalidChoiceException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
