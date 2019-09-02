
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager
{
    ProviderFactory factoryProvider = new ProviderFactory();
    HarvesterFactory factoryHarvester = new HarvesterFactory();

    List<Provider> providers = new List<Provider>();
    List<Harvester> harvesters = new List<Harvester>();
    string currentMode = "Full";

    double totalEnergyStored = 0;
    double totalOreMined = 0;
    double oreMined = 0;


    public string RegisterHarvester(List<string> arguments)
    {
        Harvester harvester = factoryHarvester.CreateHarvester(arguments);
        harvesters.Add(harvester);

        return $"Successfully registered {harvester.Type} Harvester - {harvester.Id}";
    }

    public string RegisterProvider(List<string> arguments)
    {
        Provider provider = factoryProvider.CreateProvider(arguments);
        providers.Add(provider);

        return $"Successfully registered {provider.Type} Provider - {provider.Id}";
    }

    public string Day()
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendLine($"A day has passed.");

        double dailyEnergy = providers.Sum(y => y.EnergyOutput);
        totalEnergyStored += dailyEnergy;
        oreMined = 0;

        if (totalEnergyStored >= harvesters.Sum(y => y.EnergyRequirement))
        {
            GetDailyMinerOre();
        }
        totalOreMined += oreMined;

        builder.AppendLine($"Energy Provided: {dailyEnergy}");
        builder.AppendLine($"Plumbus Ore Mined: {oreMined}");

        return builder.ToString().Trim();
    }

    public string Mode(List<string> arguments)
    {
        string modeToChange = arguments[0];

        if (Enum.TryParse<Modes>(modeToChange, out var result))
        {
            currentMode = modeToChange;
        }

        return $"Successfully changed working mode to {currentMode} Mode";
    }

    public string Check(List<string> arguments)
    {
        StringBuilder builder = new StringBuilder();
        string id = arguments[0];
        Provider provider;

        Harvester harvester = harvesters.FirstOrDefault(x => x.Id == id);

        if (harvester == null)
        {
            provider = providers.FirstOrDefault(x => x.Id == id);
            if (provider == null)
            {
                throw new ArgumentException($"No element found with id - {id}");
            }
            builder.AppendLine($"{provider.Type} Provider - {id}");
            builder.AppendLine($"Energy Output: {provider.EnergyOutput}");
            return builder.ToString().Trim();
        }
        builder.AppendLine($"{harvester.Type} Harvester - {id}");
        builder.AppendLine($"Ore Output: {harvester.OreOutput}");
        builder.AppendLine($"Energy Requirement: {harvester.EnergyRequirement}");

        return builder.ToString().Trim();
    }

    public string ShutDown()
    {
        StringBuilder builder = new StringBuilder();

        builder.AppendLine($"System Shutdown");
        builder.AppendLine($"Total Energy Stored: {totalEnergyStored}");
        builder.AppendLine($"Total Mined Plumbus Ore: {totalOreMined}");

        return builder.ToString().Trim();
    }

    private void GetDailyMinerOre()
    {

        foreach (var harvester in harvesters)
        {
            switch (currentMode)
            {
                case "Full":
                    oreMined += harvester.OreOutput;
                    totalEnergyStored -= harvester.EnergyRequirement;
                    break;
                case "Half":
                    oreMined += harvester.OreOutput * 0.50;
                    totalEnergyStored -= harvester.EnergyRequirement * 0.60;
                    break;
            }
        }
    }
}
