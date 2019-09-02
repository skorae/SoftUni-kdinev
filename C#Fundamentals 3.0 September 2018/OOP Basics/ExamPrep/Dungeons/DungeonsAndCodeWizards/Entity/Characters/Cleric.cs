using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Entity.Bags;
using DungeonsAndCodeWizards.Entity.Characters.Contracts;

namespace DungeonsAndCodeWizards.Entity.Characters
{
    public class Cleric : Character, IHealable
    {
        private const double BaseHealth = 50;
        private const double BaseArmor = 25;
        private const double AbilityPoints = 40;

        public Cleric(string name, Faction faction)
            : base(name, BaseHealth, BaseArmor, AbilityPoints, new Backpack(), faction)
        {
        }

        public override double RestHealMultiplier => 0.5;

        public void Heal(Character character)
        {
            if (this.Health + AbilityPoints > BaseHealth)
            {
                Health = BaseHealth;
                return;
            }
            character.Health += AbilityPoints;
        }
    }
}
