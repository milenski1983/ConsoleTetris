namespace ConsoleTetris.Utilities
{
    using ConsoleTetris.Exceptions;

    public static class Settings
    {
        private static int sleepTime = 200;

        public static int SleepTime
        {
            get
            {
                return sleepTime;
            }

            set
            {
                if (sleepTime < 0)
                {
                    throw new InvalidSleepTimeException("You win!");
                }

                sleepTime = value;
            }
        }

        public static int SpeedTime
        {
            get
            {
                return SleepTime / 2;
            }
        }
    }
}
