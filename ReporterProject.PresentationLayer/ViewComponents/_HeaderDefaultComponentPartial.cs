using Microsoft.AspNetCore.Mvc;

namespace ReporterProject.PresentationLayer.ViewComponents
{
	public class _HeaderDefaultComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
