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

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins",
        policy =>
        {
            policy.WithOrigins("http://localhost:5000", "https://your-swagger-ui-domain.com")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

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
app.UseCors("AllowSpecificOrigins"); // Make sure this is placed before UseRouting

app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();
