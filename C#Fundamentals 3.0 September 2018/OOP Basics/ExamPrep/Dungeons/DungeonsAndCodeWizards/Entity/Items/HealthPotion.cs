using DungeonsAndCodeWizards.Entity.Characters;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Entity.Items
{
    public class HealthPotion : Item
    {
        private const int weight = 5;
        public HealthPotion() : base(weight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            if (character.Health + 20 > character.BaseHealth)
            {
                character.Health = character.BaseHealth;
                return;
            }
            character.Health += 20;
        }
    }
}
