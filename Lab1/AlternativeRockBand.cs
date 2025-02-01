using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class AlternativeRockBand : Band
    {
        public override string Genre => "Alternative Rock";
        public AlternativeRockBand(string bandName, int yearFormed, string members)
        : base(bandName, yearFormed, members)
        {
        }

        public AlternativeRockBand() : base()
        {
        }

        public override string ToString()
        {
            return $"Alternative Rock Band: {BandName}";
        }
    }
}
