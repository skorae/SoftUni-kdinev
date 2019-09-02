namespace P01_HarvestingFields
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            string command = Console.ReadLine();
            var fields = typeof(HarvestingFields).GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static);

            while (command != "HARVEST")
            {
                string fieldInfo = "";

                switch (command)
                {
                    case "private":
                        fieldInfo = GetInfo("private", fields.Where(x => x.IsPrivate).ToArray());
                        break;
                    case "protected":
                        fieldInfo = GetInfo("protected", fields.Where(x => x.IsFamily).ToArray());
                        break;
                    case "public":
                        fieldInfo = GetInfo("public", fields.Where(x => x.IsPublic).ToArray());
                        break;
                    case "all":
                        foreach (var f in fields)
                        {
                            Console.WriteLine($"{DetermineModifier(f)} {f.FieldType.Name} {f.Name}");
                        }
                        break;

                }
                Console.WriteLine(fieldInfo);
                command = Console.ReadLine();
            }
        }

        private static string DetermineModifier(FieldInfo f)
        {
            if (f.IsPrivate)
            {
                return "private";
            }
            if (f.IsPublic)
            {
                return "public";
            }
            if (f.IsFamily)
            {
                return "protected";
            }
            return " ";
        }

        private static string GetInfo(string accesModifier, FieldInfo[] fields)
        {
            StringBuilder builder = new StringBuilder();

            foreach (var f in fields)
            {
                builder.AppendLine($"{accesModifier} {f.FieldType.Name} {f.Name}");
            }

            return builder.ToString().Trim();
        }
    }
}
