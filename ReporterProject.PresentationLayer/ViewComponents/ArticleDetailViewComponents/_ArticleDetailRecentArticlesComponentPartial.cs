using Microsoft.AspNetCore.Mvc;
using ReporterProject.BusinessLayer.Abstract;

namespace ReporterProject.PresentationLayer.ViewComponents.ArticleDetailViewComponents
{
	public class _ArticleDetailRecentArticlesComponentPartial : ViewComponent
	{
		private readonly IArticleService _articleService;

		public _ArticleDetailRecentArticlesComponentPartial(IArticleService articleService)
		{
			_articleService = articleService;
		}

		public IViewComponentResult Invoke()
		{
			var values = _articleService.TGetListAll()
						.OrderByDescending(x => x.CreatedDate)
						.Take(5)
						.ToList();
			return View(values);
		}
	}
}
