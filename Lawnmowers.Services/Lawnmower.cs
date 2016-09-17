using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lawnmowers.Services
{
    public class Lawnmower
    {
        public LawnDimensions LawnDimensionsReference { get; set; }

        public LocationCoordinates Position { get; set; }

        public char Orientation { get; set; }

        public string Instructions { get; set; }
    }
}
