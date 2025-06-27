using Microsoft.AspNetCore.Mvc;
using Winterra.Models.ViewModels;
using System.Diagnostics;
using Winterra.Services;

namespace Winterra.Controllers
{
    public class NewsController : Controller
    {
        private readonly ContentService _contentService;
        public NewsController(ContentService contentService) {
            _contentService = contentService;
        }

		public IActionResult Index(string? t)
        {
            var model = _contentService.GetNewsIndexViewModel(t);
			return View(model);
        }

        public IActionResult Details(long id, string? t)
        {
            var model = _contentService.GetNewsDetailsViewModel(
                id,
                t
            );
			return View(model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
