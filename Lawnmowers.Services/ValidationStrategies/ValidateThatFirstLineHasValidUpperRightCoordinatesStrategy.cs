using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lawnmowers.Services.ValidationStrategies
{
    public class ValidateThatFirstLineHasValidUpperRightCoordinatesStrategy : BaseValidatorConditionStrategy, IValidatorConditionStrategy
    {
        private const int MINIMUM_LENGTH_OF_LAWN = 1;

        public bool ValidateCondition(string instructions)
        {
            var firstLineComponents = instructions.Split('\n')  // split the instructions input into lines
                                                  .First()      // get the first line
                                                  .Trim()       // trims the line for extra sanity check
                                                  .Split(' ');  // split the first line into parts separated by space

            if (firstLineComponents.Count() != 2)
                return false;

            if (!CheckValidNumberValidationFor(firstLineComponents[0], MINIMUM_LENGTH_OF_LAWN))
                return false;

            if (!CheckValidNumberValidationFor(firstLineComponents[1], MINIMUM_LENGTH_OF_LAWN))
                return false;

            return true;
        }
    }
}
