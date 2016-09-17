using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lawnmowers.Services
{
    public class ILawnDimensions
    {
        int LengthOfAxisX { get; }
        int LengthOfAxisY { get; }
    }

    public class LawnDimensions : ILawnDimensions
    {
        private LocationCoordinates _topRightCornerLocation;

        public int LengthOfAxisX
        {
            get
            {
                return _topRightCornerLocation.LocationOnAxisX;
            }
        }

        public int LengthOfAxisY
        {
            get
            {
                return _topRightCornerLocation.LocationOnAxisY;
            }
        }

        private LawnDimensions()
        {
            // for this particular implementation I want to hide the default constructor to force 
            // instantiating the object and initializing its axis components with some validation
            // through an overloaded public constructor instead
        }

        public LawnDimensions(LocationCoordinates topRightCornerLocation)
        {
            SetDimensions(topRightCornerLocation);
        }

        private void SetDimensions(LocationCoordinates topRightCornerLocation)
        {
            if (topRightCornerLocation.LocationOnAxisX <= 0)
                throw new ArgumentException("The value for the axis X must be equal or greater than 1");

            if (topRightCornerLocation.LocationOnAxisY <= 0)
                throw new ArgumentException("The value for the axis Y must be equal or greater than 1");

            _topRightCornerLocation = topRightCornerLocation;
        }
    }
}
