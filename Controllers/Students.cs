using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using Training4Developers.Interfaces;

namespace Training4Developers.Controllers
{
	[Authorize]
	[Route("[controller]")]
	public class Students : Controller
	{
		private readonly IStudentRepo _studentRepo;

		public Students(IStudentRepo studentRepo) {
			_studentRepo = studentRepo;
		}

		[HttpGet]
		public IEnumerable<IStudent> Get()
		{
			return _studentRepo.GetAll();
		}
	}
}