using System.Collections.Generic;
using System.Linq;

using Training4Developers.Models;
using Training4Developers.Interfaces;

namespace Training4Developers.Data
{
	public class UserRepo: IUserRepo
	{
		private readonly ApplicationDbContext _dbContext;

		public UserRepo(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public IEnumerable<IUser> GetAll() {
			// return _dbContext.Users.Select(s => new Student {
			// 	Id = s.Id,
			// 	FirstName = s.FirstName,
			// 	LastName = s.LastName
			// });
			return null;
		}

		public IUser GetByEmailAddressAndPassword(string emailAddress, string password) {
			// return _dbContext.Students.Join(
			// 	_dbContext.ContactInfos,
			// 	s => s.Id,
			// 	ci => ci.ParentId,
			// 	(s, ci) => new { Student = s, ContactInfo = ci }
			// ).Where(sci =>
			// 	sci.ContactInfo.Method == "email" &&
			// 	sci.ContactInfo.Value == emailAddress &&
			// 	sci.Student.HashedPassword == password
			// ).Select(sci => new Student {
			// 	Id = sci.Student.Id,
			// 	FirstName = sci.Student.FirstName,
			// 	LastName = sci.Student.LastName
			// }).SingleOrDefault();
			return null;
		}

		public IUser Get(int userId)
		{
			return null;
		}

		public IUser Insert(IUser user)
		{
			return null;
		}
		
		public IUser Update(IUser user)
		{
			return null;
		}
		
		public IUser Delete(int userId)
		{
			return null;
		}
	}
}