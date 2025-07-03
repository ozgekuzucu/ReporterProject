using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReporterProject.DataAccessLayer.Context;
using ReporterProject.EntityLayer.Entities;

namespace ReporterProject.PresentationLayer.Controllers
{
	public class DashboardController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly ArticleContext _context;

		public DashboardController(UserManager<AppUser> userManager, ArticleContext context)
		{
			_userManager = userManager;
			_context = context;
		}
		public async Task<IActionResult> Index()
		{
			var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);
			var userId = currentUser.Id;

			ViewBag.FullName = currentUser.Name + " " + currentUser.Surname;
			ViewBag.Image = currentUser.ImageUrl;

			var articles = _context.Articles
				.Where(x => x.AppUserId == userId)
				.Include(x => x.Category)
				.Include(x => x.Comments);

			// Toplam makale sayısı
			ViewBag.TotalArticles = await articles.CountAsync();

			// Toplam yorum sayısı
			ViewBag.TotalComments = await articles.SelectMany(x => x.Comments).CountAsync();

			// Farklı kategoride yazılan makale sayısı
			ViewBag.DistinctCategoryCount = await articles.Select(x => x.CategoryId).Distinct().CountAsync();

			// En çok yorum alan makalenin başlığı
			ViewBag.MostCommentedArticleTitle = await articles
				.OrderByDescending(x => x.Comments.Count)
				.Select(x => x.Title)
				.FirstOrDefaultAsync() ?? "Henüz makale yok";

			// Son eklenen makale bilgileri
			var latestArticle = await articles
				.OrderByDescending(x => x.CreatedDate)
				.FirstOrDefaultAsync();

			if (latestArticle != null)
			{
				ViewBag.LatestArticleTitle = latestArticle.Title;
				ViewBag.LatestArticleDate = latestArticle.CreatedDate.ToString("dd MMM yyyy");
				ViewBag.LatestArticleCategory = latestArticle.Category.CategoryName;
				ViewBag.LatestArticleCommentCount = latestArticle.Comments.Count;
			}

			// Kategorilere göre makale sayısı (grafik için)
			ViewBag.CategoryStats = await _context.Articles
				.Where(a => a.AppUserId == userId)
				.Include(a => a.Category)
				.GroupBy(a => a.Category.CategoryName)
				.Select(g => new
				{
					CategoryName = g.Key,
					Count = g.Count()
				})
				.ToListAsync();

			var categories = articles.Select(a => a.Category.CategoryName).Distinct().ToList();
			// Kategori bazında makale başlıklarını grupla
			var articlesByCategory = await _context.Articles
				.Where(a => a.AppUserId == userId)
				.Include(a => a.Category)
				.GroupBy(a => a.Category.CategoryName)
				.Select(g => new
				{
					Category = g.Key,
					Articles = g.Select(a => a.Title).ToList()
				})
				.ToListAsync();

			// Bunu dictionary'ye dönüştürüp ViewBag'e ekle (Razor içinde daha rahat kullanmak için)
			ViewBag.ArticlesByCategory = articlesByCategory.ToDictionary(x => x.Category, x => x.Articles);
			// Kategorilere göre makale sayısı
			var categoryStats = await articles
				.GroupBy(x => x.Category.CategoryName)
				.Select(g => new
				{
					CategoryName = g.Key,
					Count = g.Count()
				})
				.ToListAsync();

			ViewBag.CategoryNames = categoryStats.Select(x => x.CategoryName).ToList();
			ViewBag.CategoryCounts = categoryStats.Select(x => x.Count).ToList();

			var lastComments = await _context.Comments
			   .Where(c => c.Article.AppUserId == userId)  // Yalnızca kendi makalelerine yazılan yorumlar
			   .OrderByDescending(c => c.CommentDate)
			   .Take(3)  // Son 3 yorum
			   .Select(c => new
			   {
				   ArticleTitle = c.Article.Title,
				   CommentText = c.CommentDetail.Length > 50 ? c.CommentDetail.Substring(0, 50) + "..." : c.CommentDetail,
				   CreatedDate = c.CommentDate,
				   UserName = c.AppUser.Name + " " + c.AppUser.Surname
			   })
			   .ToListAsync();

			ViewBag.LastComments = lastComments;

			return View();
		}
	}
}
