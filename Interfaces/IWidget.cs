namespace Training4Developers.Interfaces
{
	public interface IWidget
	{
		int Id { get; set; }
		
		string Name { get; set; }
		
		string Description { get; set; }
		
		string Color { get; set; }
		
		string Size { get; set; }

		int Quantity { get; set; }

		decimal Price { get; set; }
	}
}