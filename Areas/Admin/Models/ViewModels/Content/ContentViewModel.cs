using Winterra.Models.DataModels;

namespace Winterra.Areas.Admin.Models.ViewModels
{
  public class ContentViewModel : BaseViewModel
  {
    public string? Search { get; set; }
    public string? SortBy { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? FinishDate { get; set; }
    public Pagination<Content>? ContentList { get; set; }
    public Account? LoginUserInfo { get; set; }
	}
}
