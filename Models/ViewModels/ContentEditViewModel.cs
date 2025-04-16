using Winterra.Models.DataModels;

namespace Winterra.Models.ViewModels
{
  public class ContentEditViewModel : BaseViewModel
  {
    public Content? Content { get; set; }
    public Account? LoginUserInfo { get; set; }
  }
}
