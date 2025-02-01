using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class HeavyMetalBand : Band
    {
        public override string Genre => "Heavy Metal";
        public HeavyMetalBand(string bandName, int yearFormed, string members)
        : base(bandName, yearFormed, members)
        {
        }

        public HeavyMetalBand() : base()
        {
        }

        public override string ToString()
        {
            return $"Heavy Metal Band: {BandName}";
        }
    }
}
