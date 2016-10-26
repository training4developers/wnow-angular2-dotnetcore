using Training4Developers.Interfaces;

namespace Training4Developers.Models
{
	public class User : IUser
	{
		public int Id { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string EmailAddress { get; set; }

		public string HashedPassword { get; set; }
	}

}