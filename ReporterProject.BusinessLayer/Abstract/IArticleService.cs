using ReporterProject.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReporterProject.BusinessLayer.Abstract
{
	public interface IArticleService : IGenericService<Article>
	{
		public List<Article> TGetArticlesByCategoryId1();
		public List<Article> TGetArticlesWithUser();
		public List<Article> TGetArticlesWithCategories();
		public List<Article> TGetArticlesWithCategoriesAndAppUsers();
		public Article TGetArticlesWithAuthorAndCategoriesById(int id);
		List<Article> TGetArticlesByAuthor(string id);

		Article TGetBySlug(string slug);
	}
}
