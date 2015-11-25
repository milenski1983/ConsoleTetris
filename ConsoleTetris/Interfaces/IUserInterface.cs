namespace ConsoleTetris.Interfaces
{
    public interface IUserInterface<T>
    {
        T ReadKey();

        void Display();
    }
}
