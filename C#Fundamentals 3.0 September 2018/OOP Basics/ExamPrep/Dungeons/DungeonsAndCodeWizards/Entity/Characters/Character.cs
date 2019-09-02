using DungeonsAndCodeWizards.Entity.Bags;
using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Entity.Characters.Contracts;
using DungeonsAndCodeWizards.Entity.Items;

namespace DungeonsAndCodeWizards.Entity.Characters
{
    public abstract class Character
    {
        private string name;
        public Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
        {
            this.Name = name;

            this.BaseHealth = health;
            this.Health = health;

            this.BaseArmor = armor;
            this.Armor = armor;

            this.IsAlive = true;
            this.Bag = bag;
            this.Faction = faction;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"Name cannot be null or whitespace!");
                }
                this.name = value;
            }
        }

        public double BaseHealth { get; private set; }

        public double Health { get; set; }

        public double BaseArmor { get; private set; }

        public double Armor { get; set; }

        public double AbilityPoints { get; private set; }

        public Bag Bag { get; private set; }

        public Faction Faction { get; private set; }

        public bool IsAlive { get; set; }

        public virtual double RestHealMultiplier { get; private set; }

        public void TakeDamage(double hitPoints)
        {

            //            For a character to take damage, they need to be alive.
            //The character takes damage equal to the hit points.Taking damage works like so:
            //            The character’s armor is reduced by the hit point amount, then if there are still hit points left, they take that amount of health damage.
            //If the character’s health drops to zero, the character dies(IsAlive become false)
            //Example: Health: 100, Armor: 30, Hit Points: 40  Health: 90, Armor: 0
        }

        public void Rest()
        {
            CheckAlive(this);
            if (this.Health + (BaseHealth * RestHealMultiplier) > BaseHealth)
            {
                this.Health = this.BaseHealth;
                return;
            }
            this.Health += BaseHealth * RestHealMultiplier;
        }

        public void UseItem(Item item)
        {
            CheckAlive(this);
            item.AffectCharacter(this);
        }

        public void UseItemOn(Item item, Character character)
        {
            CheckAlive(this);
            CheckAlive(character);
            character.UseItem(item);
        }

        public void GiveCharacterItem(Item item, Character character)
        {
            CheckAlive(this);
            CheckAlive(character);
            character.ReceiveItem(item);
        }

        public void ReceiveItem(Item item)
        {
            this.Bag.AddItem(item);
        }

        private void CheckAlive(Character character)
        {
            if (!IsAlive)
            {
                throw new ArgumentException("Must be alive to perform this action!");
            }
        }
    }
}
