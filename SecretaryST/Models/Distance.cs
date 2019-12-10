using SecretaryST.Enums;
using SecretaryST.Structs;
using System.Collections.Generic;
using System;

namespace SecretaryST.Models
{
    internal class Distance
    {
        private readonly Dictionary<GroupIndexAmountStruct, DistanceGroup> _Groups;
        private DistanceLevels _Level;

        public Distance(DistanceLevels level)
        {
            _Groups = new Dictionary<GroupIndexAmountStruct, DistanceGroup>();
            _Level = level;
        }

        internal Dictionary<GroupIndexAmountStruct, DistanceGroup> Groups { get => _Groups; }
        internal DistanceLevels Level { get => _Level; set => _Level = value; }
        internal void AddGroup(GroupIndexAmountStruct groupIndexAmount, DistanceGroup grp)
        {
            if (groupIndexAmount.GroupIndex == -1)
            {
                groupIndexAmount.GroupIndex = this.Groups.Count + 1;
            }

            this.Groups.Add(key: groupIndexAmount, value: grp);
        }
        internal List<Dictionary<string, string>> GetStringRepresentList()
        {
            List<Dictionary<string, string>> lItems = new List<Dictionary<string, string>>();

            foreach (KeyValuePair<GroupIndexAmountStruct, DistanceGroup> kvGroup in Groups)
            {
                Dictionary<string, string> dItems = new Dictionary<string, string>();
                GroupIndexAmountStruct structIndexAmount = kvGroup.Key;
                DistanceGroup group = kvGroup.Value;

                int iRow = 1;
                foreach (KeyValuePair<string, string> kvHeader in Globals.Strings.StartProtocolHeaders)
                {
                    string newKey = kvHeader.Key;
                    string newVal = "";

                    switch (newKey)
                    {
                        case "nr":
                            newVal = iRow.ToString();
                            break;

                        case "name":
                            newVal = group.GetNames();
                            break;
                        case "name-coop":
                            newVal = group.GetNames(joinRang: true);
                            break;

                        case "person-nr":
                        case "both-nr":
                        case "group-nr":
                            newVal = group.GenGroupNr();
                            break;

                        case "rang":
                            newVal = group.GetRangs();
                            break;

                        case "birth":
                            newVal = group.GetBirths();
                            break;

                        case "sex":
                            newVal = group.GetSexs();
                            break;

                        case "compeete_name":
                            newVal = group.GetTypeRepresnet() + "_" + Level;
                            break;

                        case "delegation":
                            newVal = group.Delegation;
                            break;

                        case "region":
                            newVal = group.Region;
                            break;

                        case "chip-nr":
                            newVal = group.ChipNumber.ToString();
                            break;

                        case "distance-rang":
                            newVal = group.GetDistanceRangSum().ToString();
                            break;

                        case "start-time":
                            newVal = "unknown";
                            break;

                        default:
                            throw new ArgumentException("unknown header key");
                    }

                    dItems.Add(key: newKey, value: newVal);

                    iRow++;
                }
                lItems.Add(dItems);
            }

            return lItems;
        }
    }
}
