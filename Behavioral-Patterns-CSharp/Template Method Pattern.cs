public abstract class Beverage {
    public void PrepareRecipe() {
        BoilWater();
        Brew();
        PourInCup();
        if (CustomerWantsCondiments()) AddCondiments();
    }
    private void BoilWater() => Console.WriteLine("Boiling water");
    private void PourInCup() => Console.WriteLine("Pouring into cup");
    protected abstract void Brew();
    protected abstract void AddCondiments();
    protected virtual bool CustomerWantsCondiments() => true;
}

public class Tea : Beverage {
    protected override void Brew() => Console.WriteLine("Steeping the tea");
    protected override void AddCondiments() => Console.WriteLine("Adding Lemon");
}

public class Coffee : Beverage {
    protected override void Brew() => Console.WriteLine("Dripping Coffee through filter");
    protected override void AddCondiments() => Console.WriteLine("Adding Sugar and Milk");
    protected override bool CustomerWantsCondiments() {
        Console.Write("Add condiments? (y/n): ");
        return Console.ReadLine()?.ToLower() == "y";
    }
}