using Winterra.Models.DataModels;

namespace Winterra.Models.ViewModels
{
  public class PreviewViewModel : BaseViewModel
  {
    public Pagination<Preview>? CharacterPreviewList { get; set; }
    public Pagination<Preview>? HighlightPreviewList { get; set; }
    public Pagination<Preview>? LorePreviewList { get; set; }
    public Account? LoginUserInfo { get; set; }
	}
}
