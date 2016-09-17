using System;
using System.Text;
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
        public void Test_that_the_parser_gets_the_correct_lawn_dimensions()
        {
            // Arrange
            var expectedLawnDimensions = new LawnDimensions(5, 7);

            // Act
            var lawnDimensions = _instructionsParser.GetLawnDimensionsFrom(_instructionsInput);

            // Assert
            Assert.That(lawnDimensions.LengthOfAxisX, Is.EqualTo(expectedLawnDimensions.LengthOfAxisX));
            Assert.That(lawnDimensions.LengthOfAxisY, Is.EqualTo(expectedLawnDimensions.LengthOfAxisY));
        }
    }
}
