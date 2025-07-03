using ReporterProject.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReporterProject.DataAccessLayer.Abstract
{
	public interface ICommentDal : IGenericDal<Comment>
	{
		List<Comment> GetCommentsByArticleId(int id);
	}
}
