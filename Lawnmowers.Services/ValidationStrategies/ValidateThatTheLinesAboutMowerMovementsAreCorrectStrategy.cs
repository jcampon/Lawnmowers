using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lawnmowers.Services.ValidationStrategies
{
    public class ValidateThatTheLinesAboutMowerMovementsAreCorrectStrategy : IValidatorConditionStrategy
    {
        public bool ValidateCondition(string instructions)
        {
            if (string.IsNullOrWhiteSpace(instructions))
                return false;

            var linesOfInput = instructions.Split('\n');

            for (var i = 2; i <= linesOfInput.Count() - 1; i += 2)
            {
                if (!ValidateLineAboutMowerMovement(linesOfInput[i]))
                    return false;
            }

            return true;
        }

        private bool ValidateLineAboutMowerMovement(string line)
        {
            if (string.IsNullOrWhiteSpace(line))
                return false;

            var lineCharacters = line.Trim().ToCharArray();

            foreach (var character in lineCharacters)
            {
                if (!"LRM".Contains(character)) // 'L' for Left, 'R' for Right, 'M' for Move
                    return false;
            }

            return true;
        }
    }
}
