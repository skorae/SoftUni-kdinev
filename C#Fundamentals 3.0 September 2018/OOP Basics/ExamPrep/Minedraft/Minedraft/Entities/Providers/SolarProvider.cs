
public class SolarProvider : Provider
{
    public SolarProvider(string id, double energyOutput)
        : base(id, energyOutput)
    {
        this.Type = "Solar";
    }
    public override string Type { get; }
}