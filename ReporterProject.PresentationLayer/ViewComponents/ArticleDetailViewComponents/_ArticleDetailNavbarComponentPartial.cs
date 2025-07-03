using Microsoft.AspNetCore.Mvc;

namespace ReporterProject.PresentationLayer.ViewComponents.ArticleDetailViewComponents
{
	public class _ArticleDetailNavbarComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
