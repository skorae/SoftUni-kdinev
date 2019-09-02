using BorderControl.Things;
using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl.Factory
{
    public class CitizenFactory
    {
        public void GetCitizen(string[] arr, List<Buyer> buyers)
        {
            string name;
            string id;
            string birthday;
            string age;
            Buyer buyer;

            switch (arr.Length)
            {
                case 3:
                    name = arr[0];
                    age = arr[1];
                    string group = arr[2];

                    buyer = new Rebel(name, age, group);
                    buyers.Add(buyer);
                    break;
                case 4:
                    name = arr[0];
                    age = arr[1];
                    id = arr[2];
                    birthday = arr[3];

                    buyer = new Person(name, age, id, birthday);
                    buyers.Add(buyer);
                    break;
            }
        }
    }

}