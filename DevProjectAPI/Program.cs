using DevProjectAPI.Infrastructure.Helpers;
using DevProjectAPI.Infrastructure.Repositories;
using DevProjectAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<DbSettings>(builder.Configuration.GetSection("DatabaseSettings"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<UserRepository>();
builder.Services.AddTransient<ProductRepository>();
builder.Services.AddTransient<UserService>();
builder.Services.AddTransient<ProductService>();

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
