using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using NUnit.Framework;
using Lawnmowers.Services;
using Lawnmowers.Web.DependencyResolution;
using StructureMap;

namespace Lawnmowers.Web.Tests.DependencyResolution
{
    [TestFixture]
    class TestIoC
    {
        private IContainer _container;

        [SetUp]
        public void SetUp()
        {
            IoC.Initialize();
            _container = IoC.Initialize();
        }

        [Test]
        public void Test_that_ILawnmowingOperationsService_is_instance_of_LawnmowingOperationsService()
        {
            // Act
            var res = _container.GetInstance<ILawnmowingOperationsService>();

            // Assert
            Assert.IsInstanceOf<LawnmowingOperationsService>(res);
        }
    }
}
