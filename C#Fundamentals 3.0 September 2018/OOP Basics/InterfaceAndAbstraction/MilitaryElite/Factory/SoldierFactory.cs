using MilitaryElite.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Factory
{
    public class SoldierFactory
    {
        List<Private> privates = new List<Private>();
        public void SortSoldiers(string[] arr, List<Soldier> soldiers)
        {
            string type = arr[0];
            int id = int.Parse(arr[1]);
            string firstName = arr[2];
            string lastName = arr[3];
            decimal salary = 0;
            string specializationType = "";
            Soldier soldier;

            switch (type)
            {
                case "Private":
                    salary = decimal.Parse(arr[4]);

                    soldier = new Private(firstName, lastName, id, salary);
                    Private @private = new Private(firstName, lastName, id, salary);
                    privates.Add(@private);
                    soldiers.Add(soldier);
                    break;
                case "LieutenantGeneral":
                    salary = decimal.Parse(arr[4]);
                    List<int> ids = new List<int>();

                    if (arr.Length > 4)
                    {
                        for (int i = 5; i < arr.Length; i++)
                        {
                            ids.Add(int.Parse(arr[i]));
                        }
                    }

                    soldier = new LieutenantGeneral(firstName, lastName, id, salary, ids, privates);
                    soldiers.Add(soldier);
                    break;
                case "Engineer":
                    salary = decimal.Parse(arr[4]);
                    specializationType = arr[5];

                    if (!IsSpecializationValid(specializationType))
                    {
                        return;
                    }

                    List<KeyValuePair<string, int>> skills = new List<KeyValuePair<string, int>>();
                    if (arr.Length > 5)
                    {
                        for (int i = 6; i < arr.Length; i += 2)
                        {
                            string skill = arr[i];
                            int time = int.Parse(arr[i + 1]);
                            skills.Add(new KeyValuePair<string, int>(skill, time));
                        }
                    }

                    soldier = new Engineer(firstName, lastName, id, salary, specializationType, skills);
                    soldiers.Add(soldier);
                    break;
                case "Commando":
                    salary = decimal.Parse(arr[4]);
                    specializationType = arr[5];

                    if (!IsSpecializationValid(specializationType))
                    {
                        return;
                    }
                    List<KeyValuePair<string, string>> missions = new List<KeyValuePair<string, string>>();

                    if (arr.Length > 5)
                    {
                        for (int i = 6; i < arr.Length; i += 2)
                        {
                            string mission = arr[i];
                            string state = arr[i + 1];
                            if (!CompleteMission(mission, state, missions))
                            {
                                continue;
                            }
                            missions.Add(new KeyValuePair<string, string>(mission, state));
                        }
                    }
                    soldier = new Commando(firstName, lastName, id, salary, specializationType, missions);
                    soldiers.Add(soldier);
                    break;
                case "Spy":
                    int codeNumber = int.Parse(arr[4]);
                    soldier = new Spy(firstName, lastName, id, codeNumber);
                    soldiers.Add(soldier);
                    break;
            }
        }

        private bool CompleteMission(string mission, string state, List<KeyValuePair<string, string>> missions)
        {
            if (state == "inProgress" || state == "Finished")
            {
                return true;
            }
            return false;
        }

        private bool IsSpecializationValid(string specializationType)
        {
            if (specializationType == "Airforces" || specializationType == "Marines")
            {
                return true;
            }
            return false;
        }
    }
}
