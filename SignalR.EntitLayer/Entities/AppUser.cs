using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.EntityLayer.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public string Ad { get; set; }
        public string Surname { get; set; }
    }
}
