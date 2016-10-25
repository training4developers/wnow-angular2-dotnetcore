using System.ComponentModel.DataAnnotations.Schema;

namespace Training4Developers.Data.Models
{
	[Table("users")]
	public class User
	{
		public int Id { get; set; }

		[Column("first_name")]
		public string FirstName { get; set; }

		[Column("last_name")]
		public string LastName { get; set; }

		[Column("email_address")]
		public string EmailAddress { get; set; }

		[Column("hashed_password")]
		public string HashedPassword { get; set; }
	}

}