using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LawnMowers.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ViewResult MowTheLawn(string Instructions)
        {

            var validator = new Lawnmowers.Services.LawnmowingInstructionsInputValidator();
            var parser = new Lawnmowers.Services.LawnmowingInstructionsInputParser();
            var service = new Lawnmowers.Services.LawnmowingOperationsService(validator, parser);

            if (service.ValidateTheInput(Instructions))
            {
                service.MowTheLawnUsingTheInput(Instructions);

                ViewBag.Result = service.GetOutputResultsAfterLawnmowing();
            }
            else
            {
                ViewBag.Error = service.ErrorMessageFromValidationFailure;
            }

            return View("Results");
        }
    }
}