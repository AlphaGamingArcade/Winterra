using Winterra.Models.DataModels;

namespace Winterra.Models.ViewModels
{
  public class AccountEditViewModel : BaseViewModel
  {
    public Account? Account { get; set; }
    public Account? LoginUserInfo { get; set; }
  }
}
