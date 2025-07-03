using Microsoft.AspNetCore.Mvc;
using ReporterProject.BusinessLayer.Abstract;

namespace ReporterProject.PresentationLayer.ViewComponents
{
	public class _ArticleListDefaultComponentPartial : ViewComponent
	{
		private readonly IArticleService _articleService;

		public _ArticleListDefaultComponentPartial(IArticleService articleService)
		{
			_articleService = articleService;
		}

		public IViewComponentResult Invoke()
		{
			var values = _articleService.TGetArticlesWithCategoriesAndAppUsers().OrderByDescending(x => x.CreatedDate)
			   .Take(9)
			   .ToList();
			return View(values);
		}
	}
}
