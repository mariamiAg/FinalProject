using FinalProject.BusinesLogic.Contracts;
using FinalProject.BusinesLogic.Services;
using FinalProject.DataAccess;
using FinalProject.Repositories.Interfaces;
using FinalProject.Repositories.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var ConnectionToString = builder.Configuration.GetConnectionString("Web_Try2NewEntities");
builder.Services.AddDbContext<WebTry2Context>(option => option.UseSqlServer(ConnectionToString, sqlServerOptionsAction: s => s.EnableRetryOnFailure()));
builder.Services.AddScoped<DbContext, WebTry2Context>();

#region repositories
static void ConfigureServices(IServiceCollection services)
{
    services.AddScoped<ICustomerService, CustomerService>();
    services.AddScoped<IProductService, ProductService>();
    services.AddScoped<ICustomerRepository, CustomerRepository>();
    services.AddScoped<IProductRepository, ProductRepository>();
    services.AddScoped<IWarehouseRepository, WarehouseRepository>();
    services.AddScoped<DbContext, WebTry2Context>();

}
#endregion

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
