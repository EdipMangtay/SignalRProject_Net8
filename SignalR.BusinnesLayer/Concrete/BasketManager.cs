using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    public class BasketManager : IBasketService
    {
        private readonly IBasketDal _basketdal;

        public BasketManager(IBasketDal basketService)
        {
           _basketdal = basketService;
        }

        public void TAdd(Basket entity)
        {
            _basketdal.Add(entity);         
        }

        public void TDelete(Basket entity)
        {
            _basketdal.Delete(entity);
        }

        public List<Basket> TGetBasketMenuTableNumber(int id)
        {
            return _basketdal.GetBasketMenuTableNumber(id);
        }

        public Basket TGetByID(int id)
        {
            return _basketdal.GetByID(id);
        }

        public List<Basket> TGetListAll()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Basket entity)
        {
            throw new NotImplementedException();
        }
    }
}
