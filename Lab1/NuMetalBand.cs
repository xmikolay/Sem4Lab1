using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class NuMetalBand : Band
    {
        public override string Genre => "Nu Metal";
        public NuMetalBand(string bandName, int yearFormed, string members)
        : base(bandName, yearFormed, members)
        {
        }

        public NuMetalBand() : base()
        {
        }

        public override string ToString()
        {
            return $"Nu Metal Band: {BandName}";
        }
    }
}
