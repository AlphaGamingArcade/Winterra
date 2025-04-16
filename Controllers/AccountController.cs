using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Winterra.DataContexts;
using Winterra.Models.InputModels;
using System.Security.Claims;
using Winterra.Helpers;
using Winterra.Models.ViewModels;

namespace Winterra.Controllers
{
    public class AccountController : Controller
    {
		private readonly AccountDataAccess _accountDataAccess;
		private readonly ContentDataAccess _contentDataAccess;
		private readonly PreviewDataAccess _previewDataAccess;

		public AccountController(AccountDataAccess accountDataAccess, ContentDataAccess contentDataAccess, PreviewDataAccess previewDataAccess)
        {
			this._accountDataAccess = accountDataAccess;
			this._contentDataAccess = contentDataAccess;
			this._previewDataAccess = previewDataAccess;
		}

        public IActionResult User()
        {
            string? accountEmail = null;
			string? accountSession = null;

			if (HttpContext.User.Identity?.IsAuthenticated == true)
			{
				accountEmail = HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;
				accountSession = HttpContext.User.FindFirst(ClaimTypes.Hash)?.Value;
			}

            var model = new AccountViewModel
            {
                MenuOut = 1,
                MenuIn = "user",
                MenuTitle = "Account Management",
				LoginUserInfo = _accountDataAccess.GetLoginMemberData(accountEmail)
			};

            if (model.LoginUserInfo?.Session != accountSession)
				return RedirectToAction("Logout", "Account");

			return View(model);
        }

        public IActionResult Administrator()
        {
            string? accountEmail = null;
			string? accountSession = null;

			if (HttpContext.User.Identity?.IsAuthenticated == true)
			{
				accountEmail = HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;
				accountSession = HttpContext.User.FindFirst(ClaimTypes.Hash)?.Value;
			}

            var model = new AccountViewModel
            {
                MenuOut = 1,
                MenuIn = "administrator",
                MenuTitle = "Account Management",
				LoginUserInfo = _accountDataAccess.GetLoginMemberData(accountEmail)
			};

            if (model.LoginUserInfo?.Session != accountSession)
				return RedirectToAction("Logout", "Account");

			return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Login member)
        {
            if (ModelState.IsValid)
            {
                bool isLogin = _accountDataAccess.CheckLogin(member);
                Console.WriteLine($"IS LOGING {isLogin}");
                if (isLogin)
                {
                    var nowDate = DateTime.Now.ToString();
                    var ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "Unknown IP";
                    var session = HashHelper.ComputeSHA256(member.Email + nowDate + ipAddress);

                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, member.Email),
                        new Claim(ClaimTypes.Hash, session),
                        new Claim(ClaimTypes.Role, Roles.Admin)
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, "Auth");
                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                    await HttpContext.SignInAsync("Auth", claimsPrincipal);

                    _accountDataAccess.UpdateAfterLogin(member.Email, session);

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid username or password");
            }
            return View(member);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            string? account = HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;

            await HttpContext.SignOutAsync();

            if (account != null)
                _accountDataAccess.UpdateAfterLogout(account);

            return RedirectToAction("Index", "Home");
        }

    }
}
