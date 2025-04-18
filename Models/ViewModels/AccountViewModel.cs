using Winterra.Models.DataModels;

namespace Winterra.Models.ViewModels
{
  public class AccountViewModel : BaseViewModel
  {
    public Pagination<Account>? UserAccountList { get; set; } 
    public Pagination<Account>? AdminAccountList { get; set; }
		public Account? LoginUserInfo { get; set; }
	}
}
