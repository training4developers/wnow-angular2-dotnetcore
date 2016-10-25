using System.Collections.Generic;
using System.Linq;

using Training4Developers.Interfaces;

using UserModel = Training4Developers.Models.User;
using UserData = Training4Developers.Data.Models.User;

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
			return _dbContext.Users.Select(u => new UserModel {
				Id = u.Id,
				FirstName = u.FirstName,
				LastName = u.LastName,
				EmailAddress = u.EmailAddress,
				HashedPassword = u.HashedPassword
			});
		}

		public IUser Get(int userId)
		{
			return _dbContext.Users.Where(u => u.Id == userId)
				.Select(u => new UserModel {
					Id = u.Id,
					FirstName = u.FirstName,
					LastName = u.LastName,
					EmailAddress = u.EmailAddress,
					HashedPassword = u.HashedPassword
				}).SingleOrDefault();
		}

		public IUser Insert(IUser user)
		{
			var newUser = new UserData {
				FirstName = user.FirstName,
				LastName = user.LastName,
				EmailAddress = user.EmailAddress,
				HashedPassword = user.HashedPassword
			};

			_dbContext.Users.Add(newUser);
			_dbContext.SaveChanges();
			
			user.Id = newUser.Id;

			return user;
		}
		
		public IUser Update(IUser user)
		{
			var editUser = _dbContext.Users.SingleOrDefault(u => u.Id == user.Id);

			if (editUser == null) {
				return null;
			}

			editUser.FirstName = user.FirstName;
			editUser.LastName = user.LastName;
			editUser.EmailAddress = user.EmailAddress;
			editUser.HashedPassword =  user.HashedPassword;

			_dbContext.SaveChanges();

			return user;
		}
		
		public IUser Delete(int userId)
		{
			var deleteUser = _dbContext.Users.SingleOrDefault(u => u.Id == userId);

			if (deleteUser == null)
			{
				return null;
			}

			_dbContext.Users.Remove(deleteUser);
			_dbContext.SaveChanges();

			return new UserModel {
				Id = deleteUser.Id,
				FirstName = deleteUser.FirstName,
				LastName = deleteUser.LastName,
				EmailAddress = deleteUser.EmailAddress,
				HashedPassword = deleteUser.HashedPassword
			};
		}

		public IUser GetByEmailAddressAndPassword(string emailAddress, string password) {

			return _dbContext.Users.Where(u =>
				u.EmailAddress == emailAddress &&
				u.HashedPassword == password).Select(u => new UserModel {
					FirstName = u.FirstName,
					LastName = u.LastName,
					EmailAddress = u.EmailAddress,
					HashedPassword = u.HashedPassword
				}).SingleOrDefault();

		}

		private string hashPassword(string password) {
			return password;
		}
	}
}