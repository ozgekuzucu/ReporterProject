using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReporterProject.BusinessLayer.Abstract;
using ReporterProject.DataAccessLayer.Abstract;
using ReporterProject.DataAccessLayer.Context;

namespace ReporterProject.PresentationLayer.Controllers
{
	public class ArticleController : Controller
	{
		private readonly IArticleService _articleService;
		private readonly ArticleContext _context;
		public ArticleController(IArticleService articleService, ArticleContext context)
		{
			_articleService = articleService;
			_context = context;
		}

		[Route("Article/ArticleDetail/{slug}")]
		public IActionResult ArticleDetail(string slug)
		{
			var article = _context.Articles
								  .Include(a => a.Category)
								  .Include(a => a.AppUser)
								  .FirstOrDefault(a => a.Slug == slug);

			if (article == null)
				return NotFound();

			ViewBag.id = article.ArticleId;
			return View();
		}
	}
}
