using Winterra.Models.DataModels;

namespace Winterra.Models.ViewModels
{
  public class AccountViewModel : BaseViewModel
  {
    public IEnumerable<Account>? UserAccountList { get; set; } 
    public IEnumerable<Account>? AdminAccountList { get; set; } 
		public Account? LoginUserInfo { get; set; }
	}
}
