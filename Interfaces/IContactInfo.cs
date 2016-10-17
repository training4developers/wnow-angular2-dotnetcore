using Training4Developers.Enums;

namespace Training4Developers.Interfaces { 

	public interface IContactInfo {
		int Id { get; set; }
		ContactMethods Method { get; set; }
		string Value { get; set; }
		int Priority { get; set; }
	}

}