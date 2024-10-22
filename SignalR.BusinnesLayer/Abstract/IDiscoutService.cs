﻿using SignalRApi.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinnesLayer.Abstract
{
    public interface IDiscoutService : IGenericService<Discount>
    {
		void TChangeStatusToTrue(int id);
		void TChangeStatusToFalse(int id);
	}
}
