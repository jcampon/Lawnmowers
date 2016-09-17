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
    class LawnDimensionsTests
    {
        [Test]
        public void Test_that_we_can_create_lawn_dimensions_with_valid_values()
        {
            // act
            var lawnDimensions = new LawnDimensions(new LocationCoordinates(2, 4));

            // assert
            Assert.That(lawnDimensions, Is.Not.Null);
            Assert.That(lawnDimensions.LengthOfAxisX, Is.EqualTo(2));
            Assert.That(lawnDimensions.LengthOfAxisY, Is.EqualTo(4));
        }

        [Test]
        public void Test_that_we_can_not_create_lawn_dimensions_with_invalid_values()
        {
            // Assert
            Assert.Throws<ArgumentException>(() => RaiseExceptionWhenCreatingLawnDimentions(0, 2));
            Assert.Throws<ArgumentException>(() => RaiseExceptionWhenCreatingLawnDimentions(3, -1));
        }

        private void RaiseExceptionWhenCreatingLawnDimentions(int x, int y)
        {
            var lawnDimensions = new LawnDimensions(new LocationCoordinates(x, y));
        }
    }
}
