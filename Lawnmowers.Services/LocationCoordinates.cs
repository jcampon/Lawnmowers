using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lawnmowers.Services
{
    public class ILocationCoordinates
    {
        int LocationOnAxisX { get; set; }
        int LocationOnAxisY { get; set; }
    }

    public class LocationCoordinates : ILocationCoordinates
    {
        public int LocationOnAxisX { get; set; }
        public int LocationOnAxisY { get; set; }

        private LocationCoordinates()
        {
            // for this particular implementation I want to hide the default constructor to force 
            // instantiating the object and initializing its axis components with some validation
            // through an overloaded public constructor instead
        }

        public LocationCoordinates(int axisX, int axisY)
        {
            SetLocation(axisX, axisY);
        }

        private void SetLocation(int axisX, int axisY)
        {
            if (axisX < 0)
                throw new ArgumentException("The value for the axis X must be equal or greater than 0");

            if (axisY < 0)
                throw new ArgumentException("The value for the axis Y must be equal or greater than 0");

            LocationOnAxisX = axisX;
            LocationOnAxisY = axisY;
        }
    }
}
