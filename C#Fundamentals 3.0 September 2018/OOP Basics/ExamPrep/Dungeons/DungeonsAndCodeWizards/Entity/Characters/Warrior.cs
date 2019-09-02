using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Entity.Bags;
using DungeonsAndCodeWizards.Entity.Characters.Contracts;

namespace DungeonsAndCodeWizards.Entity.Characters
{
    public class Warrior : Character, IAttackable
    {
        private const double BaseHealth = 100;
        private const double BaseArmor = 50;
        private const double AbilityPoints = 40;

        public Warrior(string name, Faction faction)
            : base(name, BaseHealth, BaseArmor, AbilityPoints, new Satchel(), faction)
        {
        }

        public override double RestHealMultiplier => 0.2;

        public void Attack(Character character)
        {
            if (this == character)
            {
                throw new InvalidOperationException($"Cannot attack self!");
            }
            if (this.Faction == character.Faction)
            {
                throw new ArgumentException($"Friendly fire!Both characters are from { this.Faction.ToString()} faction!");
            }

            //TODO

        }
    }
}
