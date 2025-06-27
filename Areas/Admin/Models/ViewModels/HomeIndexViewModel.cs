using Winterra.Models.DataModels;

namespace Winterra.Areas.Admin.Models.ViewModels
{
  public class HomeIndexViewModel : BaseViewModel
  {
    public int ActivePlayerCount { get; set; }
    public int OnlinePlayerCount { get; set; }
    public decimal InGameStellarCount { get; set; }
    public List<Account> AccountList { get; set; } = new();
    public Account? LoginUserInfo { get; set; }
  }

  public class HomeAdminstratorViewModel : BaseViewModel
  {
    public List<Account> AccountList { get; set; } = new();
    public Account? LoginUserInfo { get; set; }
  }
  
}