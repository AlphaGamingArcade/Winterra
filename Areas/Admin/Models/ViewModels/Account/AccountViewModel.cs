using Winterra.Models.DataModels;

namespace Winterra.Areas.Admin.Models.ViewModels
{
  public class AccountViewModel : BaseViewModel
  {
    public string? Search { get; set; }
    public string? SortBy { get; set; }
    public Pagination<Account>? UserAccountList { get; set; } 
    public Pagination<Account>? AdminAccountList { get; set; }
		public Account? LoginUserInfo { get; set; }
	}
}
