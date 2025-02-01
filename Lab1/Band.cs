using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public abstract class Band : IComparable
    {
        public string BandName { get; set; }
        public int YearFormed { get; set; }
        public string Members { get; set; }
        public List<Album> Albums { get; set; }

        public abstract string Genre { get; }

        public Band(string bandName, int yearFormed, string members)
        {
            BandName = bandName;
            YearFormed = yearFormed;
            Members = members;
            Albums = new List<Album>();     
        }

        public Band()
        {
            Albums = new List<Album>();
        }

        public override string ToString()
        {
            return BandName;
        }


        public int CompareTo(object obj)
        {
            Band otherBand = obj as Band;
            return this.BandName.CompareTo(otherBand.BandName);
        }
    }
}
