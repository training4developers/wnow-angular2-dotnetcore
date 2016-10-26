using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using Training4Developers.Interfaces;
using Training4Developers.Models;

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

		[HttpGet("{userId}", Name="GetUser")]
		public IActionResult Get(int userId)
		{
			return new ObjectResult(_userRepo.Get(userId));
		}

		[HttpPost]
		public IActionResult Insert([FromBody] User user) {

			if (user == null)
			{
				return BadRequest();
			}

			_userRepo.Insert(user);

			return CreatedAtRoute("GetUser", new { userId = user.Id }, user);
		}

		[HttpPut("{userId}")]
		public IActionResult Update(int userId, [FromBody] User user) {

			if (user == null || user.Id != userId)
			{
				return BadRequest();
			}

			if (_userRepo.Update(user) == null)
			{
				return NotFound();
			}

			return NoContent();
		}

		[HttpPatch("{userId}")]
		public IActionResult Update([FromBody] User user, int userId) {
			return this.Update(userId, user);
		}

		[HttpDelete("{userId}")]
		public IActionResult Delete(int userId) {

			if (_userRepo.Delete(userId) == null) {
				return NotFound();
			}

			return NoContent();
		}
	}
}