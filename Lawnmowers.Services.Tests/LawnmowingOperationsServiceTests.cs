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
        private ILawnmowingOperationsService _lawnmowingOperationsService;

        [SetUp]
        public void Setup()
        {
            _lawnmowingOperationsService = new LawnmowingOperationsService();
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
            var areInstructionsInputValid = _lawnmowingOperationsService.ValidateInput(instructions);

            // Assert
            Assert.That(areInstructionsInputValid, Is.EqualTo(expectedValidation));
        }

    }
}
