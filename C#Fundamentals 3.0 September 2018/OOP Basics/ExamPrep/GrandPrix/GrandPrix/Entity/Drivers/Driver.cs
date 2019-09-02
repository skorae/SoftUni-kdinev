
public abstract class Driver
{
    public Driver(string name, Car car, double fuelConsuptionPerKm)
    {
        Name = name;
        TotalTime = 0;
        Car = car;
        FuelConsumptionPerKm = fuelConsuptionPerKm;
    }

    public string Name { get; private set; }

    public double TotalTime { get; set; }

    public Car Car { get; private set; }

    public double FuelConsumptionPerKm { get; private set; }

    public virtual double Speed => (Car.Hp + Car.Tyre.Degradation) / Car.FuelAmount;

    public string Status { get; set; }

}
