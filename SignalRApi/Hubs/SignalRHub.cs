using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.SignalR;
using SignalR.DataAccessLayer.Concrete;

namespace SignalRApi.Hubs
{// hub burada bir sunucu olacak
	//Burada Cors mantığı var bu da eğer signalR kullanılacaksa bunun konfigürasyonu yapılmalı
	public class SignalRHub : Hub
	{
		SignalRContext context = new SignalRContext();
		public async Task SendCategoryCount() //Client tarafından çağrılacak 
		{
			var value = context.Categories.Count();
			await Clients.All.SendAsync("ReceiveCategoryCount", value); //Tüm clientlara gönderilecek
		}
	}
}
