using System.Collections.Generic;

namespace Training4Developers.Interfaces {
	public interface IStudentRepo {
		IEnumerable<IStudent> GetAll();
		IStudent Get(int studentId);
		IStudent Insert(IStudent student);
		IStudent Update(IStudent student);
		IStudent Delete(int studentId);
		IStudent GetByEmailAddressAndPassword(string emailAddress, string password);
	}
}