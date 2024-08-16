using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.SignalR;
using SignalR.BusinessLayer.Abstract;
using SignalR.BusinnesLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;

namespace SignalRApi.Hubs
{// hub burada bir sunucu olacak
	//Burada Cors mantığı var bu da eğer signalR kullanılacaksa bunun konfigürasyonu yapılmalı
	//Burası bir Sunucu olacak ve clientlar buraya bağlanacak
	public class SignalRHub : Hub
	{
		private readonly ICategoryService _categoryService; // Kategori servisi oluşturuldu
		private readonly IProductService _productService; // Ürün servisi oluşturuldu
		private readonly IOrderService _orderService; // Sipariş servisi oluşturuldu
		private readonly IMoneyCaseService _moneyCaseService; // Kasa servisi oluşturuldu
		private readonly IMenutableService _menutableService; // Menü tablosu servisi oluşturuldu
		private readonly IBookingService _bookingService;
		private readonly INotificationService _notificationService;


        public SignalRHub(ICategoryService categoryService, IProductService productService, IOrderService orderService, IMoneyCaseService moneyCaseService, IMenutableService menutableService, IBookingService bookingService, INotificationService notificationService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _orderService = orderService;
            _moneyCaseService = moneyCaseService;
            _menutableService = menutableService;
            _bookingService = bookingService;
            _notificationService = notificationService;
        }

        public async Task SendStatistic() //Client tarafından çağrılacak 
		{
			var value = _categoryService.TCategoryCount(); // Kategorilerin sayısı alındı
			await Clients.All.SendAsync("ReceiveCategoryCount", value); //Tüm clientlara gönderilecek
																		// Bursası aslında bir tetikleyici

			var value2 = _productService.TProductCount(); // Ürünlerin sayısı alındı
			await Clients.All.SendAsync("ReceiveProductCount", value2);

			var value3 = _categoryService.TActiveCategoryCount(); // Aktif kategoriler alındı
			var value4 = _categoryService.TPassiveCategoryCount(); // Pasif kategoriler alındı

			await Clients.All.SendAsync("ReceiveActiveCategoryCount", value3); //Tüm clientlara gönderilecek
			await Clients.All.SendAsync("ReceivePassiveCategoryCount", value4); //Tüm clientlara gönderilecek

			var value5 = _productService.TProductCountByCategoryNameHamburger(); // Hamburger kategorisindeki ürün sayısı alındı
			await Clients.All.SendAsync("ReceiveProductCountByCategoryNameHamburger", value5); //Tüm clientlara gönderilecek

			var value6 = _productService.TProductCountByCategoryNameDrink(); // Pizza kategorisindeki ürün sayısı alındı
			await Clients.All.SendAsync("ReceiveProductCountByCategoryNameDrink", value6); //Tüm clientlara gönderilecek

			var value7 = _productService.TProductPriceAvg(); 
			await Clients.All.SendAsync("ReceiveProductPriceAvg", value7.ToString("0.00" + "₺")); // Ürünlerin ortalama fiyatı alındı ve tüm clientlara gönderilecek


			var value8 = _productService.TProductPriceByMax();
			await Clients.All.SendAsync("ReceiveProductPriceByMax", value8);

			var value9  =_productService.TProductPriceByMin();
			await Clients.All.SendAsync("ReceiveProductPriceByMin", value9);

			var value10 = _orderService.TTotalOrderCount();
			await Clients.All.SendAsync("ReceiveTotalOrderCount", value10);

			var value11 = _orderService.TActiveOrderCount();
			await Clients.All.SendAsync("ReceiveActiveOrderCount", value11);

			var value12 = _orderService.TLastOrderPrice();
			await Clients.All.SendAsync("ReceiveLastOrderPrice", value12.ToString("0.00" + "₺"));

			var value13 = _moneyCaseService.TTotalMoneyCaseAmount();
			await Clients.All.SendAsync("ReceiveTotalMoneyCaseAmount", value13.ToString("0.00" + "₺"));
			
			var value14 = _menutableService.TMenuTableCount();
			await Clients.All.SendAsync("ReceiveMenuTableCount", value14);

		}

		public async Task SendProgress()
		{
			var value = _moneyCaseService.TTotalMoneyCaseAmount();
			await Clients.All.SendAsync("ReceiveTtotalMoneyCaseAmount", value);

			var value2 = _orderService.TActiveOrderCount();
			await Clients.All.SendAsync("ReceiveActiveOrderCount", value2);
			
			var value3 = _menutableService.TMenuTableCount();
			await Clients.All.SendAsync("ReceiveMenuTableCount", value3);
		}
		public async Task GetBookingList()
		{
			var values = _bookingService.TGetListAll();
			await Clients.All.SendAsync("ReceiveBookingList", values);
        }
		public async Task SendNotification()
		{
			var value = _notificationService.TNotificationCountByFalse();
            await Clients.All.SendAsync("ReceiveNotificationCountByFalse", value);

			var notificationListByFalse = _notificationService.TGetAllNotificationByFalse();
            await Clients.All.SendAsync("ReceiveNotificationListByFalse", notificationListByFalse);
        }


	}
}
