using Microsoft.AspNetCore.Mvc;

namespace Training4Developers
{
	public class Home: Controller
	{
		public IActionResult Index()
		{
			return View();
		}

	}
}