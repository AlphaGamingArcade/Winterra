using System.ComponentModel.DataAnnotations;

namespace Winterra.Models.DataModels
{
	public class Preview
	{
		public int Id { get; set; }
		
		[Required(ErrorMessage = "Type is required.")]
		public string? Type { get; set; }

		[Required(ErrorMessage = "Image is required.")]
		public string? Image { get; set; }

		[Required(ErrorMessage = "Name is required.")]
		public string? Name { get; set; }
	}
}
