using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace SignalRWebUI.ViewModels.Dtos.IdentityDtos
{
    public class RegisterDto
    {
        public string Surname { get; set; }
        public string Ad { get; set; }
        public string Username { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        
    }
}
