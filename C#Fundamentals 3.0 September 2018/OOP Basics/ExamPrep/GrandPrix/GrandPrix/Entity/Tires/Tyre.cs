
public abstract class Tyre
{
    private double defaultDegradation = 100;

    public Tyre(string name, double hardness)
    {
        Name = name;
        Hardness = hardness;
        Degradation = defaultDegradation;
    }

    public string Name { get; private set; }

    public double Hardness { get; private set; }

    public double Degradation { get; private set; }

    public double Degradate()
    {
       return this.Degradation -= this.Hardness;
    }
}

