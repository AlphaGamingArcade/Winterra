namespace Winterra.Models.DataModels
{
    public class Content
    {
        public long Id { get; set; }
        public string? Type { get; set; }
        public string? Title { get; set; }
        public string? Data { get; set; }
        public DateTime PublishedAt { get; set; }
    }
}
