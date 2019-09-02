﻿
public class PressureProvider : Provider
{
    public PressureProvider(string id, double energyOutput)
        : base(id, energyOutput * 1.5)
    {
        this.Type = "Pressure";
    }
    public override string Type { get; }
}
