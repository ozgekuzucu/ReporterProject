using Microsoft.AspNetCore.Mvc;

namespace ReporterProject.PresentationLayer.ViewComponents
{
	public class _FooterDefaultComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
