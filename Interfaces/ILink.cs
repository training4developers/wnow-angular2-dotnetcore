using System;

namespace Training4Developers.Interfaces { 
	public interface ILink {
		int Id { get; set; }
		Uri Url { get; set; }
	}
}