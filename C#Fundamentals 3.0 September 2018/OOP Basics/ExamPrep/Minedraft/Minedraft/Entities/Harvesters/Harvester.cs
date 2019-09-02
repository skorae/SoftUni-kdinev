
using System;

public abstract class Harvester
{
    private double oreOutput;
    private double energyRequirement;

    public Harvester(string id, double oreOutput, double energyRequirement)
    {
        Id = id;
        OreOutput = oreOutput;
        EnergyRequirement = energyRequirement;
    }

    public string Id { get; private set; }

    public double OreOutput
    {
        get { return this.oreOutput; }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException($"Harvester is not registered, because of it's OreOutput");
            }
            this.oreOutput = value;
        }
    }

    public double EnergyRequirement
    {
        get { return this.energyRequirement; }
        private set
        {
            if (value < 0 || value > 20000)
            {
                throw new ArgumentException("Harvester is not registered, because of it's EnergyRequirement");
            }
            this.energyRequirement = value;
        }
    }

    public virtual string Type { get; }
    
}