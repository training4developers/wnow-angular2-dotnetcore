using System.Collections.Generic;

namespace Training4Developers.Interfaces
{
	public interface IUserRepo
	{		
		IEnumerable<IUser> GetAll();
		
		IUser Get(int userId);
		
		IUser Insert(IUser user);
		
		IUser Update(IUser user);
		
		IUser Delete(int userId);
		
		IUser GetByEmailAddressAndPassword(string emailAddress, string password);
	}
}