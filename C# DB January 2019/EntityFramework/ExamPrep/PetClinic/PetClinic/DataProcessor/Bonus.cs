﻿namespace PetClinic.DataProcessor
{
    using System;
    using System.Linq;
    using PetClinic.Data;

    public class Bonus
    {
        public static string UpdateVetProfession(PetClinicContext context, string phoneNumber, string newProfession)
        {
            var vet = context.Vets.FirstOrDefault(x => x.PhoneNumber == phoneNumber);

            if (vet == null)
            {
                return $"Vet with phone number {phoneNumber} not found!";
            }

            var oldProffesion = vet.Profession;

            vet.Profession = newProfession;

            context.SaveChanges();

            return $"Edmond Halley's profession updated from {oldProffesion} to {newProfession}.";
        }
    }
}
