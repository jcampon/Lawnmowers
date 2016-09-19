using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lawnmowers.Services;
using Lawnmowers.Web.Models;

namespace LawnMowers.Web.Controllers
{
    public class HomeController : Controller
    {
        private ILawnmowingOperationsService _service;

        public HomeController(ILawnmowingOperationsService service)
        {
            _service = service;
        }

        public ActionResult Index()
        {
            var instructionsInputModel = new InstructionsInputModel();

            return View(instructionsInputModel);
        }

        public ViewResult MowTheLawn(string Instructions)
        {            

            if (_service.ValidateTheInput(Instructions))
            {
                _service.MowTheLawnUsingTheInput(Instructions);

                ViewBag.Result = _service.GetOutputResultsAfterLawnmowing();
            }
            else
            {
                ViewBag.Error = _service.ErrorMessageFromValidationFailure;
            }

            return View("Results");
        }
    }
}