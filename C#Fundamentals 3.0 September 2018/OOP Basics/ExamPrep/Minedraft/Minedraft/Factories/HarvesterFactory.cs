
using System;
using System.Collections.Generic;

public class HarvesterFactory
{
    public Harvester CreateHarvester(List<string> arr)
    {
        Harvester harvester;
        string type = arr[0];
        string id = arr[1];
        double oreOutput = double.Parse(arr[2]);
        double energyRequirement = double.Parse(arr[3]);

        switch (type)
        {
            case "Hammer":
                harvester = new HammerHarvester(id, oreOutput, energyRequirement);
                break;
            case "Sonic":
                int sonicFactor = int.Parse(arr[4]);
                harvester = new SonicHarvester(id, oreOutput, energyRequirement, sonicFactor);
                break;
            default:
                throw new ArgumentException($"Harvester is not registered, because of it's {type}");
        }

        return harvester;
    }
}
