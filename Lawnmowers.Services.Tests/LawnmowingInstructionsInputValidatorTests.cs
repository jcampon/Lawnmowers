using System;
using System.Text;
using NUnit.Framework;
using Lawnmowers.Services;

namespace Lawnmowers.Services.Tests
{
    [TestFixture]
    public class LawnmowingInstructionsInputValidatorTests
    {
        private ILawnmowingInstructionsInputValidator _instructionsValidator;

        [SetUp]
        public void Setup()
        {
            _instructionsValidator = new LawnmowingInstructionsInputValidator();
        }

        [Test]
        public void Test_that_null_or_empty_instructions_input_will_fail_validation()
        {
            // Act
            var nullInstructionsAreValid  = _instructionsValidator.Validate(null);
            var emptyInstructionsAreValid = _instructionsValidator.Validate(string.Empty);

            // Assert
            Assert.That(nullInstructionsAreValid, Is.False);
            Assert.That(emptyInstructionsAreValid, Is.False);
        }

        [Test]
        public void Test_that_instructions_input_has_a_valid_number_of_lines()
        {
            // Arrange
            var instructionsInputWithOneLine = "5 5";
            var instructionsInputWithTwoLines = instructionsInputWithOneLine + "\n1 2 N";
            var instructionsInputWithOddNumberOfLines = instructionsInputWithTwoLines + "\nLMLMLMLMM";
            var instructionsInputWithEvenNumberOfLines = instructionsInputWithOddNumberOfLines + "\n" + "This is line #4";

            // Act
            var instructionsInputWithOneLineAreValid = _instructionsValidator.Validate(instructionsInputWithOneLine);
            var instructionsInputWithTwoLinesAreValid = _instructionsValidator.Validate(instructionsInputWithTwoLines);
            var instructionsInputWithOddNumberOfLinesAreValid = _instructionsValidator.Validate(instructionsInputWithOddNumberOfLines);
            var instructionsInputWithEvenNumberOfLinesAreValid = _instructionsValidator.Validate(instructionsInputWithEvenNumberOfLines);

            // Assert
            Assert.That(instructionsInputWithOneLineAreValid, Is.False);
            Assert.That(instructionsInputWithTwoLinesAreValid, Is.False);
            Assert.That(instructionsInputWithOddNumberOfLinesAreValid, Is.True);
            Assert.That(instructionsInputWithEvenNumberOfLinesAreValid, Is.False);
        }

        [Test]
        [TestCase ("5 5\n1 2 N\nLMLMLMLMM", true)]
        [TestCase("5 aaa\n1 2 N\nLMLMLMLMM", false)]
        [TestCase("aaa 5\n1 2 N\nLMLMLMLMM", false)]
        [TestCase("This is line #1\n1 2 N\nLMLMLMLMM", false)]
        public void Test_that_first_line_of_instructions_input_has_valid_upper_right_coordinates(string instructionsInput, bool expectedResult)
        {
            // Act
            var instructionsAreValid = _instructionsValidator.Validate(instructionsInput);

            // Assert
            Assert.That(instructionsAreValid, Is.EqualTo(expectedResult));           
        }

        [TestCase("5 5\n1 2 N\nLMLMLMLMM", true)]
        [TestCase("5 5\nAAAAA AAAA AAAA AAAA\nLMLMLMLMM", false)]
        [TestCase("5 5\n1 2 N\nLMLMLMLMM\n3 4 S\nLMLMLMLMM", true)]
        [TestCase("5 5\n1 2 N\nLMLMLMLMM\nBBBB BBBB BBBBB\nLMLMLMLMM", false)]
        public void Test_that_the_lines_about_mower_positions_are_correct(string instructionsInput, bool expectedResult)
        {
            // Act
            var instructionsAreValid = _instructionsValidator.Validate(instructionsInput);

            // Assert
            Assert.That(instructionsAreValid, Is.EqualTo(expectedResult));
        }

        [TestCase("5 5\n1 2 N\nLMLMLMLMM", true)]
        [TestCase("5 5\n1 2 N\nDSFSDFSDFS", false)]
        [TestCase("5 5\n1 2 N\nLMLMLMLMM\n3 4 S\nLMLMLMLMM", true)]
        [TestCase("5 5\n1 2 N\nLMLMLMLMM\n3 4 S\nSDFSDFSDFSDF", false)]
        public void Test_that_the_lines_about_mower_movements_are_correct(string instructionsInput, bool expectedResult)
        {
            // Act
            var instructionsAreValid = _instructionsValidator.Validate(instructionsInput);

            // Assert
            Assert.That(instructionsAreValid, Is.EqualTo(expectedResult));
        }
    }
}
