using DungeonsAndCodeWizards.Entity.Characters;
using DungeonsAndCodeWizards.Entity.Characters.Contracts;
using System;

namespace DungeonsAndCodeWizards.Core.Factory
{
    public class CharacterFactory
    {
        public Character CreateCharacter(string faction, string type,string name)
        {
            Character character;

            if (!Enum.TryParse<Faction>(faction, out var validFaction))
            {
                throw new ArgumentException($"Invalid faction \"{ faction }\"!");
            }

            switch (type)
            {
                case "Warrior":
                    character = new Warrior(name, validFaction);
                    break;
                case "Cleric":
                    character = new Cleric(name, validFaction);
                    break;
                default:
                    throw new ArgumentException($"Invalid character type \"{ type }\"!");
            }

            return character;
        }
    }
}
