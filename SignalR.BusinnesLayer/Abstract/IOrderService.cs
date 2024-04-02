using SignalR.BusinnesLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Abstract
{
    public interface IOrderService :IGenericService<Order>
    {
        int TTotalOrderCount(); //burası bana toplam sipariş sayısını döndürecek
        int TActiveOrderCount(); //burası bana aktif sipariş sayısını döndürecek
        decimal TLastOrderPrice();
    }
}
