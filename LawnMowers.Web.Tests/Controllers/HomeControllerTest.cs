using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using LawnMowers.Web;
using Lawnmowers.Services;
using LawnMowers.Web.Controllers;
using NUnit.Framework;

namespace LawnMowers.Web.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTest
    {
        private HomeController _homeController;

        [SetUp]
        public void Setup()
        {
            var validator = new LawnmowingInstructionsInputValidator();
            var parser = new LawnmowingInstructionsInputParser();
            var service = new LawnmowingOperationsService(validator, parser);
            _homeController = new HomeController(service);
        }

        [Test]
        public void Test_that_the_index_action_returns_a_view_result()
        {
            // Act
            ViewResult result = _homeController.Index() as ViewResult;

            // Assert
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void Test_that_the_mowthelawn_action_returns_a_view_result()
        {
            // Act
            ViewResult result = _homeController.MowTheLawn("some input") as ViewResult;

            // Assert
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void Test_the_result_message_on_the_viewbag_when_mowthelawn_action_received_correct_instructions()
        {
            // Act
            ViewResult result = _homeController.MowTheLawn("5 6\n1 2 N\nLMLMLMLMM") as ViewResult;

            // Assert
            Assert.That(_homeController.ViewBag.Result, Is.EqualTo("1 3 N\r\n"));
        }

        [Test]
        public void Test_the_error_message_on_the_viewbag_when_mowthelawn_action_received_wrong_instructions()
        {
            // Act
            ViewResult result = _homeController.MowTheLawn("some wrong input") as ViewResult;

            // Assert
            Assert.That(_homeController.ViewBag.Error, Is.EqualTo("Error! The input instructions provided are nor correct"));
        }
    }
}
