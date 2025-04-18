using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Winterra.Models.DataModels
{
    public class Content
    {
        public long Id { get; set; }

        [Required]
        public string? Type { get; set; }

        [Required]
        public string? Title { get; set; }

        [Required]
        [DisplayName("Content")]
        public string? Data { get; set; }

        [Required]
        [DisplayName("Published Date")]
        public DateTime PublishedAt { get; set; }
    }
}
