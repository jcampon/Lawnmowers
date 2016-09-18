using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lawnmowers.Services.ValidationStrategies
{
    public class BaseValidatorConditionStrategy
    {
        protected bool CheckValidNumberValidationFor(string value, int lowestValidValue)
        {
            var parsedIntValue = 0;

            if (!int.TryParse(value.ToString(), out parsedIntValue))
                return false;

            return parsedIntValue >= lowestValidValue;
        }
    }
}
