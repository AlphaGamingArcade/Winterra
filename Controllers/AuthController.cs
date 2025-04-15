using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Winterra.DataContexts;
using Winterra.Models.InputModels;
using System.Security.Claims;
using Winterra.Helpers;

namespace Winterra.Controllers
{
    public class AuthController : Controller
    {
        private readonly AuthDataAccess _authDataAccess;
        public AuthController(AuthDataAccess authDataAccess)
        {
            this._authDataAccess = authDataAccess;
        }

        public IActionResult Index()
        {
            return View();
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
                bool isLogin = _authDataAccess.CheckLogin(member);
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

                    _authDataAccess.UpdateAfterLogin(member.Email, session);

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
                _authDataAccess.UpdateAfterLogout(account);

            return RedirectToAction("Index", "Home");
        }

    }
}
