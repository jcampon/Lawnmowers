using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lawnmowers.Services
{
    public interface ILawnmowingInstructionsInputValidator
    {
        bool Validate(string instructions);
    }

    public class LawnmowingInstructionsInputValidator : ILawnmowingInstructionsInputValidator
    {
        public bool Validate(string instructions)
        {
            if (!ValidateThatInstructionsAreNotNullOrEmpty(instructions))
                return false;

            if (!ValidateThatInstructionsHaveAValidNumberOfLines(instructions))
                return false;

            if (!ValidateThatFirstLineHasValidUpperRightCoordinates(instructions))
                return false;

            if (!ValidateThatTheLinesAboutMowerPositionsAreCorrect(instructions))
                return false;

            if (!ValidateThatTheLinesAboutMowerMovementsAreCorrect(instructions))
                return false;

            return true;
        }

        #region Private helper  methods

        private bool ValidateThatInstructionsAreNotNullOrEmpty(string instructions)
        {
            return !string.IsNullOrWhiteSpace(instructions);
        }

        private bool ValidateThatInstructionsHaveAValidNumberOfLines(string instructions)
        {
            var linesOfInstructions = instructions.Count(nl => nl == '\n') + 1;

            if (linesOfInstructions <= 2)
                return false;

            return (linesOfInstructions % 2 != 0);
        }

        private bool ValidateThatFirstLineHasValidUpperRightCoordinates(string instructions)
        {
            var firstLineComponents = instructions.Split('\n')  // split the instructions input into lines
                                                  .First()      // get the first line
                                                  .Trim()       // trims the line for extra sanity check
                                                  .Split(' ');  // split the first line into parts separated by space

            if (firstLineComponents.Count() != 2)
                return false;

            if (!CheckValidNumberValidationFor(firstLineComponents[0]))
                return false;

            if (!CheckValidNumberValidationFor(firstLineComponents[1]))
                return false;

            return true;
        }

        private bool CheckValidNumberValidationFor(string value)
        {
            int parsedIntValue = 0;

            return int.TryParse(value.ToString(), out parsedIntValue);
        }

        private bool ValidateThatTheLinesAboutMowerPositionsAreCorrect(string instructions)
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

        private bool ValidateLineAboutMowerPosition(string line)
        {
            if (string.IsNullOrWhiteSpace(line))
                return false;

            var lineComponents = line.Split(' ');

            if (lineComponents.Count() != 3)
                return false;

            if (!CheckValidNumberValidationFor(lineComponents[0]))
                return false;

            if (!CheckValidNumberValidationFor(lineComponents[1]))
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

        private bool ValidateThatTheLinesAboutMowerMovementsAreCorrect(string instructions)
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

        #endregion
    }
}
