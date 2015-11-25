namespace ConsoleTetris.Models
{
    using System;

    using ConsoleTetris.Interfaces;
    using ConsoleTetris.Models.Figures;

    public static class FigureFactory
    {
        private static char[] figuresShapes = { 'O', 'I', 'S', 'Z', 'L', 'J', 'T' };

        private static Random randomGenerator = new Random();

        public static IFigure CreateFigure()
        {
            char figureShape = figuresShapes[randomGenerator.Next(0, figuresShapes.Length)];
            switch (figureShape)
            {
                case 'I':
                    return new IFigureClass();
                case 'O':
                    return new OFigureClass();
                case 'S':
                    return new SFigureClass();
                case 'Z':
                    return new ZFigureClass();
                case 'L':
                    return new LFigureClass();
                case 'J':
                    return new JFigureClass();
                case 'T':
                    return new TFigureClass();
                default:
                    throw new ArgumentException();
            }
        }
    }
}
