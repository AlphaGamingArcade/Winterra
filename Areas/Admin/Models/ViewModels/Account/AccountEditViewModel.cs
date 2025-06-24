using Winterra.Models.DataModels;

namespace Winterra.Areas.Admin.Models.ViewModels
{
  public class AccountEditViewModel : BaseViewModel
  {
    public Account? Account { get; set; }
    public Account? LoginUserInfo { get; set; }
  }
}
