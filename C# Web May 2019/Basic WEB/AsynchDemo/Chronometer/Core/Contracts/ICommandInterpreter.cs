namespace Chronometer.Core.Contracts
{
    public interface ICommandInterpreter
    {
        string Interpret(string command);
    }
}
