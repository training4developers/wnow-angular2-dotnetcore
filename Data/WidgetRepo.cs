using System.Collections.Generic;
using System.Linq;

using Training4Developers.Models;
using Training4Developers.Interfaces;

using WidgetData = Training4Developers.Data.Models.Widget;

namespace Training4Developers.Data
{
	public class WidgetRepo: IWidgetRepo
	{
		private readonly ApplicationDbContext _dbContext;

		public WidgetRepo(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public IEnumerable<IWidget> GetAll() {
			return _dbContext.Widgets.Select(w => new Widget {
				Id = w.Id,
				Name = w.Name,
				Description = w.Description,
				Color = w.Color,
				Size = w.Size,
				Quantity = w.Quantity,
				Price = w.Price
			});
		}

		public IWidget Get(int widgetId)
		{
			return _dbContext.Widgets.Where(w => w.Id == widgetId).Select(w => new Widget {
				Id = w.Id,
				Name = w.Name,
				Description = w.Description,
				Color = w.Color,
				Size = w.Size,
				Quantity = w.Quantity,
				Price = w.Price
			}).SingleOrDefault();
		}

		public IWidget Insert(IWidget widget)
		{
			var newWidget = new WidgetData {
				Name = widget.Name,
				Description = widget.Description,
				Color = widget.Color,
				Size = widget.Size,
				Quantity = widget.Quantity,
				Price = widget.Price
			};

			_dbContext.Widgets.Add(newWidget);
			_dbContext.SaveChanges();

			widget.Id = newWidget.Id;

			return widget;
		}
		
		public IWidget Update(IWidget widget)
		{
			var findWidget = _dbContext.Widgets.SingleOrDefault(w => w.Id == widget.Id);

			if (findWidget == null)
			{
				return null;
			}

			findWidget.Name = widget.Name;
			findWidget.Description = widget.Description;
			findWidget.Color = widget.Color;
			findWidget.Size = widget.Size;
			findWidget.Quantity = widget.Quantity;
			findWidget.Price = widget.Price;

			_dbContext.SaveChanges();			

			return widget;
		}
		
		public IWidget Delete(int widgetId)
		{
			var widget = _dbContext.Widgets.SingleOrDefault(w => w.Id == widgetId);

			if (widget == null)
			{
				return null;
			}

			_dbContext.Widgets.Remove(widget);
			_dbContext.SaveChanges();
			
			return new Widget {
				Id = widget.Id,
				Name = widget.Name,
				Description = widget.Description,
				Color = widget.Color,
				Size = widget.Size,
				Quantity = widget.Quantity,
				Price = widget.Price
			};
		}
	}
}