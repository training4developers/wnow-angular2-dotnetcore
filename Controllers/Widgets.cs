using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using Training4Developers.Interfaces;
using Training4Developers.Models;

namespace Training4Developers.Controllers
{
	//[Authorize]
	[AllowAnonymous]
	[Route("[controller]")]
	public class Widgets : Controller
	{
		private readonly IWidgetRepo _widgetRepo;

		public Widgets(IWidgetRepo widgetRepo)
		{
			_widgetRepo = widgetRepo;
		}

		[HttpGet]
		public IEnumerable<IWidget> Get()
		{
			return _widgetRepo.GetAll();
		}

		[HttpGet("{widgetId}", Name="GetWidget")]
		public IActionResult Get(int widgetId)
		{
			var widget = _widgetRepo.Get(widgetId);

			if (widget == null)
			{
				return NotFound();
			}
			
			return new ObjectResult(widget);
		}

		[HttpPost]
		public IActionResult Insert([FromBody] Widget widget)
		{
			if (widget == null)
			{
				return BadRequest();
			}
			
			_widgetRepo.Insert(widget);
			
			return CreatedAtRoute("GetWidget", new { widgetId = widget.Id }, widget);
		}		

		[HttpPut("{widgetId}")]
		public IActionResult Update(int widgetId, [FromBody] Widget widget)
		{
			if (widget == null || widgetId != widget.Id)
			{
				return BadRequest();
			}

			if (_widgetRepo.Update(widget) == null)
			{
				return NotFound();
			}

			return new NoContentResult();
		}		

		[HttpPatch("{widgetId}")]
		public IActionResult Update([FromBody] Widget widget, int widgetId)
		{
			if (widget == null || widgetId != widget.Id)
			{
				return BadRequest();
			}

			if (_widgetRepo.Update(widget) == null)
			{
				return NotFound();
			}

			return new NoContentResult();
		}

		[HttpDelete("{widgetId}")]
		public IActionResult Delete(int widgetId)
		{
			if (_widgetRepo.Get(widgetId) == null)
			{
				return NotFound();
			}

			_widgetRepo.Delete(widgetId);

			return new NoContentResult();
		}					
	}
}