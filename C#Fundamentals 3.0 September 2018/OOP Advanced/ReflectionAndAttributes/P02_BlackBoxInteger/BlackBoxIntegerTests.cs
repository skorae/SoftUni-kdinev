namespace P02_BlackBoxInteger
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            var type = typeof(BlackBoxInteger);

            var calculator = Activator.CreateInstance(type,true);
            var methods = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);


            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] arr = command.Split("_");

                string method = arr[0];
                int value = int.Parse(arr[1]);

                methods.FirstOrDefault(x => x.Name == method).Invoke(calculator, new object[] { value });

                Console.WriteLine(fields[0].GetValue(calculator));
                command = Console.ReadLine();
            }
        }
    }
}
