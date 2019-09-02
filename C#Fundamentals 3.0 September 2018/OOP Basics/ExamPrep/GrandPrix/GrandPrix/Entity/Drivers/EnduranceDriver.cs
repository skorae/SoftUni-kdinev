
public class EnduranceDriver : Driver
{
    private const double fuelConsuptionPerKm = 1.5;

    public EnduranceDriver(string name, Car car)
        : base(name, car, fuelConsuptionPerKm)
    {
    }
    public override double Speed => base.Speed;
}
