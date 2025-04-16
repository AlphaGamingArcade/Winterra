using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Winterra.DataContexts;
using Winterra.Models.InputModels;
using System.Security.Claims;
using Winterra.Helpers;

namespace Winterra.Controllers
{
    public class ContentController : Controller
    {
        private readonly ContentDataAccess _contentDataAccess;
        public ContentController(ContentDataAccess contentDataAccess)
        {
            this._contentDataAccess = contentDataAccess;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return View();
        }
    }
}
