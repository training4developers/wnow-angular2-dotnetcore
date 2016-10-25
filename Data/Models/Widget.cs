using System.ComponentModel.DataAnnotations.Schema;

namespace Training4Developers.Data.Models
{
	[Table("widgets")]
	public class Widget
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public string Color { get; set; }

		public string Size { get; set; }

		public int Quantity { get; set; }

		[Column(TypeName="Money")]
		public decimal Price { get; set; }
	}

}