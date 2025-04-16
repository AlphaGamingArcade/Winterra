using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Winterra.DataContexts;
using Winterra.Models.InputModels;
using System.Security.Claims;
using Winterra.Helpers;

namespace Winterra.Controllers
{
    public class PreviewController : Controller
    {
        private readonly PreviewDataAccess _previewDataAccess;
        public PreviewController(PreviewDataAccess previewDataAccess)
        {
            this._previewDataAccess = previewDataAccess;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
