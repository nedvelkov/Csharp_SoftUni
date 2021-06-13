using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Chronometer
{
    class Chronometer : IChronometer
    {
        private Stopwatch stopWatch;
        private readonly List<string> laps;
        public Chronometer()
        {
            this.stopWatch = new Stopwatch();
            this.laps = new List<string>();
            this.laps.Add($"Laps:");
        }
        public string GetTime => this.stopWatch.Elapsed.Duration().ToString();

        public List<string> Laps {get {

                if (laps.Count == 1)
                {
                    laps[0] = "Laps: no laps";
                }
               return this.laps;
            }
        }
        public string Lap()
        {
            this.laps.Add($"{this.laps.Count-1}. {GetTime}");
            return GetTime;
        }

        public void Reset()
        {
            this.stopWatch.Restart();
        }

        public void Start()
        {
            this.stopWatch.Start();
        }

        public void Stop()
        {

            this.stopWatch.Stop();
        }
    }
}
