using SignalRApi.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface IBookingDal : IGenericDal<Booking>
    {
        // for tr :  IGeneric dala zaten bir class geleceğini belirtmiştim şimdi Igenericdaldan miras aldığım methodlara booking sınıfını ekledim

    }
}
