
public class AggressiveDriver : Driver
{
    private const double fuelConsuptionPerKm = 2.7;

    public AggressiveDriver(string name, Car car)
        : base(name, car, fuelConsuptionPerKm)
    {
    }

    public override double Speed => ((this.Car.Hp + this.Car.Tyre.Degradation) / this.Car.FuelAmount) * 1.3;
}