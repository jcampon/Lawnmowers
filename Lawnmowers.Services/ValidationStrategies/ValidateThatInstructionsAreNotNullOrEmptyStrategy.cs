using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lawnmowers.Services.ValidationStrategies
{
    public class ValidateThatInstructionsAreNotNullOrEmptyStrategy : IValidatorConditionStrategy
    {
        public bool ValidateCondition(string instructions)
        {
            return !string.IsNullOrWhiteSpace(instructions);
        }
    }
}
