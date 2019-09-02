using SIS.MvcFramework;

namespace MishMash.App
{
    class Program
    {
        static void Main(string[] args)
        {
            WebHost.Start(new StartUp());
        }
    }
}
