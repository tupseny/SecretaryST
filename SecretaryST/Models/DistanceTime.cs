using System;

namespace SecretaryST.Models
{
    class DistanceTime
    {
        public static readonly DateTime ZERO_TIME = new DateTime(year: 0, month: 0, day: 0, hour: 0, minute: 0, second: 0);

        private const string StringRepresentationFormat = "";

        private DateTime start;
        private DateTime finish;
        private TimeSpan pause;

        public DistanceTime(DateTime start)
        {
            this.Start = start;
        }

        public DateTime Start { get => start; set => start = value; }
        public DateTime Finish { get => finish; set => finish = value; }
        public TimeSpan Pause { get => pause; set => pause = value; }

        public DateTime GetResultTime(bool usePause = true)
        {
            //todo: implement
            return DateTime.Now;
        }

        public void addPause(TimeSpan val)
        {
            pause.Add(val);
        }

        public override string ToString()
        {
            DateTime result = this.GetResultTime();

            return result.ToString(StringRepresentationFormat);
        }

        internal class PauseCounter
        {
            private Dictionary<> cPause;
        }
    }
}
