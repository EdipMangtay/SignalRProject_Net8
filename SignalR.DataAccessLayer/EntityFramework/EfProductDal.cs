using Microsoft.EntityFrameworkCore;
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
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public EfProductDal(SignalRContext context) : base(context)
            // burada EfProductDal sınıfını oluşturduk ve GenericRepository sınıfından kalıtım aldık
        {
        }

        public List<Product> GetProductsWithCategories()
        {
            var context = new SignalRContext();
            var values = context.Products.Include(x => x.Category).ToList();
            return values;
            // burada context.Products tablosundaki kayıtları context.Categories tablosundaki kayıtlarla birleştirip döndürdük

        }

		public int ProductCount()
		{
            using var context = new SignalRContext(); // burada signalrcontext örnekledik
            return context.Products.Count(); // context.Products tablosundaki kayıt sayısını döndürdük

		}

        public int ProductCountByCategoryNameDrink()
        {
            using var context = new SignalRContext();
            return context.Products.Where(x=> x.CategoryID==(context.Categories.Where(y=>y.CategoryName=="İçecek").Select(z=> z.Categoryid)).FirstOrDefault()).Count();
            // burada içecek kategorisindeki ürün sayısını döndürdük

        }

        public int ProductCountByCategoryNameHamburger()
        {
            using var context = new SignalRContext();
            return context.Products.Where(x => x.CategoryID == (context.Categories.Where(y => y.CategoryName == "Hamburger").Select(z => z.Categoryid)).FirstOrDefault()).Count();
            // burada hamburger kategorisindeki ürün sayısını döndürdük
        }

        public decimal ProductPriceAvg()
        {
           using var context = new SignalRContext();
            
            return context.Products.Average(x => x.Price);
            // burada context.Products tablosundaki Price alanındaki değerlerin ortalamasını döndürdük

        }

        public decimal ProductPriceByHamburger()
        {
            using var context = new SignalRContext();
            return context.Products.Where(x => x.CategoryID == (context.Categories.Where(y => y.CategoryName == "Hamburger").Select(z => z.Categoryid)).FirstOrDefault()).Average(w => w.Price);
            // burada hamburger kategorisindeki ürünlerin fiyatlarının ortalamasını döndürdük
        }

        public string ProductPriceByMax()
        {
            using var context = new SignalRContext();
           return context.Products.Where(x=>x.Price==(context.Products.Max(context=>context.Price))).Select(z=>z.ProductName).FirstOrDefault();
            // burada context.Products tablosundaki Price alanındaki en yüksek değeri döndürdük
        }

        public string ProductPriceByMin()
        {
            using var context = new SignalRContext();
            return context.Products.Where(x => x.Price == (context.Products.Min(context => context.Price))).Select(z => z.ProductName).FirstOrDefault();
            // burada context.Products tablosundaki Price alanındaki en düşük değeri döndürdük
        }
    }
}
