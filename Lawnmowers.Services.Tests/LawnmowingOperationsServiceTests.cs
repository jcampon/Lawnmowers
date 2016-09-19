using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Lawnmowers.Services;

namespace Lawnmowers.Services.Tests
{
    [TestFixture]
    class LawnmowingOperationsServiceTests
    {
        private ILawnmowingInstructionsInputValidator _inputValidator;
        private ILawnmowingInstructionsInputParser _inputParser;
        private LawnmowingOperationsService _lawnmowingOperationsService;

        [SetUp]
        public void Setup()
        {
            _inputValidator = new LawnmowingInstructionsInputValidator();
            _inputParser = new LawnmowingInstructionsInputParser();
            _lawnmowingOperationsService = new LawnmowingOperationsService(_inputValidator, _inputParser);
        }

        [Test]
        [TestCase(null, false)]                                      // Validate against no input
        [TestCase("", false)]                                        // Validate against no input
        [TestCase("skdjfksjdfksdjfhk", false)]                       // Validate against rubbish input
        [TestCase("5 0\n1 2 N\nLMLMLMLMM", false)]                   // Validate against wrong lawn dimension values
        [TestCase("5 5\n1 2 K\nLMLMLMLMM", false)]                   // Validate against wrong orientation values
        [TestCase("5 5\n1 -2 N\nLMLMLMLMM", false)]                  // Validate against wrong position coordenate values
        [TestCase("5 5\n1 2 N\nLMLKGFMLMLMM", false)]                // Validate against wrong instruction values
        [TestCase("5 5\n1 2 N\nLMLMLMLMM\nsdfsdfsdf", false)]        // Validate against wrong number of intruction lines
        [TestCase("5 5\n1 2 N\nLMLMLMLMM", true)]                    // Validate against valid input for one lawnmower
        [TestCase("5 5\n1 2 N\nLMLMLMLMM\n3 3 E\nMMRMMRMRRM", true)] // Validate against valid input for two lawnmowers
        public void Test_that_the_service_can_validate_instructions_input_correctly(string instructions, bool expectedValidation)
        {
            // Act            
            var areInstructionsInputValid = _lawnmowingOperationsService.ValidateTheInput(instructions);

            // Assert
            Assert.That(areInstructionsInputValid, Is.EqualTo(expectedValidation));
        }

        [Test]
        public void Test_that_the_service_can_parse_instructions_input_correctly()
        {
            // Act            
            _lawnmowingOperationsService.MowTheLawnUsingTheInput("5 6\n1 2 N\nLMLMLMLMM\n3 3 E\nMMRMMRMRRM");
            var lawnmower1 = _lawnmowingOperationsService.Lawnmowers[0];
            var lawnmower2 = _lawnmowingOperationsService.Lawnmowers[1];

            // Assert
            Assert.That(_lawnmowingOperationsService.Lawnmowers.Count, Is.EqualTo(2));

            Assert.That(lawnmower1.Orientation, Is.EqualTo('N'));
            Assert.That(lawnmower1.Instructions, Is.EqualTo("LMLMLMLMM"));
            Assert.That(lawnmower1.LawnDimensionsReference.LengthOfAxisX, Is.EqualTo(5));
            Assert.That(lawnmower1.LawnDimensionsReference.LengthOfAxisY, Is.EqualTo(6));
            Assert.That(lawnmower1.Position.LocationOnAxisX, Is.EqualTo(1));            

            Assert.That(lawnmower2.Orientation, Is.EqualTo('E'));
            Assert.That(lawnmower2.Instructions, Is.EqualTo("MMRMMRMRRM"));
            Assert.That(lawnmower2.LawnDimensionsReference.LengthOfAxisX, Is.EqualTo(5));
            Assert.That(lawnmower2.LawnDimensionsReference.LengthOfAxisY, Is.EqualTo(6));
        }

        [Test]
        public void Test_that_the_service_produce_the_correct_output_after_all_lawnmowers_finish()
        {
            // Act            
            _lawnmowingOperationsService.MowTheLawnUsingTheInput("5 6\n1 2 N\nLMLMLMLMM\n3 3 E\nMMRMMRMRRM");

            var outputResult = _lawnmowingOperationsService.GetOutputResultsAfterLawnmowing();

            // Assert
            Assert.That(outputResult, Is.EqualTo("1 3 N\r\n5 1 E\r\n"));
        }

        [Test]
        public void Test_that_the_service_provides_an_error_message_when_validation_fails()
        {
            // Act            
            _lawnmowingOperationsService.MowTheLawnUsingTheInput("Bad instructions that should fail validation");

            var outputResult = _lawnmowingOperationsService.ErrorMessageFromValidationFailure;

            // Assert
            Assert.That(outputResult, Is.EqualTo("Error! The input instructions provided are nor correct"));
        }

    }

}
