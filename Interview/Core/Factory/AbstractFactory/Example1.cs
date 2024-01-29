namespace Interview.Core.Factory.AbstractFactory;

interface IButton {
    public string GetButtonType();
}

class Button : IButton {
    private readonly string _type;
    public Button(string type) {
        _type = type;
    }

    public string GetButtonType()
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

class DesktopDialog : IDialog {
    private readonly Button _button;

    public DesktopDialog() {
        _button = new Button("Desktop");
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

interface ICheckbox {
    abstract string Tick();
}

class DesktopCheckbox : ICheckbox
{
    public string Tick()
    {
        return "DesktopCheckbox";
    }
}

class MobileCheckbox : ICheckbox
{
    public string Tick()
    {
        return "MobileCheckbox";
    }
}

interface IGUIFactory {
    abstract IDialog GetDialog();
    abstract ICheckbox GetCheckbox();
}

class DesktopUIFactory : IGUIFactory {
    private readonly IDialog _dialog;
    private readonly ICheckbox _checkbox;
    public DesktopUIFactory() {
        _dialog = new DesktopDialog();
        _checkbox = new DesktopCheckbox();
    }

    public ICheckbox GetCheckbox()
    {
        return _checkbox;
    }

    public IDialog GetDialog()
    {
        return _dialog;
    }
}

class MobileUIFactory : IGUIFactory {
    private readonly IDialog _dialog;
    private readonly ICheckbox _checkbox;
    public MobileUIFactory() {
        _dialog = new MobileDialog();
        _checkbox = new MobileCheckbox();
    }

    public ICheckbox GetCheckbox()
    {
        return _checkbox;
    }

    public IDialog GetDialog()
    {
        return _dialog;
    }
}

public class Main {
    public static void Execute() {
        IGUIFactory guiFactory;
        var device = "Desktop";
        if (device.Equals("Desktop")) guiFactory = new DesktopUIFactory();
        else guiFactory = new MobileUIFactory();
        
        Console.WriteLine(guiFactory.GetDialog().GetButton().GetButtonType());
        Console.WriteLine(guiFactory.GetCheckbox().Tick());
    }
}