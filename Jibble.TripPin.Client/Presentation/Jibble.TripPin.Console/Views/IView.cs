namespace Jibble.TripPin.Console.Views;

public interface IView
{
    void Display();
    void ReadInput();
}

public interface IView<T> : IView where T : IViewModel
{
    public T Model { get; set; }
}