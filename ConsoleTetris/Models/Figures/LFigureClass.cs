namespace ConsoleTetris.Models.Figures
{
    using ConsoleTetris.Interfaces;
    using ConsoleTetris.Utilities;

    public class LFigureClass : Figure
    {
        public LFigureClass()
            : base(BricksConfigurationGenerator.GenerateLConfiguration())
        {
        }

        public override void Rotate()
        {
            base.Rotate();
            switch (this.Angle)
            {
                case 90:
                    Rotate90();
                    break;
                case 180:
                    Rotate180();
                    break;
                case 270:
                    Rotate270();
                    break;
                default:
                    Rotate0();
                    break;
            }
        }

        private void Rotate0()
        {
            this.Bricks[0].Position.Row -= 1;
            this.Bricks[1].Position.Col -= 1;
            this.Bricks[2].Position.Row += 1;
            this.Bricks[2].Position.Col -= 2;
            this.Bricks[3].Position.Row += 2;
            this.Bricks[3].Position.Col -= 1;
        }

        private void Rotate270()
        {
            this.Bricks[0].Position.Row -= 1;
            this.Bricks[0].Position.Col -= 1;
            this.Bricks[2].Position.Row += 1;
            this.Bricks[2].Position.Col += 1;
            this.Bricks[3].Position.Col += 2;
        }

        private void Rotate180()
        {
            this.Bricks[0].Position.Row += 2;
            this.Bricks[0].Position.Col -= 1;
            this.Bricks[1].Position.Row += 1;
            this.Bricks[2].Position.Col += 1;
            this.Bricks[3].Position.Row -= 1;
        }

        private void Rotate90()
        {
            this.Bricks[0].Position.Col += 2;
            this.Bricks[1].Position.Row -= 1;
            this.Bricks[1].Position.Col += 1;
            this.Bricks[2].Position.Row -= 2;
            this.Bricks[3].Position.Row -= 1;
            this.Bricks[3].Position.Col -= 1;
        }
    }
}
