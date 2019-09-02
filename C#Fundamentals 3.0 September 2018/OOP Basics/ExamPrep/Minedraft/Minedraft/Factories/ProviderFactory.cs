using System;
using System.Collections.Generic;

public class ProviderFactory
{
    public Provider CreateProvider(List<string> arr)
    {
        Provider provider;
        string type = arr[0];
        string id = arr[1];
        double energyOutput = double.Parse(arr[2]);

        switch (type)
        {
            case "Solar":
                provider = new SolarProvider(id, energyOutput);
                break;
            case "Pressure":
                provider = new PressureProvider(id, energyOutput);
                break;
            default:
                throw new ArgumentException($"Provider is not registered, because of it's {type}");
        }

        return provider;
    }
}
