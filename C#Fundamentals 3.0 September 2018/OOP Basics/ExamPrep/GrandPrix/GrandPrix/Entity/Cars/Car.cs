
using System;

public class Car
{
    private double fuelAmount;

    public Car(int hp, double fuelAmount, Tyre tyre)
    {
        Hp = hp;
        FuelAmount = fuelAmount;
        Tyre = tyre;
    }

    public int Hp { get; private set; }

    public double FuelAmount
    {
        get { return this.fuelAmount; }
        set
        {
            if (value > 160)
            {
                value = 160;
            }
            this.fuelAmount = value;
        }
    }

    public Tyre Tyre { get; private set; }
}
