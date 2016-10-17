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