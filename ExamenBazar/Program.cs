using Microsoft.EntityFrameworkCore;
using ExamenBazar.Data;
using ExamenBazar.Services;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "_myAllowSpecificOrigins",
                    builder =>
                    {
                        builder.AllowAnyOrigin();
                        builder.AllowAnyHeader();
                        builder.AllowAnyMethod();
                    });
});


// Add services to the container.
builder.Services.AddDbContext<BazarDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<ProductService>();
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


app.UseDefaultFiles();  // Esto busca automáticamente index.html u otros archivos predeterminados
app.UseStaticFiles();   // Esto permite servir archivos estáticos desde wwwroot



app.UseHttpsRedirection();

app.UseCors("_myAllowSpecificOrigins");

app.UseAuthorization();

app.MapControllers();

app.Run();
