using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using Training4Developers.Interfaces;

namespace Training4Developers.Controllers
{
	[Authorize]
	[Route("[controller]")]
	public class Users : Controller
	{
		private readonly IUserRepo _userRepo;

		public Users(IUserRepo userRepo) {
			_userRepo = userRepo;
		}

		[HttpGet]
		public IEnumerable<IUser> Get()
		{
			return _userRepo.GetAll();
		}

		[HttpGet("{userId}")]
		public IActionResult Get(int userId)
		{
			return new ObjectResult(_userRepo.Get(userId));
		}		
	}
}