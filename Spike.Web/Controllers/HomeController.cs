using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Web;
using System.Web.Mvc;
using Spike.Stubs.Orchestrations;

namespace Spike.Web.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Login(string username, string password)
        {
            // TODO: This should be DI Injected
            var securityOrchestrator = new SecurityOrchestrationStub();
            var isLoggedIn = securityOrchestrator.Login(username, password);

            var responseData = new
            {
                LoggedIn = isLoggedIn
            };

            return this.Json(responseData);
        }

    }
}