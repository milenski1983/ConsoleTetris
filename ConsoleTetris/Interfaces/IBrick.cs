namespace ConsoleTetris.Interfaces
{
    using ConsoleTetris.Models;

    public interface IBrick
    {
        char Layout { get; }

        Position Position { get; set; }
    }
}
