using System.ComponentModel;

namespace Winterra.Models.DataModels
{
    public class Content
    {
        public long Id { get; set; }
        public string? Type { get; set; }
        public string? Title { get; set; }

        [DisplayName("Content")]
        public string? Data { get; set; }

        [DisplayName("Published Date")]
        public DateTime PublishedAt { get; set; }
    }
}
