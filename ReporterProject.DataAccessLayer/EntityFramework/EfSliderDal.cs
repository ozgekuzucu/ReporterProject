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
	public class EfSliderDal : GenericRepository<Slider>, ISliderDal
	{
		public EfSliderDal(ArticleContext context) : base(context)
		{
		}
	}
}
