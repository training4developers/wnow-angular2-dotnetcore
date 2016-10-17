using System;
using System.Collections.Generic;

namespace Training4Developers.Interfaces {
	public interface ITrainingClass {
		int Id { get; set; }
		ICourse Course { get; }
		ILocation Location { get; }
		IEnumerable<IStudent> Students { get; }
		DateTime StartDate { get; set; }
		DateTime EndDate { get; set; }
		string ScheduleDetails { get; set; }
		ITrainingClass AssignCourse(ICourse course);
		ITrainingClass AssignLocation(ILocation location);
		ITrainingClass EnrollStudent(IStudent student);
		ITrainingClass WithdrawStudent(IStudent student);
	}
}