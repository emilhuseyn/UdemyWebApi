using Microsoft.EntityFrameworkCore;
using UdemyWebApi.Dal;
using UdemyWebApi.Repositories.Abstractions;
using UdemyWebApi.Repositories.Interfaces;
using UdemyWebApi.Services.Abstractions;
using UdemyWebApi.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ICategoryIRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService,CategoryService >();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
