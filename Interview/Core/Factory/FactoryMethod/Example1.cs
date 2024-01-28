namespace Interview.Core.Factory.FactoryMethod;

interface IButton {
    public string getType();
}

class Button : IButton {
    private readonly string _type;
    public Button(string type) {
        _type = type;
    }

    public string getType()
    {
        return _type;
    }
}

interface IDialog {
    public Button GetButton();
}

abstract class Dialog : IDialog {
    public abstract Button GetButton();
}

class WindowsDialog : IDialog {
    private readonly Button _button;

    public WindowsDialog() {
        _button = new Button("Windows");
    }

    public Button GetButton()
    {
        return _button;
    }
}

class MobileDialog : IDialog {
    private readonly Button _button;

    public MobileDialog() {
        _button = new Button("Mobile");
    }

    public Button GetButton()
    {
        return _button;
    }
}

public class Main {
    public static void Execute() {
        IDialog dialog;
        var device = "we";
        if (device.Equals("Windows")) dialog = new WindowsDialog();
        else dialog = new MobileDialog();
        
        Console.WriteLine(dialog.GetButton().getType());
    }
}