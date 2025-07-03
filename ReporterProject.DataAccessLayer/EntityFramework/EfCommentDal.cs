using Microsoft.EntityFrameworkCore;
using ReporterProject.DataAccessLayer.Abstract;
using ReporterProject.DataAccessLayer.Context;
using ReporterProject.DataAccessLayer.Repositories;
using ReporterProject.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReporterProject.DataAccessLayer.EntityFramework
{
	public class EfCommentDal : GenericRepository<Comment>, ICommentDal
	{
		private readonly ArticleContext _context;
		public EfCommentDal(ArticleContext context) : base(context)
		{
			_context = context;
		}

		public List<Comment> GetCommentsByArticleId(int id)
		{
			var values = _context.Comments.Include(y => y.AppUser).Where(x => x.ArticleId == id);
			return values.ToList();
		}
	}
}
