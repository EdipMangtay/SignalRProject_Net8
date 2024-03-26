using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.SignalR;
using SignalR.DataAccessLayer.Concrete;

namespace SignalRApi.Hubs
{// hub burada bir sunucu olacak
	//Burada Cors mantığı var bu da eğer signalR kullanılacaksa bunun konfigürasyonu yapılmalı
	//Burası bir Sunucu olacak ve clientlar buraya bağlanacak
	public class SignalRHub : Hub
	{
		SignalRContext context = new SignalRContext(); //Veritabanı bağlantısı oluşturuldu
		public async Task SendCategoryCount() //Client tarafından çağrılacak 
		{
			var value = context.Categories.Count(); // Kategorilerin sayısı alındı
			await Clients.All.SendAsync("ReceiveCategoryCount", value); //Tüm clientlara gönderilecek
			// Bursası aslında bir tetikleyici
			
		}  
	}
}
