using System.Collections.Generic;

namespace Training4Developers.Interfaces
{
	public interface IWidgetRepo
	{
		IEnumerable<IWidget> GetAll();
		
		IWidget Get(int widgetId);
		
		IWidget Insert(IWidget widget);
		
		IWidget Update(IWidget widget);
		
		IWidget Delete(int widgetId);
	}
}