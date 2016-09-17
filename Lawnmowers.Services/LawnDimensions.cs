using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lawnmowers.Services
{
    public class ILawnDimensions
    {
        int LengthOfAxisX { get; set; }
        int LengthOfAxisY { get; set; }
    }

    public class LawnDimensions : ILawnDimensions
    {
        int _lengthOfAxisX = 1;
        public int LengthOfAxisX
        {
            get
            {
                return _lengthOfAxisX;
            }
            private set {}
        }

        int _lengthOfAxisY = 1;
        public int LengthOfAxisY
        {
            get
            {
                return _lengthOfAxisY;
            }
            private set { }
        }

        private LawnDimensions()
        {
            // for this particular implementation I want to hide the default constructor to force 
            // instantiating the object and initializing its axis components with some validation
            // through an overloaded public constructor instead
        }

        public LawnDimensions(int lengthOfAxisX, int lengthOfAxisY)
        {
            SetDimensions(lengthOfAxisX, lengthOfAxisY);
        }

        private void SetDimensions(int lengthOfAxisX, int lengthOfAxisY)
        {
            if (lengthOfAxisX <= 0)
                throw new ArgumentException("The value for the axis X must be equal or greater than 1");

            if (lengthOfAxisY <= 0)
                throw new ArgumentException("The value for the axis Y must be equal or greater than 1");

            _lengthOfAxisX = lengthOfAxisX;
            _lengthOfAxisY = lengthOfAxisY;
        }
    }
}
