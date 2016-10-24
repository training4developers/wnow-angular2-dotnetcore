using System.Collections.Generic;
using System.Linq;

using Training4Developers.Models;
using Training4Developers.Interfaces;

namespace Training4Developers.Data
{
	public class StudentRepo: IStudentRepo
	{
		private readonly ApplicationDbContext _dbContext;

		public StudentRepo(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public IEnumerable<IStudent> GetAll() {
			return _dbContext.Students.Select(s => new Student {
				Id = s.Id,
				FirstName = s.FirstName,
				LastName = s.LastName
			});
		}

		public IStudent GetByEmailAddressAndPassword(string emailAddress, string password) {
			return _dbContext.Students.Join(
				_dbContext.ContactInfos,
				s => s.Id,
				ci => ci.ParentId,
				(s, ci) => new { Student = s, ContactInfo = ci }
			).Where(sci =>
				sci.ContactInfo.Method == "email" &&
				sci.ContactInfo.Value == emailAddress &&
				sci.Student.HashedPassword == password
			).Select(sci => new Student {
				Id = sci.Student.Id,
				FirstName = sci.Student.FirstName,
				LastName = sci.Student.LastName
			}).SingleOrDefault();
		}

		public IStudent Get(int studentId)
		{
			return null;
		}

		public IStudent Insert(IStudent student)
		{
			return null;
		}
		
		public IStudent Update(IStudent student)
		{
			return null;
		}
		
		public IStudent Delete(int studentId)
		{
			return null;
		}
	}
}