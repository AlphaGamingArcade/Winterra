using Microsoft.AspNetCore.Mvc;
using Winterra.Models.ViewModels;
using System.Diagnostics;
using Winterra.Services;

namespace Winterra.Controllers
{
    public class TermsAndPolicyController : Controller
    {

        private readonly ContentService _contentService;
        public TermsAndPolicyController(ContentService contentService)
        {
            _contentService = contentService;
        }

		public IActionResult PrivacyPolicy()
        {
            var model = _contentService.GetPrivacyPolicyViewModel();
			return View(model);
        }

        public IActionResult TermsOfUse()
        {
            var model = _contentService.GetTermsOfUsViewModel();
			return View(model);
        }

        public IActionResult CodeOfConduct()
        {
            var model = _contentService.GetCodeOfConductViewModel();
			return View(model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
