using Winterra.Models.DataModels;

namespace Winterra.Models.PartialModels 
{
    public class PreviewTablePartialModel : BasePartialModel
    {
        public IEnumerable<Preview>? PreviewList { get; set; }
    }
}