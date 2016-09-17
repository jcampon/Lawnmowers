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
    class LocationCoordinatesTests
    {
        [Test]
        public void Test_that_we_can_create_location_coordinates_with_valid_values()
        {
            // act
            var locationCoordinates = new LocationCoordinates(2, 4);

            // assert
            Assert.That(locationCoordinates, Is.Not.Null);
            Assert.That(locationCoordinates.LocationOnAxisX, Is.EqualTo(2));
            Assert.That(locationCoordinates.LocationOnAxisY, Is.EqualTo(4));
        }

        [Test]
        public void Test_that_we_can_not_create_location_coordinates_with_invalid_values()
        {
            // Assert
            Assert.Throws<ArgumentException>(() => RaiseExceptionWhenCreatingLocationCoordinates(-1, 2));
            Assert.Throws<ArgumentException>(() => RaiseExceptionWhenCreatingLocationCoordinates(3, -1));
        }

        private void RaiseExceptionWhenCreatingLocationCoordinates(int x, int y)
        {
            var locationCoordinates = new LocationCoordinates(x, y);
        }
    }
}
