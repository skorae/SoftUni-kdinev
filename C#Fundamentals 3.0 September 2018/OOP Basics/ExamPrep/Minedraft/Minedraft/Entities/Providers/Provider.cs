
using System;

public abstract class Provider
{
    private double energyOutput;

    public Provider(string id, double energyOutput)
    {
        Id = id;
        EnergyOutput = energyOutput;
    }

    public string Id { get; private set; }

    public double EnergyOutput
    {
        get { return this.energyOutput; }
        private set
        {
            if (value < 0 || value > 10000)
            {
                throw new ArgumentException($"Provider is not registered, because of it's EnergyOutput");
            }
            this.energyOutput = value;
        }
    }

    public virtual string Type { get; }
}
