using Microsoft.EntityFrameworkCore;
using URLShortener.Data;
using URLShortener.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<URLShortenerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("URLShortenerContext") ?? throw new InvalidOperationException("Connection string 'URLShortenerContext' not found.")));

// Add custom services
builder.Services.AddScoped<URLShortenerService>();

// Add controllers
builder.Services.AddControllers();



// Add Swagger/OpenAPI support
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

app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();
