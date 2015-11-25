namespace ConsoleTetris.Models.Figures
{
    using ConsoleTetris.Interfaces;
    using ConsoleTetris.Utilities;

    public class ZFigureClass : Figure
    {
        public ZFigureClass()
            : base(BricksConfigurationGenerator.GenerateZConfiguration())
        {
        }

        public override void Rotate()
        {
            base.Rotate();
            switch (this.Angle)
            {
                case 90:
                case 270:
                    this.Rotate90();
                    break;
                default:
                    this.Rotate0();
                    break;
            }
        }

        private void Rotate0()
        {
            this.Bricks[0].Position.Col -= 1;
            this.Bricks[1].Position.Row -= 1;
            this.Bricks[2].Position.Col += 1;
            this.Bricks[3].Position.Row -= 1;
            this.Bricks[3].Position.Col += 2;
        }

        private void Rotate90()
        {
            this.Bricks[0].Position.Col += 1;
            this.Bricks[1].Position.Row += 1;
            this.Bricks[2].Position.Col -= 1;
            this.Bricks[3].Position.Row += 1;
            this.Bricks[3].Position.Col -= 2;
        }
    }
}
