using Winterra.Models.DataModels;

namespace Winterra.Models.ViewModels
{
  public class PreviewEditViewModel : BaseViewModel
  {
    public Preview? Preview { get; set; }
    public Account? LoginUserInfo { get; set; }
  }
}
