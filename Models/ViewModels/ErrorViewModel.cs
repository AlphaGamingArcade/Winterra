namespace Winterra.Models.ViewModels
{
    public class ErrorViewModel : BaseViewModel
    {
        public int StatusCode { get; set; }
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
