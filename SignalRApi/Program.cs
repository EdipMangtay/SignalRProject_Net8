using SignalR.BusinessLayer.Abstract;
using SignalR.BusinessLayer.Concrete;
using SignalR.BusinnesLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.EntityFramework;
using SignalR.DataAccessLayer.Migrations;
using SignalRApi.Hubs;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
	options.AddPolicy("CorsPolicy", builder => builder // Cors politikası oluşturuldu
    		.AllowAnyMethod() // Tüm metotlara izin ver
            		.AllowAnyHeader() //Başlıklara izin ver
                                      .SetIsOriginAllowed((host)=>true)		
                            		.AllowCredentials()); //
});

builder.Services.AddSignalR();

builder.Services.AddControllers().AddJsonOptions(options =>
    options.AllowInputFormatterExceptionMessages = false);

builder.Services.AddDbContext<SignalRContext>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());



builder.Services.AddScoped<IAboutService, AboutManager>();//AboutManager sınıfı IAboutService arayüzüne bağlandı
builder.Services.AddScoped<IAboutDal, EfAboutDal>();//EfAboutDal sınıfı IAboutDal arayüzüne bağlandı

builder.Services.AddScoped<IBookingService, BookingManager>();//BookingManager sınıfı IBookingService arayüzüne bağlandı
builder.Services.AddScoped < IBookingDal, EfBookingDal>();//EfBookingDal sınıfı IBookingDal arayüzüne bağlandı

builder.Services.AddScoped<ICategoryService, CategoryManager>();//CategoryManager sınıfı ICategoryService arayüzüne bağlandı
builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();//EfCategoryDal sınıfı ICategoryDal arayüzüne bağlandı

builder.Services.AddScoped<IContactService, ContactManager>();//ContactManager sınıfı IContactService arayüzüne bağlandı
builder.Services.AddScoped<IContactDal, EfContactDal>();//EfContactDal sınıfı IContactDal arayüzüne bağlandı

builder.Services.AddScoped<IDiscoutService, DiscountManager>();//DiscountManager sınıfı IDiscoutService arayüzüne bağlandı
builder.Services.AddScoped<IDiscountDal, EfDiscountDal>();//EfDiscountDal sınıfı IDiscountDal arayüzüne bağlandı

builder.Services.AddScoped<IFeatureService, FeatureManager>();//FeatureManager sınıfı IFeatureService arayüzüne bağlandı
builder.Services.AddScoped<IFeatureDal, EfFeatureDal>();//EfFeatureDal sınıfı IFeatureDal arayüzüne bağlandı

builder.Services.AddScoped<ISocialMediaService, SocialMediaManager>();//SocialMediaManager sınıfı ISocialMediaService arayüzüne bağlandı
builder.Services.AddScoped<ISocialMediaDal, EfSocialMediaDal>(); //EfSocialMediaDal sınıfı ISocialMediaDal arayüzüne bağlandı

builder.Services.AddScoped<ITestimonialService, TestimonialManager>();//TestimonialManager sınıfı ITestimonialService arayüzüne bağlandı
builder.Services.AddScoped<ITestimonialDal, EfTestimonialDal>();//EfTestimonialDal sınıfı ITestimonialDal arayüzüne bağlandı

builder.Services.AddScoped<IProductService, ProductManager>();//ProductManager sınıfı IProductService arayüzüne bağlandı
builder.Services.AddScoped<IProductDal, EfProductDal>();//EfProductDal sınıfı IProductDal arayüzüne bağlandı

builder.Services.AddScoped<IOrderService, OrderManager>();//OrderManager sınıfı IOrderService arayüzüne bağlandı
builder.Services.AddScoped<IOrderDal, EfOrderDal>();//EfOrderDal sınıfı IOrderDal arayüzüne bağlandı
builder.Services.AddScoped<IOrderDetailService, OrderDetailManager>();//OrderManager sınıfı IOrderService arayüzüne bağlandı
builder.Services.AddScoped<IOrderDetailDal, EfOrderDetailDal>();//EfOrderDal sınıfı IOrderDal arayüzüne bağlandı

builder.Services.AddScoped<IMoneyCaseService, MoneyCaseManager>(); //MoneyCaseManager sınıfı IMoneyCaseService arayüzüne bağlandı
builder.Services.AddScoped<IMoneyCaseDal, EfMoneyCaseDal>(); //EfMoneyCaseDal sınıfı IMoneyCaseDal arayüzüne bağlandı

builder.Services.AddScoped<IMenutableService, MenuTableManager>();
builder.Services.AddScoped<IMenuTableDal, EfMenuTableDal>();






builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy"); // Cors politikası uygulandı

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapHub<SignalRHub>("/signalrhub");//SignalRHub sınıfı signalrhub olarak tanımlandı // istekte ulunacağım adresi belirledik 

app.Run();
//localhost:5001/swagger bunun gibi bir araçla beraeber ben loccalhost:5001/signalrhub adresine giderek signalrhub ı test edebilirim