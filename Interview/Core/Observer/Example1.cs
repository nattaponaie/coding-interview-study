namespace Interview.Core.Observer;

interface IObserver {
     public void Update<T>(T text);
}

interface IObservable {
    public void Add(IObserver observer);
    public void Notify<T>(T value);
}

class Sender : IObservable {
    private readonly List<IObserver>? _observers = [];

    public void Add(IObserver observer)
    {
        _observers?.Add(observer);
    }

    public void Notify<T>(T text)
    {
        var ob = _observers?.FirstOrDefault();
        _observers?.ForEach(ob => ob.Update(text));
    }

    public void SendMessage(string text) {
        Console.WriteLine("Send: " + text);
        Notify(text);
    }
}

class Receiver : IObserver
{
    private readonly string _name;
    public Receiver(string name) {
        _name = name;
    }
    public void Update<T>(T text)
    {
        Console.WriteLine($"Receiver {_name}: {text}");
    }
}

public class Main {
    public static void Execute() {
        var sender = new Sender();

        var receiver = new Receiver("A");
        var receiver2 = new Receiver("B");
        var receiver3 = new Receiver("C");
        sender.Add(receiver);
        sender.Add(receiver2);
        sender.Add(receiver3);

        sender.SendMessage("Hello World1");
        sender.SendMessage("Hello World2");
    }
}