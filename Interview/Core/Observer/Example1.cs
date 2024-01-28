namespace Interview.Core.Observer;

interface IObserver {
     public void Update<T>(T text);
}

interface IObservable {
    public void Add(IObserver observer);
    public void Notify<T>(T value);
}

interface ISender {
    public List<string> GetMessages();
}

class Sender : IObservable, ISender {
    private readonly List<IObserver>? _observers = [];
    private readonly List<string> _messages = [];

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
        _messages.Add(text);
        Notify(text);
    }

    public List<string> GetMessages()
    {
        return _messages;
    }
}

class Receiver : IObserver
{
    private readonly Sender _sender;
    private readonly string _name;
    public Receiver(Sender sender, string name) {
        _sender = sender;
        _name = name;
    }
    public void Update<T>(T text)
    {
        Console.WriteLine($"Receiver {_name}: {text}");
        _sender.GetMessages()?.ForEach(msg => Console.WriteLine($"msg: {msg}"));
    }
}

public class Main {
    public static void Execute() {
        var sender = new Sender();

        var receiver = new Receiver(sender, "A");
        var receiver2 = new Receiver(sender, "B");
        var receiver3 = new Receiver(sender, "C");
        sender.Add(receiver);
        sender.Add(receiver2);
        sender.Add(receiver3);

        sender.SendMessage("Hello World1");
        sender.SendMessage("Hello World2");
    }
}