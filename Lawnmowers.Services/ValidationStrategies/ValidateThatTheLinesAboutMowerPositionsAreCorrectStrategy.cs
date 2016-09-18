using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lawnmowers.Services.ValidationStrategies
{
    public class ValidateThatTheLinesAboutMowerPositionsAreCorrectStrategy : BaseValidatorConditionStrategy, IValidatorConditionStrategy
    {
        private const int MINIMUM_COORDINATE_VALUE = 0;

        public bool ValidateCondition(string instructions)
        {
            if (string.IsNullOrWhiteSpace(instructions))
                return false;

            var linesOfInput = instructions.Split('\n');

            for (var i = 1; i <= linesOfInput.Count() - 2; i += 2)
            {
                if (!ValidateLineAboutMowerPosition(linesOfInput[i].Trim()))
                    return false;
            }

            return true;
        }

        /// <remarks> This is another method that could benefit from refactoring it using the strategy pattern</remarks>
        private bool ValidateLineAboutMowerPosition(string line)
        {
            if (string.IsNullOrWhiteSpace(line))
                return false;

            var lineComponents = line.Split(' ');

            if (lineComponents.Count() != 3)
                return false;

            if (!CheckValidNumberValidationFor(lineComponents[0], MINIMUM_COORDINATE_VALUE))
                return false;

            if (!CheckValidNumberValidationFor(lineComponents[1], MINIMUM_COORDINATE_VALUE))
                return false;

            if (!CheckCoordinatesLetterValidationFor(lineComponents[2]))
                return false;

            return true;
        }

        private bool CheckCoordinatesLetterValidationFor(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return false;

            if (value.Trim().Length > 1)
                return false;

            return ("NSEW".Contains(value)); // 'N' for North, 'S' for South, 'E' for East, 'W' for West
        }
    }
}
