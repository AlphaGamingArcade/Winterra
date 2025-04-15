using Microsoft.AspNetCore.Mvc;
using Winterra.Models.ViewModels;

namespace Winterra.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
			var model = new BaseViewModel
			{
				MenuOut = 0,
				MenuIn = "error",
				MenuTitle = "에러페이지",
			};

            return View(model);
        }
    }
}
