using Winterra.Areas.Admin.Models.InputModels;
using Winterra.Areas.Admin.Models.ViewModels;
using Winterra.DataContexts;
using Winterra.Helpers;
using Winterra.Models.DataModels;

namespace Winterra.Areas.Admin.Services
{
    public class AccountService : BaseService
    {
        private readonly AccountDataAccess _accountDataAccess;
        public AccountService(IHttpContextAccessor httpContextAccessor, AccountDataAccess accountDataAccess) : base(httpContextAccessor)
        {
            _accountDataAccess = accountDataAccess;
        }

        public HomeIndexViewModel GetHomeIndexViewModel()
        {
            var loginUser = GetLoginUser();
            return new HomeIndexViewModel
            {
                MenuOut = 1,
                MenuIn = "user",
                MenuTitle = "Account Management",
                AccountList = _accountDataAccess.GetAccountList(0),
                OnlinePlayerCount = _accountDataAccess.GetOnlinePlayerCount(),
                ActivePlayerCount = _accountDataAccess.GetPlayerCount(),
                InGameStellarCount = _accountDataAccess.GetInGameStellarCount(),
                LoginUserInfo = loginUser
            };
        }
        
         public HomeAdminstratorViewModel GetHomeAdministratorViewModel(){
            var loginUser = GetLoginUser();
            return new HomeAdminstratorViewModel
            {
                MenuOut = 1,
                MenuIn = "administrator",
                MenuTitle = "Account Management",
                AccountList = _accountDataAccess.GetAccountList(1),
                LoginUserInfo = loginUser
            };
        }
    }
}