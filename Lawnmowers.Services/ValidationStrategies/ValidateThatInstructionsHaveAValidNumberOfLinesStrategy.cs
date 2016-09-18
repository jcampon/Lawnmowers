using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lawnmowers.Services.ValidationStrategies
{
    public class ValidateThatInstructionsHaveAValidNumberOfLinesStrategy : IValidatorConditionStrategy
    {
        public bool ValidateCondition(string instructions)
        {
            var linesOfInstructions = instructions.Count(nl => nl == '\n') + 1;

            if (linesOfInstructions <= 2)
                return false;

            return (linesOfInstructions % 2 != 0);
        }
    }
}
