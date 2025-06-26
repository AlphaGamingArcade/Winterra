using Microsoft.AspNetCore.Mvc;
using Winterra.Models.ViewModels;
using System.Diagnostics;

namespace Winterra.Controllers
{
    public class TermsAndPolicyController : Controller
    {
		public TermsAndPolicyController(){}

		public IActionResult PrivacyPolicy()
        {
			return View();
        }

        public IActionResult TermsOfUse()
        {
			return View();
        }

        public IActionResult CodeOfConduct()
        {
			return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
