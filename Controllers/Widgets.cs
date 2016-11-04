using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using Training4Developers.Interfaces;
using Training4Developers.Models;

namespace Training4Developers.Controllers
{
	[Authorize]
	[Route("[controller]")]
	public class Widgets : Controller
	{
		private readonly IWidgetRepo _widgetRepo;

		public Widgets(IWidgetRepo widgetRepo)
		{
			_widgetRepo = widgetRepo;
		}

		[HttpGet]
		public IActionResult Get()
		{
			return new ObjectResult(_widgetRepo.GetAll());
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

			return NoContent();
		}		

		[HttpPatch("{widgetId}")]
		public IActionResult Update([FromBody] Widget widget, int widgetId)
		{
			return this.Update(widgetId, widget);
		}

		[HttpDelete("{widgetId}")]
		public IActionResult Delete(int widgetId)
		{
			if (_widgetRepo.Delete(widgetId) == null)
			{
				return NotFound();
			}

			return NoContent();
		}					
	}
}