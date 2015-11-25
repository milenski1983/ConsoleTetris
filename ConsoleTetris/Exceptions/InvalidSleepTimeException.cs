namespace ConsoleTetris.Exceptions
{
    using System;

    public class InvalidSleepTimeException : Exception
    {
        public InvalidSleepTimeException(string message)
            : base(message)
        {
        }

        public InvalidSleepTimeException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
