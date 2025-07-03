using ReporterProject.BusinessLayer.Abstract;
using ReporterProject.DataAccessLayer.Abstract;
using ReporterProject.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReporterProject.BusinessLayer.Concrete
{
	public class ArticleManager : IArticleService
	{
		private readonly IArticleDal _articleDal;
		private readonly ISlugService _slugService;

		public ArticleManager(IArticleDal articleDal, ISlugService slugService)
		{
			_articleDal = articleDal;
			_slugService = slugService;
		}

		public Article TGetBySlug(string slug)
		{
			return _articleDal.GetBySlug(slug);
		}

		public void TDelete(int id)
		{
			_articleDal.Delete(id);
		}

		public List<Article> TGetArticlesByAuthor(string id)
		{
			return _articleDal.GetArticlesByAuthor(id);
		}

		public List<Article> TGetArticlesByCategoryId1()
		{
			return _articleDal.GetArticlesByCategoryId1();
		}

		public Article TGetArticlesWithAuthorAndCategoriesById(int id)
		{
			return _articleDal.GetArticlesWithAuthorAndCategoriesById(id);
		}

		public List<Article> TGetArticlesWithCategories()
		{
			return _articleDal.GetArticlesWithCategories();
		}

		public List<Article> TGetArticlesWithCategoriesAndAppUsers()
		{
			return _articleDal.GetArticlesWithCategoriesAndAppUsers();
		}

		public List<Article> TGetArticlesWithUser()
		{
			return _articleDal.GetArticlesWithUser();
		}

		public Article TGetById(int id)
		{
			return _articleDal.GetById(id);
		}

		public List<Article> TGetListAll()
		{
			return _articleDal.GetListAll();
		}

		public void TInsert(Article entity)
		{
			if (entity.Title != null && entity.Title.Length > 10 && entity.CategoryId != 0 && entity.Content.Length <= 1000)
			{
				if (string.IsNullOrEmpty(entity.Slug))
				{
					entity.Slug = _slugService.GenerateSlug(entity.Title);
				}

				_articleDal.Insert(entity);
			}
			else
			{

			}
		}

		public void TUpdate(Article entity)
		{
			_articleDal.Update(entity);
		}
	}
}
