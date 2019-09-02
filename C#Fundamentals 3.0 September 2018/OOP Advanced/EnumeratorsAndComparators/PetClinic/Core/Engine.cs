using System;
using System.Collections.Generic;
using System.Text;

namespace PetClinic.Core
{
    public class Engine
    {
        private ClinicManager manager;

        public Engine()
        {
            manager = new ClinicManager();
        }

        public void Run()
        {
            int n = int.Parse(Console.ReadLine());

            while (n != 0)
            {
                string[] arr = Console.ReadLine().Split();

                string command = arr[0];
                string petName;
                string clinicName;

                try
                {
                    switch (command)
                    {
                        case "Create":
                            string type = arr[1];
                            string name = arr[2];
                            int ageOrNumber = int.Parse(arr[3]);

                            if (type == "Pet")
                            {
                                string kind = arr[4];

                                manager.CreatePet(name, ageOrNumber, kind);
                            }
                            else
                            {
                                manager.CreateClinic(name, ageOrNumber);
                            }
                            break;
                        case "Add":
                            petName = arr[1];
                            clinicName = arr[2];

                            Console.WriteLine(manager.AddPet(petName, clinicName));
                            break;
                        case "Release":
                            clinicName = arr[1];

                            Console.WriteLine(manager.ReleasePet(clinicName));
                            break;
                        case "HasEmptyRooms":
                            clinicName = arr[1];

                            Console.WriteLine(manager.DoesHaveEmptyRooms(clinicName));
                            break;
                        case "Print":
                            clinicName = arr[1];

                            if (arr.Length == 2)
                            {
                                manager.Print(clinicName);
                            }
                            else
                            {
                                int room = int.Parse(arr[2]);
                                manager.PrintSpecificRoom(clinicName, room);
                            }
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                n--;
            }
        }
    }
}
