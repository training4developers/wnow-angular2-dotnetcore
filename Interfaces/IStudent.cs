using System.Collections.Generic;

namespace Training4Developers.Interfaces { 
		public interface IStudent {
		int Id { get; set; }
		string FirstName { get; set; }
		string LastName { get; set; }
		IEnumerable<IContactInfo> EmailAddresses { get; }
		IStudent AppendEmailAddress(IContactInfo emailAddress);
		IStudent RemoveEmailAddress(int emailAddressId);
	}
}