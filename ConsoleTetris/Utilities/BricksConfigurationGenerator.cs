namespace ConsoleTetris.Utilities
{
    using System;

    using ConsoleTetris.Models;

    public static class BricksConfigurationGenerator
    {
        private static readonly int MidField = Console.BufferWidth / 2;

        public static Brick[] GenerateIConfiguration()
        {
            return new Brick[]
                       {
                           new Brick(new Position(0, MidField - 1)),
                           new Brick(new Position(0, MidField)),
                           new Brick(new Position(0, MidField + 1)),
                           new Brick(new Position(0, MidField + 2)),
                       };
        }

        public static Brick[] GenerateOConfiguration()
        {
            return new Brick[]
                       {
                           new Brick(new Position(0, MidField)), 
                           new Brick(new Position(0, MidField + 1)),
                           new Brick(new Position(1, MidField)),
                           new Brick(new Position(1, MidField + 1)),
                       };
        }

        public static Brick[] GenerateLConfiguration()
        {
            return new Brick[]
                       {
                            new Brick(new Position(0, MidField)),
                            new Brick(new Position(1, MidField)),
                            new Brick(new Position(2, MidField)),
                            new Brick(new Position(2, MidField + 1)),
                       };
        }

        public static Brick[] GenerateJConfiguration()
        {
            return new Brick[]
                       {
                            new Brick(new Position(2, MidField - 1)),
                            new Brick(new Position(2, MidField)),
                            new Brick(new Position(1, MidField)),
                            new Brick(new Position(0, MidField)),
                       };
        }

        public static Brick[] GenerateSConfiguration()
        {
            return new Brick[]
                       {
                            new Brick(new Position(1, MidField - 1)),
                            new Brick(new Position(1, MidField)),
                            new Brick(new Position(0, MidField)),
                            new Brick(new Position(0, MidField + 1)),
                       };
        }

        public static Brick[] GenerateZConfiguration()
        {
            return new Brick[]
                       {
                            new Brick(new Position(0, MidField - 1)),
                            new Brick(new Position(0, MidField)),
                            new Brick(new Position(1, MidField)),
                            new Brick(new Position(1, MidField + 1)),
                       };
        }

        public static Brick[] GenerateTConfiguration()
        {
            return new Brick[]
                       {
                            new Brick(new Position(1, MidField - 1)),
                            new Brick(new Position(1, MidField)),
                            new Brick(new Position(1, MidField + 1)),
                            new Brick(new Position(0, MidField)),
                       };
        }
    }
}
