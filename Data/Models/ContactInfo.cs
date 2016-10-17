using System.ComponentModel.DataAnnotations.Schema;

namespace Training4Developers.Data.Models
{

	[Table("contact_info")]
	public class ContactInfo
	{
		public int Id { get; set; }

		public int ParentId { get; set; }

		public string Method { get; set; }

		public string Value { get; set; }

		public int Priority { get; set; }
	}

}