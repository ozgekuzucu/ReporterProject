using ReporterProject.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReporterProject.DataAccessLayer.Abstract
{
	public interface IArticleDal : IGenericDal<Article>
	{
		List<Article> GetArticlesByCategoryId1();
		List<Article> GetArticlesWithUser();
		List<Article> GetArticlesWithCategories();
		List<Article> GetArticlesWithCategoriesAndAppUsers();
		Article GetArticlesWithAuthorAndCategoriesById(int id);
		List<Article> GetArticlesByAuthor(string id);
		Article GetBySlug(string slug);
	}
}
