using Microsoft.EntityFrameworkCore;
using ProfitTest.Application.Services;
using ProfitTest.DAL;
using ProfitTest.DAL.Repositories;
using ProfitTest.Application;
using ProfitTest.Core.Interfaces.DAL;
using ProfitTest.Core.Interfaces.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLogging();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string host = Environment.GetEnvironmentVariable("DB_HOST")!;
string port = Environment.GetEnvironmentVariable("DB_PORT")!;
string db_name = Environment.GetEnvironmentVariable("DB_DATABASE")!;
string db_username = Environment.GetEnvironmentVariable("DB_USERNAME")!;
string db_password = Environment.GetEnvironmentVariable("DB_PASSWORD")!;
string db_setting = String.Format("Host={0}; Port={1}; User ID={2}; Password={3}; Database={4}; CommandTimeout=300;", host, port, db_username, db_password, db_name);

builder.Services.AddDbContext<ProductDbContext>(options => options.UseNpgsql(db_setting));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddApplication();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
