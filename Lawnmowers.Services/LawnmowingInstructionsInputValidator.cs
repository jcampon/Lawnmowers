using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Lawnmowers.Services.ValidationStrategies;

namespace Lawnmowers.Services
{
    public interface ILawnmowingInstructionsInputValidator
    {
        bool Validate(string instructions);
    }

    public class LawnmowingInstructionsInputValidator : ILawnmowingInstructionsInputValidator
    {
        public List<IValidatorConditionStrategy> ValidationStrategies { get; set; }

        public LawnmowingInstructionsInputValidator()
        {
            ValidationStrategies = new List<IValidatorConditionStrategy>()
            {
                new ValidateThatInstructionsAreNotNullOrEmptyStrategy(),
                new ValidateThatInstructionsHaveAValidNumberOfLinesStrategy(),
                new ValidateThatFirstLineHasValidUpperRightCoordinatesStrategy(),
                new ValidateThatTheLinesAboutMowerPositionsAreCorrectStrategy(),
                new ValidateThatTheLinesAboutMowerMovementsAreCorrectStrategy()
            };
        }

        public bool Validate(string instructions)
        {
            foreach (var validationStrategy in ValidationStrategies)
            {
                if (!validationStrategy.ValidateCondition(instructions))
                    return false;
            }

            return true;
        }
    }
}
