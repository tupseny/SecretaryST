using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretaryST.Models
{
    class PenaltyScore
    {
        internal const bool SATUS_FAILED = true;
        
        private double score;
        private FailedState failed;

        public PenaltyScore(double score=0, bool failed=false)
        {
            if (failed && score > 0)
            {
                throw new System.ArgumentException("Choose only one whether score or failed status");
            }

            this.score = score;
            this.failed = new FailedState(failed);
        }

        internal double Score { get => score; set => score = value; }
        internal FailedState Failed { get => failed; set => failed = value; }

        internal class FailedState
        {
            internal const string FAILED_REPRESENT_SHORT = "сн";
            internal const string FAILED_REPRESENT_FULL = "Снятие";

            private bool failed;

            public FailedState(bool failed)
            {
                this.failed = failed;
            }

            public bool State { get => failed; set => failed = value; }

            public override string ToString()
            {
                return State ? FAILED_REPRESENT_FULL : string.Empty;
            }
        }
    }
}
