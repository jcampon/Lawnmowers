using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
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
            var expectedLawnDimensions = new LawnDimensions(new LocationCoordinates(5, 7));

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

        [Test]
        public void Test_that_the_parser_creates_correct_lawnmower_objects_from_the_instructions_input()
        {
            // Arrange 
            var expectedLawnmower = GetExpectedTestLawnmower();

            // Act
            var listOfLawnmowers = _instructionsParser.GetListOfLawnMowersFrom("5 6\n2 3 E\nLMLMLMLMM");
            var lawnmover = listOfLawnmowers.FirstOrDefault();

            // Assert
            Assert.That(lawnmover.Instructions, Is.EqualTo(expectedLawnmower.Instructions));
            Assert.That(lawnmover.LawnDimensionsReference.LengthOfAxisX, Is.EqualTo(expectedLawnmower.LawnDimensionsReference.LengthOfAxisX));
            Assert.That(lawnmover.LawnDimensionsReference.LengthOfAxisY, Is.EqualTo(expectedLawnmower.LawnDimensionsReference.LengthOfAxisY));
            Assert.That(lawnmover.Orientation, Is.EqualTo(expectedLawnmower.Orientation));
            Assert.That(lawnmover.Position.LocationOnAxisX, Is.EqualTo(expectedLawnmower.Position.LocationOnAxisX));
            Assert.That(lawnmover.Position.LocationOnAxisY, Is.EqualTo(expectedLawnmower.Position.LocationOnAxisY));
        }

        #region Private Helper Methods

        private Lawnmower GetExpectedTestLawnmower()
        {
            return new Lawnmower()
            {
                LawnDimensionsReference = new LawnDimensions(new LocationCoordinates(5, 6)),
                Instructions = "LMLMLMLMM",
                Orientation = 'E',
                Position = new LocationCoordinates(2, 3)
            };
        }

        #endregion

    }
}
