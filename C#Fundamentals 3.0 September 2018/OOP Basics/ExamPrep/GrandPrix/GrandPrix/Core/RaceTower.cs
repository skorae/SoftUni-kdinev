using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RaceTower
{
    private List<Driver> drivers;
    private DriverFactory factory;
    private Stack<Driver> failiers;
    private int currentLap;
    private int totalLaps;
    private int trackLength;
    private string weathe;

    public RaceTower()
    {
        this.drivers = new List<Driver>();
        this.factory = new DriverFactory();
        this.failiers = new Stack<Driver>();
        this.currentLap = 0;
        this.totalLaps = 0;
        this.trackLength = 0;
        weathe = "Sunny";
    }

    public void SetTrackInfo(int lapsNumber, int trackLength)
    {
        this.totalLaps = lapsNumber;
        this.trackLength = trackLength;
    }
    void RegisterDriver(List<string> commandArgs)
    {
        Driver driver = factory.GetDriver(commandArgs.ToArray());
        drivers.Add(driver);
    }

    void DriverBoxes(List<string> commandArgs)
    {
        //TODO: Add some logic here …
    }

    string CompleteLaps(List<string> commandArgs)
    {
        int n = int.Parse(commandArgs[0]);

        if (n > totalLaps - currentLap)
        {
            throw new ArgumentException($"There is no time! On lap {currentLap}.");
        }

        while (n != 0)
        {
            foreach (var driver in drivers)
            {
                driver.TotalTime += 60 / (trackLength / driver.Speed);
                driver.Car.FuelAmount -= trackLength * driver.FuelConsumptionPerKm;
                driver.Car.Tyre.Degradate();
                PossibleFail(driver);
            }
        }
        return null;
    }
    
    string GetLeaderboard()
    {
        StringBuilder builder = new StringBuilder();
        int positon = 1;
        builder.AppendLine($"Lap {currentLap}/{totalLaps}");

        foreach (var driver in drivers.OrderBy(x => x.TotalTime))
        {
            builder.AppendLine($"{positon++} {driver.Name} {driver.TotalTime}");
        }
        while (failiers.Count != 0)
        {
            builder.AppendLine($"{positon++} {failiers.Peek().Name} {failiers.Peek().Status}");
            failiers.Pop();
        }
        return builder.ToString().Trim();
    }

    void ChangeWeather(List<string> commandArgs)
    {
        //TODO: Add some logic here …
    }
    
    private void PossibleFail(Driver driver)
    {
        if (driver.Car.Tyre.Degradation < 0)
        {
            driver.Status = "Blown Tyre";
            RemoveDriverFromRace(driver);
        }
        else if (driver.Car.FuelAmount< 0)
        {
            driver.Status = "Out of fuel";
            RemoveDriverFromRace(driver);
        }
    }

    private void RemoveDriverFromRace(Driver driver)
    {
        failiers.Push(driver);
        drivers.Remove(driver);
    }
}
