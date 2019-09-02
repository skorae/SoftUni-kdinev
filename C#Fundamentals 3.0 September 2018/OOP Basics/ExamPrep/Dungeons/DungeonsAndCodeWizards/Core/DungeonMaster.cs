using DungeonsAndCodeWizards.Core.Factory;
using DungeonsAndCodeWizards.Entity.Characters;
using DungeonsAndCodeWizards.Entity.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards.Core
{
    public class DungeonMaster
    {
        private CharacterFactory characterFactory;
        private ItemFactory itemFactory;
        private List<Character> characters;
        private Stack<Item> items;

        public DungeonMaster()
        {
            characterFactory = new CharacterFactory();
            itemFactory = new ItemFactory();
            characters = new List<Character>();
            items = new Stack<Item>();
        }

        public string JoinParty(string[] args)
        {
            string faction = args[0];
            string type = args[1];
            string name = args[2];
            Character character = characterFactory.CreateCharacter(faction, type, name);
            characters.Add(character);

            return $"{name} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {
            string type = args[0];
            Item item = itemFactory.CreateItem(type);
            items.Push(item);

            return $"{type} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            string charName = args[0];
            Character character = GetCharacter(charName);
            Item item = items.Pop();
            character.Bag.AddItem(item);

            return $"{charName} picked up {item.GetType().Name}!";
        }

        public string UseItem(string[] args)
        {
            string name = args[0];
            string itemName = args[1];
            Character character = GetCharacter(name);
            Item item = character.Bag.GetItem(itemName);

            character.UseItem(item);

            return $"{character.Name} used {itemName}.";
        }

        public string UseItemOn(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            Character giver = GetCharacter(giverName);
            Character receiver = GetCharacter(receiverName);
            Item item = giver.Bag.GetItem(itemName);

            giver.UseItemOn(item, receiver);

            return $"{giverName} used {itemName} on {receiverName}.";
        }

        public string GiveCharacterItem(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            Character giver = GetCharacter(giverName);
            Character receiver = GetCharacter(receiverName);
            Item item = giver.Bag.GetItem(itemName);

            giver.GiveCharacterItem(item, receiver);

            return $"{giverName} gave {itemName} {receiverName}.";
        }

        public string GetStats()
        {
            throw new NotImplementedException();
        }

        public string Attack(string[] args)
        {
            StringBuilder builder = new StringBuilder();
            string attackerName = args[0];
            string attackTargetName = args[1];

            Character attacker = GetCharacter(attackerName);
            Character defender = GetCharacter(attackTargetName);

            if (attacker is IAttackable attackable)
            {
                attackable.Attack(defender);
                builder.AppendLine( $"{attackerName} attacks {attackTargetName} for {attacker.AbilityPoints} hit points! {attackTargetName} has {defender.Health}/{defender.BaseHealth} HP and {defender.Armor}/{defender.BaseArmor} AP left!");
                if (defender.Health <=0)
                {
                    defender.IsAlive = false;
                    builder.AppendLine($"{defender.Name} is dead!");
                }
                return builder.ToString().Trim();
            }
            throw new ArgumentException($"{attacker.Name} cannot attack!");
        }

        public string Heal(string[] args)
        {
            StringBuilder builder = new StringBuilder();
            string healerNAme = args[0];
            string healingReceiverName = args[1];

            Character healer = GetCharacter(healerNAme);
            Character receiver = GetCharacter(healingReceiverName);

            if (healer is IHealable healable)
            {
                healable.Heal(receiver);
                builder.AppendLine($"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!");
              
                return builder.ToString().Trim();
            }
            throw new ArgumentException($"{healer.Name} cannot heal!");
        }

        public string EndTurn(string[] args)
        {
            throw new NotImplementedException();
        }

        public bool IsGameOver()
        {
            throw new NotImplementedException();
        }

        private Character GetCharacter(string charName)
        {
            Character character = characters.FirstOrDefault(x => x.Name == charName);
            if (character == null)
            {
                throw new ArgumentException($"Character {charName} not found!");
            }

            return character;
        }
    }
}
