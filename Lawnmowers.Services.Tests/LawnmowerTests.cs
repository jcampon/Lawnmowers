using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Lawnmowers.Services.Tests
{
    [TestFixture]
    class LawnmowerTests
    {
        private ILawnmower _lawnmower;

        [SetUp]
        public void Setup()
        {
            _lawnmower = new Lawnmower()
            {
                LawnDimensionsReference = new LawnDimensions(new LocationCoordinates(5, 5)),
                Instructions = "LMLMLMLRLMM",
                Position = new LocationCoordinates(1, 2),
                Orientation = 'N'
            };
        }

        [Test]
        public void Test_that_the_lawnmower_can_process_all_its_instructions()
        {
            // Act
            _lawnmower.ProcessAllInstructions();
            var finalOuput = _lawnmower.GetFinishedInstructionsOutput();

            // Assert
            Assert.That(finalOuput, Is.EqualTo("1 3 N\r\n"));
        }

    }
}
