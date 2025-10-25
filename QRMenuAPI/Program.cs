using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using QRMenuAPI.Hubs;
using SignalR.BussinessLayer.Abstract;
using SignalR.BussinessLayer.Concrete;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.EntityFramework;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

// ------------------- CORS -------------------
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyHeader()
              .AllowAnyMethod()
              .SetIsOriginAllowed((host) => true)
              .AllowCredentials();
    });
});

// ------------------- SignalR -------------------
builder.Services.AddSignalR();

// ------------------- DbContext -------------------
builder.Services.AddDbContext<SignalRContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ------------------- AutoMapper -------------------
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// ------------------- Dependency Injection -------------------
builder.Services.AddScoped<IAboutService, AboutManager>();
builder.Services.AddScoped<IAboutDal, EfAboutDal>();

builder.Services.AddScoped<IBookingService, BookingManager>();
builder.Services.AddScoped<IBookingDal, EfBookingDal>();

builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();

builder.Services.AddScoped<IContactService, ContactManager>();
builder.Services.AddScoped<IContactDal, EfContactDal>();

builder.Services.AddScoped<IDiscountService, DiscountManager>();
builder.Services.AddScoped<IDiscountDal, EfDiscountDal>();

builder.Services.AddScoped<IFeatureService, FeatureManager>();
builder.Services.AddScoped<IFeatureDal, EfFeatureDal>();

builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<IProductDal, EfProductDal>();

builder.Services.AddScoped<ISocialMediaService, SocialMediaManager>();
builder.Services.AddScoped<ISocialMediaDal, EfSocialMediaDal>();

builder.Services.AddScoped<ITestoimonialService, TestimonialManager>();
builder.Services.AddScoped<ITestimonialDal, EfTestimonialDal>();

builder.Services.AddScoped<IOrderDetailService, OrderDetailManager>();
builder.Services.AddScoped<IOrderDetailDal, EfOrderDetailDal>();

builder.Services.AddScoped<IOrderService, OrderManager>();
builder.Services.AddScoped<IOrderDal, EfOrderDal>();

// ------------------- Controllers & Swagger -------------------
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "QRMenu API",
        Version = "v1",
        Description = "QRMenu Projesi için geliştirilmiş API dokümantasyonu"
    });
});

// ------------------- App Pipeline -------------------
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // ✔️ Hataları detaylı görmek için
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "QRMenu API v1");
        c.DocExpansion(DocExpansion.None);
    });
}

app.UseCors("CorsPolicy");
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();
app.MapHub<SignalRhub>("/signalRHub");

app.Run();
