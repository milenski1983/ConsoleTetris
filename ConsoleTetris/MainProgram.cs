namespace ConsoleTetris
{
    using System.Threading;

    using ConsoleTetris.Controllers;
    using ConsoleTetris.Controllers.Updaters;
    using ConsoleTetris.Display;
    using ConsoleTetris.Exceptions;
    using ConsoleTetris.Interfaces;

    public class MainProgram
    {
        public static void Main(string[] args)
        {
            const int WindowHeight = 36;
            const int WindowWidth = 20;
            int highestRow = WindowHeight - 2; // actually it is the smallest value

            IDisplay display = new ConsoleDisplay(WindowHeight, WindowWidth);
            IUpdater updater = new ConsoleUpdater(highestRow, WindowWidth, new RowsHandler());
            IEngine engine = new Engine(display, updater);

            display.DisplayWelcomeScreen();
            try
            {
                int choice = display.MenuVisualization();
                switch (choice)
                {
                    case 1: 
                        engine.Run();
                        break;
                    case 2:
                        display.DisplayManual();
                        Main(args);
                        break;
                    default:
                        break;
                }
            }
            catch (InvalidChoiceException ex)
            {
                display.DisplayMessage(ex.Message);
                Thread.Sleep(2000);
                Main(args);
            }
        }
    }
}
