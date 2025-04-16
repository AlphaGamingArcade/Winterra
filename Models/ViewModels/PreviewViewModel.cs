using Winterra.Models.DataModels;

namespace Winterra.Models.ViewModels
{
  public class PreviewViewModel : BaseViewModel
  {
    public IEnumerable<Preview>? CharacterPreviewList { get; set; }
    public IEnumerable<Preview>? HighlightPreviewList { get; set; }
    public IEnumerable<Preview>? LorePreviewList { get; set; }
    public Account? LoginUserInfo { get; set; }
	}
}
