using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretaryST
{
    class StartTimer
    {
        private DateTime start;
        private TimeSpan interval;
        private DateTime timeBreak;

        private DateTime? current;

        public StartTimer(DateTime start, TimeSpan interval)
        {
            this.start = start;
            this.interval = interval;
        }

        public DateTime Start { get => start; }
        public TimeSpan Interval { get => interval; }
        public DateTime TimeBreak { get => timeBreak; set => timeBreak = value; }

        private DateTime Next()
        {
            if (!current.HasValue)
            {
                current = start;
            }
            else
            {
                current = current.Value.Add(interval);
            }

            return current.Value;
        }

        public string NextString()
        {
            string format = "hh:mm";
            string result = Next().ToString(format);

            return result;
        }

        public void Reset()
        {
            this.current = null;
        }
    }
}
