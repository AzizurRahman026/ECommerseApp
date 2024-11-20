using Core.Interface;
using ECommerseApp.Middleware;
using Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// for appsettings.json file access...
var configuration = builder.Configuration;

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddCors();

builder.Services.AddSingleton<MongoDbContext>(sp =>
{
    string connectionUri = configuration.GetSection("ConnectionStrings:connectionUri").Value; // Adjust if needed
    string databaseName = configuration.GetSection("ConnectionStrings:databaseName").Value;

    return new MongoDbContext(connectionUri, databaseName);
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Enable authentication and authorization middleware

app.UseHttpsRedirection();
// app.UseMiddleware<ExceptionMiddleware>();

app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4201", "http://localhost:4200"));

app.MapControllers();


app.Run();


// swagger run url
// http://localhost:4201/swagger
// http://localhost:4201/swagger/index.html