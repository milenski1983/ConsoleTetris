namespace ConsoleTetris.Models.Figures
{
    using ConsoleTetris.Interfaces;
    using ConsoleTetris.Utilities;

    public class OFigureClass : Figure
    {
        public OFigureClass()
            : base(BricksConfigurationGenerator.GenerateOConfiguration())
        {
        }
    }
}
