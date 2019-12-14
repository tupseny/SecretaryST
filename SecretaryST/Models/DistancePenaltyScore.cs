using System;
using System.Collections.Generic;

namespace SecretaryST.Models
{
    class DistancePenaltyScore
    {
        private List<PenaltyScore> penalties;
        private int sum;
        private int failCount;

        public DistancePenaltyScore()
        {
            penalties = new List<PenaltyScore>();
        }

        public int Sum { get => sum; }
        public int FailCount { get => failCount; }
        internal List<PenaltyScore> Penalties { get => penalties; }

        internal void Add(PenaltyScore val)
        {
            if (val is null)
            {
                throw new ArgumentNullException(nameof(val));
            }

            this.penalties.Add(val);

            if (val.Failed.State)
            {
                failCount += 1;
            }
            else
            {
                sum += (int)val.Score;
            }
        }

        internal void Add(double val)
        {
            this.Add(new PenaltyScore(val));
        }
        
        internal void Add(int val)
        {
            this.Add((double)val);
        }

        internal void Add(bool failed)
        {
            this.Add(new PenaltyScore(failed = Failed))
        }
    }
}
