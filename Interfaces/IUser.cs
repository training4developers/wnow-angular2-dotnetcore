namespace Training4Developers.Interfaces
{
	public interface IUser
	{
		int Id { get; set; }
		string FirstName { get; set; }
		string LastName { get; set; }
		string EmailAddress { get; set; }
		string HashedPassword { get; set; }
	}
}