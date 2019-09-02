using PetClinic.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetClinic.Core
{
    public class ClinicManager
    {
        private readonly IList<Pet> pets;
        private readonly IList<Clinic> clinics;

        public ClinicManager()
        {
            pets = new List<Pet>();
            clinics = new List<Clinic>();
        }

        public void CreatePet(string name, int age, string kind)
        {
            Pet pet = new Pet(name, age, kind);
            pets.Add(pet);
        }

        public void CreateClinic(string name, int rooms)
        {
            Clinic clinic = new Clinic(name, rooms);
            clinics.Add(clinic);
        }

        public bool AddPet(string petName, string clinicName)
        {
            Clinic clinic = GetClinic(clinicName);
            Pet pet = GetPet(petName);

            return clinic.Add(pet);
        }

        public bool ReleasePet(string clinicName)
        {
            Clinic clinic = GetClinic(clinicName);

            return clinic.Release();
        }

        public bool DoesHaveEmptyRooms(string clinicName)
        {
            Clinic clinic = GetClinic(clinicName);

            return clinic.HasEmptyRooms();
        }

        public void Print(string clinicName)
        {
            Clinic clinic = GetClinic(clinicName);

            Console.WriteLine(clinic);
        }

        public void PrintSpecificRoom(string clinicName, int roomNumber)
        {
            Clinic clinic = GetClinic(clinicName);

            Pet pet = clinic.GetSpecificRoom(roomNumber);

            if (pet == null)
            {
                Console.WriteLine("Room empty");
                return;
            }
            Console.WriteLine(pet);
        }

        private Pet GetPet(string petName)
        {
            Pet pet = pets.FirstOrDefault(x => x.Name == petName);

            pets.Remove(pet);

            return pet;
        }

        private Clinic GetClinic(string clinicName)
        {
            return clinics.FirstOrDefault(x => x.Name == clinicName);
        }
    }
}
