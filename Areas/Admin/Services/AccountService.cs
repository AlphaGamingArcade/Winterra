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

        public AccountViewModel GetHomeIndexViewModel(SearchFilter filter)
        {
            var loginUser = GetLoginUser();

            int currentPage = filter.PageNumber ?? 1;
            int currentPageSize = filter.PageSize ?? 30;
            string currentOrderBy = "id";
            string currentSortBy = SQLHelper.SanitizeSortBy(filter.SortBy);

            int memberLevel = 1;
            var total = _accountDataAccess.GetAccountCount(memberLevel, filter.Search);
            var paged = _accountDataAccess.GetAccountListPaged(
                currentPage,
                currentPageSize,
                memberLevel,
                filter.Search,
                currentOrderBy,
                currentSortBy
            );

            return new AccountViewModel
            {
                MenuOut = 1,
                MenuIn = "user",
                MenuTitle = "Account Management",
                UserAccountList = new Pagination<Account>(paged, total, currentPage, currentPageSize),
                Search = filter.Search,
                SortBy = filter.SortBy,
                LoginUserInfo = loginUser
            };
        }
        
         public AccountViewModel GetAdministratorViewModel(SearchFilter filter){
            var loginUser = GetLoginUser();

            int currentPage = filter.PageNumber ?? 1;
            int currentPageSize = filter.PageSize ?? 30;
            string currentOrderBy = "id";
            string currentSortBy = SQLHelper.SanitizeSortBy(filter.SortBy);

            int memberLevel = 3;
            var total = _accountDataAccess.GetAccountCount(memberLevel, filter.Search);
            var paged = _accountDataAccess.GetAccountListPaged(
                currentPage,
                currentPageSize,
                memberLevel,
                filter.Search,
                currentOrderBy,
                currentSortBy
            );

            return new AccountViewModel
            {
                MenuOut = 1,
                MenuIn = "admin",
                MenuTitle = "Account Management",
                UserAccountList = new Pagination<Account>(paged, total, currentPage, currentPageSize),
                Search = filter.Search,
                SortBy = filter.SortBy,
                LoginUserInfo = loginUser
            };
        }
    }
}