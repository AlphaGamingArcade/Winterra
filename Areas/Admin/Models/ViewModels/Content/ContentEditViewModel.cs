using Microsoft.AspNetCore.Mvc.Rendering;
using Winterra.Models.DataModels;

namespace Winterra.Areas.Admin.Models.ViewModels
{
  public class ContentEditViewModel : BaseViewModel
  {
    public List<SelectListItem> Types { get; set; } = new();
    public Content? Content { get; set; }
    public Account? LoginUserInfo { get; set; }
  }
}
