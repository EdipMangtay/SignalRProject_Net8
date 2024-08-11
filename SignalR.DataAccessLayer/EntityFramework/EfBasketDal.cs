using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfBasketDal : GenericRepository<Basket>, IBasketDal
    {
        public EfBasketDal(SignalRContext context) : base(context)
        {

        }

        public List<Basket> GetBasketMenuTableNumber(int id)
        {
            using var context = new SignalRContext();    // using bloğu ile context nesnesini oluşturduk.
            var values = context.Baskets.Where(x => x.MenuTableID == id).ToList(); // MenuTableID'si id'ye eşit olanları getir.
            return values;
        }
    }
}
