using System.ComponentModel.DataAnnotations.Schema;

namespace Training4Developers.Data.Models
{
	[Table("students")]
	public class Student
	{
		public int Id { get; set; }

		[Column("first_name")]
		public string FirstName { get; set; }

		[Column("last_name")]
		public string LastName { get; set;}

		[Column("hashed_password")]
		public string HashedPassword { get; set;}
	}

}