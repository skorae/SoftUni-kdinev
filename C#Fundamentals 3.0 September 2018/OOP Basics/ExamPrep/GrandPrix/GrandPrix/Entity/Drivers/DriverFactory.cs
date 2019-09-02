
using System.Collections.Generic;
using System.Linq;

public class DriverFactory
{
    public Driver GetDriver(string[] arr)
    {
        string type = arr[0];
        string name = arr[1];
        int hp = int.Parse(arr[2]);
        double fuelAmount = double.Parse(arr[3]);
        string[] tyreArr = arr.Skip(4).ToArray();

        TyreFactory tyre = new TyreFactory();
        Driver driver;

        switch (type)
        {
            case "Aggressive":
                driver = new AggressiveDriver(name, new Car(hp, fuelAmount, tyre.GetTyre(tyreArr)));
                break;
            case "Endurance":
                driver = new EnduranceDriver(name, new Car(hp, fuelAmount, tyre.GetTyre(tyreArr)));
                break;
            default:
                return null;
        }

        return driver;
    }
}
