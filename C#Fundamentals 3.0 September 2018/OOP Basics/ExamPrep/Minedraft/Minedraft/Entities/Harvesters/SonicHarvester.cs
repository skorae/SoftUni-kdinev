﻿
public class SonicHarvester : Harvester
{
    private int sonicFactor;

    public SonicHarvester(string id, double oreOutput, double energyRequirement, int sonicFactor)
        : base(id, oreOutput,energyRequirement / sonicFactor)
    {
        this.sonicFactor = sonicFactor;
        this.Type = "Sonic";
    }
    public override string Type { get; }
}
