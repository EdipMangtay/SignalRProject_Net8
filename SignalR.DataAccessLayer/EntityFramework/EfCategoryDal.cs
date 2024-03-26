using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalRApi.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        public EfCategoryDal(SignalRContext context) : base(context)
        {

        }

        public int ActiveCategoryCount() 
        {
            using var context = new SignalRContext();
            return context.Categories.Where(x => x.Status ==true).Count();
        }
        public int PassiveCategoryCount()
        {
            using var context = new SignalRContext();
            return context.Categories.Where(x => x.Status == false).Count(); // context.Categories tablosundaki kayıtların durumu false olanları saydık
        }
      

        public int CategoryCount()
		{
			using var context = new SignalRContext();// signalrcontext örnekledik
			return context.Categories.Count();// context.Categories tablosundaki kayıt sayısını döndürdük
		}
	}
}
