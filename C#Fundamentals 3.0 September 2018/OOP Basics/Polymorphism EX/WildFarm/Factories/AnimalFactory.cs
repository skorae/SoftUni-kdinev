using WildFarm.Objects.Animals;
using WildFarm.Objects.Animals.Birds;
using WildFarm.Objects.Animals.Mamal;
using WildFarm.Objects.Animals.Mamal.Feline;
using WildFarm.Objects.Foods;

namespace WildFarm.Factories
{
    public class AnimalFactory
    {
        public Animal GetAnimal(string[] arr, Food food)
        {
            string type = arr[0].ToLower();
            string name = arr[1];
            double weight = double.Parse(arr[2]);
            Animal animal;

            switch (type)
            {
                case "cat":
                    animal =  new Cat(name, weight, arr[3], arr[4]);
                    return animal;
                case "tiger":
                    animal = new Tiger(name, weight, arr[3], arr[4]);
                    return animal;
                case "dog":
                    animal = new Dog(name, weight, arr[3]);
                    return animal;
                case "mouse":
                    animal = new Mouse(name, weight, arr[3]);
                    return animal;
                case "owl":
                    animal = new Owl(name, weight, double.Parse(arr[3]));
                    return animal;
                case "hen":
                    animal = new Hen(name, weight, double.Parse(arr[3]));
                    return animal;
            }
            return null;
        }
    }
}
