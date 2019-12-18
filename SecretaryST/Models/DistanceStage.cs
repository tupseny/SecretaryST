using System.Collections.Generic;

namespace SecretaryST.Models
{
    class DistanceStages
    {
        private Dictionary<string, DistanceStage> dStages;

        public DistanceStages()
        {
            dStages = new Dictionary<string, DistanceStage>();
        }

        internal Dictionary<string, DistanceStage> StagesDictionary { get => dStages; }

        internal List<DistanceStage> StagesList
        {
            get
            {
                List<DistanceStage> resList = new List<DistanceStage>();
                foreach (DistanceStage item in this.dStages.Values)
                {
                    resList.Add(item);
                }
                return resList;
            }
        }

        internal DistanceStage this[string key]
        {
            set
            {
                if (dStages.ContainsKey(key))
                {
                    dStages[key] = value;
                }
                else
                {
                    this.dStages.Add(key, value);
                }

            }

            get
            {
                return dStages[key];
            }
        }

        //internal void Add(double val)
        //{
        //    this.Add(new DistanceStage(val));
        //}

        //internal void Add(int val)
        //{
        //    this.Add((double)val);
        //}

        //internal void Add(bool failed)
        //{
        //    this.Add(new PenaltyScore(failed: failed));
        //}
    }

    class DistanceStage
    {
        private DistancePenaltyScore penalties;

        public DistanceStage(DistancePenaltyScore penalties)
        {
            this.penalties = penalties;
        }
    }
}
