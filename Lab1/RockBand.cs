using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class RockBand : Band
    {
        public override string Genre => "Rock";
        public RockBand(string bandName, int yearFormed, string members)
         :base(bandName, yearFormed, members)
        {

        }

        public RockBand() :base()
        {

        }

        public override string ToString()
        {
            return $"Rock Band: {BandName}";
        }
    }
}
