using Training4Developers.Interfaces;

namespace Training4Developers.Models
{
	public class Widget : IWidget
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public string Color { get; set; }

		public string Size { get; set; }

		public int Quantity { get; set; }

		public decimal Price { get; set; }
	}

}