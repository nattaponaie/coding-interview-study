namespace Interview.Core.Decorator;

abstract class Beverage {
    public abstract int Cost();
}

abstract class AddOnDecorator : Beverage {

}

class Expresso : Beverage
{
    public override int Cost()
    {
        return 2;
    }
}

class Caramel : AddOnDecorator
{
    private readonly Beverage _beverage;
    public Caramel(Beverage beverage) {
        _beverage = beverage;
    }

    public override int Cost()
    {
        return _beverage.Cost() + 2;
    }
}

class Chocolate : AddOnDecorator
{
    private readonly Beverage _beverage;
    public Chocolate(Beverage beverage) {
        _beverage = beverage;
    }

    public override int Cost()
    {
        return _beverage.Cost() + 5;
    }
}

public class Main {
    public static void Execute() {
        var expresso = new Caramel(new Expresso());
        Console.WriteLine(new Chocolate(expresso).Cost());
    }
}