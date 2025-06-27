using Winterra.Models.DataModels;

namespace Winterra.Areas.Admin.Models.ViewModels
{
 public class HomeIndexViewModel : BaseViewModel
  {
    public int ActivePlayerCount { get; set; }
    public int OnlinePlayerCount { get; set; }
    public decimal InGameStellarCount { get; set; }
    public IEnumerable<Account>? UserAccountList { get; set; }
    public IEnumerable<Account>? AdminAccountList { get; set; }
		public Account? LoginUserInfo { get; set; }
	}

}