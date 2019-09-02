using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetClinic.Entity
{
    public class Clinic
    {
        private readonly int middleRoom;

        private string name;
        private Pet[] totalRooms;

        public Clinic(string name, int rooms)
        {
            Name = name;
            CheckMiddleRoomIndex(rooms);
            totalRooms = new Pet[rooms];
            middleRoom = totalRooms.Length / 2;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public bool Add(Pet pet)
        {
            bool result = false;

            for (int i = 0; i <= middleRoom; i++)
            {
                if (totalRooms[middleRoom - i] == null)
                {
                    totalRooms[middleRoom - i] = pet;
                    result = true;
                    break;
                }

                if (totalRooms[middleRoom + i] == null)
                {
                    totalRooms[middleRoom + i] = pet;
                    result = true;
                    break;
                }
            }

            return result;
        }

        public bool Release()
        {
            for (int i = middleRoom; i < totalRooms.Length; i++)
            {
                if (totalRooms[i] != null)
                {
                    totalRooms[i] = null;
                    return true;
                }
            }

            for (int i = 0; i < middleRoom; i++)
            {
                if (totalRooms[i] != null)
                {
                    totalRooms[i] = null;
                    return true;
                }
            }
            return false;
        }

        public bool HasEmptyRooms()
        {
            return totalRooms.Any(x => x == null);
        }

        public Pet GetSpecificRoom(int roomNumber)
        {
            return totalRooms[roomNumber - 1];
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            foreach (var pet in totalRooms)
            {
                if (pet == null)
                {
                    builder.AppendLine("Room empty");
                    continue;
                }
                builder.AppendLine(pet.ToString());
            }

            return builder.ToString().Trim();
        }

        private void CheckMiddleRoomIndex(int rooms)
        {
            if (rooms % 2 == 0)
            {
                throw new ArgumentException("Invalid Operation!");
            }
        }
    }
}
