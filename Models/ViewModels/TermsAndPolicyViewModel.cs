namespace Winterra.Models.ViewModels
{
    public class TermsAndPolicyItemListViewModel {
        public List<TermsAndPolicyItemViewModel> ItemList { get; set; } = new();
    }

    public class TermsAndPolicyItemViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public List<string> ImageList { get; set; } = new();
    }
}