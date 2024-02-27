using SignalRApi.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface IAboutDal : IGenericDal<About>
    {
        // It became clear to get rid of the code garbage by inheriting all the methods in genericdal
    }
}
