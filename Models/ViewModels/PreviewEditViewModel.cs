using Winterra.Models.DataModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Winterra.Models.ViewModels
{
  public class PreviewEditViewModel : BaseViewModel
  {
    public static readonly List<SelectListItem> AvailableTypes = new()
    {
        new SelectListItem { Text = "Characters", Value = "characters" },
        new SelectListItem { Text = "Highlights", Value = "highlights" },
        new SelectListItem { Text = "Lore", Value = "lore" }
    };
    public IEnumerable<SelectListItem> Types { get; set; } = AvailableTypes;
    public Preview? Preview { get; set; }
    public Account? LoginUserInfo { get; set; }
  }
}


