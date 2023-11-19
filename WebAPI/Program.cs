using Business.Abstrack;
using Business.Concrete;
using DataAccess.Abstrack;
using DataAccess.Concrete.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IProductService, ProductManager>();
builder.Services.AddSingleton<IProductDal,EfProductDal>();

builder.Services.AddSingleton<ICategoryService, CategoryManager>();
builder.Services.AddSingleton<ICategoryDal, EfCategoryDal>();

// Add services to the container.

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
