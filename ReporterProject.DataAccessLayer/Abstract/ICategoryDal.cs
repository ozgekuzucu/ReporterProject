using ReporterProject.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReporterProject.DataAccessLayer.Abstract
{
	public interface ICategoryDal : IGenericDal<Category>
	{
		int GetCategoryCount();
	}
}
