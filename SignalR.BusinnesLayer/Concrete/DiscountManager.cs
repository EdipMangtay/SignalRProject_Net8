using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SignalR.BusinnesLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalRApi.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    public class DiscountManager : IDiscoutService
    {
        private readonly IDiscountDal _discountDal;

        public DiscountManager(IDiscountDal discountDal)
        {
            _discountDal = discountDal;
        }

        public void TAdd(Discount entity)
        {
            _discountDal.Add(entity);

        }

        public void TChangeStatusToFalse(int id)
        {
            _discountDal.ChangeStatusToFalse(id);
        }

        public void TChangeStatusToTrue(int id)
        {
            _discountDal.ChangeStatusToTrue(id);
        }

        public void TDelete(Discount entity)
        {
            _discountDal.Delete(entity);

        }

        public Discount TGetByID(int id)
        {
            return _discountDal.GetByID(id);

        }

        public List<Discount> TGetListAll()
        {
            return _discountDal.GetListAll();

        }

        public void TUpdate(Discount entity)
        {
            _discountDal.Update(entity);

        }
    }
}
