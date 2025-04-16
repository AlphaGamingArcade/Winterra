using Winterra.Models.DataModels;

namespace Winterra.Models.PartialModels 
{
    public class PreviewTablePartialModel : BasePartialModel
    {   
        public int PreviewCount {get; set;}
        public IEnumerable<Preview>? PreviewList { get; set; }
    }
}