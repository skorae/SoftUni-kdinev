namespace Chronometer.Core.Contracts
{
    public interface ICommandManager
    {
        string Start();

        string Stop();

        string Lap();

        string Laps();

        string Time();

        string Reset();

        void Exit();
    }
}
