using SignalRApi.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinnesLayer.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
        List<Product> TGetProductsWithCategories();
        public int TProductCount(); // bu metot IProductService implemente edildiğinde kullanılacak
        public int TProductCountByCategoryNameHamburger(); // bu metot IProductService implemente edildiğinde kullanılacak
        public int TProductCountByCategoryNameDrink(); // bu metot IProductService implemente edildiğinde kullanılacak
        decimal TProductPriceAvg();
        string TProductPriceByMax();
        string TProductPriceByMin();
        decimal TProductPriceByHamburger();



    }
}
