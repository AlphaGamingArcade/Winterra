using Winterra.Models.DataModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Winterra.Models.InputModels;

namespace Winterra.Models.ViewModels
{
  public class ContentCreateViewModel : BaseViewModel
  {
    public static readonly List<SelectListItem> AvailableTypes = new()
    {
      new SelectListItem { Text = "Features", Value = "features" },
      new SelectListItem { Text = "News", Value = "news" },
      new SelectListItem { Text = "Update", Value = "update" },
      new SelectListItem { Text = "Code of Conduct", Value = "code-of-conduct" },
      new SelectListItem { Text = "Terms of Use", Value = "terms-of-use" },
      new SelectListItem { Text = "Privacy Policy", Value = "privacy-policy" },
      new SelectListItem { Text = "Playbook", Value = "playbook" },
    };
    public IEnumerable<SelectListItem> Types { get; set; } = AvailableTypes;
    public Content? Content { get; set; }
    public Account? LoginUserInfo { get; set; }
  }
}


