using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using Lawnmowers.Services;

namespace Lawnmowers.Services.Tests
{
    [TestFixture]
    public class LawnmowingInstructionsInputParserTests
    {
        private ILawnmowingInstructionsInputParser _instructionsParser;
        private string _instructionsInput;

        [SetUp]
        public void Setup()
        {
            _instructionsParser = new LawnmowingInstructionsInputParser();
            _instructionsInput = "5 7\n1 2 N\nLMLMLMLMM\n3 4 S\nMMLRLRMM";
        }

        [Test]
        public void Test_that_the_parser_gets_the_correct_lawn_dimensions_from_the_instructions_input()
        {
            // Arrange
            var expectedLawnDimensions = new LawnDimensions(5, 7);

            // Act
            var lawnDimensions = _instructionsParser.GetLawnDimensionsFrom(_instructionsInput);

            // Assert
            Assert.That(lawnDimensions.LengthOfAxisX, Is.EqualTo(expectedLawnDimensions.LengthOfAxisX));
            Assert.That(lawnDimensions.LengthOfAxisY, Is.EqualTo(expectedLawnDimensions.LengthOfAxisY));
        }

        [Test]
        [TestCase("5 5\n1 2 N\nLMLMLMLMM", 1)]
        [TestCase("5 5\n1 2 N\nLMLMLMLMM\n2 3 N\nLMLMLMLMM", 2)]
        [TestCase("5 5\n1 2 N\nLMLMLMLMM\n2 3 N\nLMLMLMLMM\n4 4 N\nLMLMLMLMM", 3)]
        public void Test_that_the_parser_gets_the_correct_number_of_lawnmowers_from_the_instructions_input(string instructions, int expectedLawnmowers)
        {
            // Act
            var listOfLawnmowers = _instructionsParser.GetListOfLawnMowersFrom(instructions);

            // Assert
            Assert.That(listOfLawnmowers.Count, Is.EqualTo(expectedLawnmowers));
        }

    }
}
