using System;
using System.Collections.Generic;

namespace SecretaryST.Models
{
    class DistanceTime
    {
        public static readonly DateTime ZERO_TIME = new DateTime(year: 0, month: 0, day: 0, hour: 0, minute: 0, second: 0);

        private const string StringRepresentationFormat = "";

        private DateTime start;
        private DateTime finish;
        private PauseCollection pauses;

        public DistanceTime(DateTime start)
        {
            this.Start = start;
        }

        public DateTime Start { get => start; set => start = value; }
        public DateTime Finish { get => finish; set => finish = value; }
        public PauseCollection Pauses { get => pauses; }

        public DateTime GetResultTime(bool usePause = true)
        {
            //todo: implement
            return DateTime.Now;
        }

        public void addPause(string key, TimeSpan val)
        {
            pauses[key] = val;
        }

        public override string ToString()
        {
            DateTime result = this.GetResultTime();

            return result.ToString(StringRepresentationFormat);
        }

        internal class PauseCollection
        {
            private Dictionary<string, TimeSpan> dPause;

            public PauseCollection(List<string> keys)
            {
                this.dPause = new Dictionary<string, TimeSpan>();

                keys.ForEach(k => dPause.Add(key: k, value: TimeSpan.Zero));
            }

            public PauseCollection()
            {

            }

            internal TimeSpan this[string key]
            {
                get { return dPause[key]; }

                set
                {
                    if (dPause.ContainsKey(key))
                    {
                        dPause[key] = value;
                    }
                    else
                    {
                        dPause.Add(key, value);
                    }
                }
            }

            internal TimeSpan Sum()
            {
                TimeSpan accum = TimeSpan.Zero;
                foreach (TimeSpan item in dPause.Values)
                {
                    accum.Add(item);
                }
                return accum;
            }
        }
    }
}
