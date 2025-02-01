using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class Album
    {
        private static Random random = new Random();
        public string AlbumName { get; set; }
        public DateTime YearReleased { get; private set; }
        public int Sales { get; private set; }

        public Album(string albumName) 
        {
            AlbumName = albumName;
            YearReleased = new DateTime(random.Next(1981, 2025), random.Next(1, 13), random.Next(1, 29));
            Sales = random.Next(100000, 100000000);
        }

        public int YearsSinceRelease()
        {
            return DateTime.Now.Year - YearReleased.Year;
        }

        public override string ToString()
        {
            return $"{AlbumName} ({YearsSinceRelease()} years since release)";  
        }
    }
}
