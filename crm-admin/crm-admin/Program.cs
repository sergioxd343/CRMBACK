using crm_admin.Models;
using crm_admin.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios al contenedor
builder.Services.AddControllers();
builder.Services.AddDbContext<AdminSoftliContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IAuthService, AuthService>();

// Agregar servicios de Swagger
builder.Services.AddEndpointsApiExplorer(); // Para explorar los puntos finales de la API
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API de CRM Admin", Version = "v1" });
});

var app = builder.Build();

// Configurar la canalización HTTP
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // Para ver detalles del error en modo desarrollo
}

// Habilitar middleware de Swagger
app.UseSwagger(); // Habilitar el middleware de Swagger
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API de CRM Admin V1"); // Configurar el endpoint de Swagger
    c.RoutePrefix = string.Empty; // Hacer que Swagger esté disponible en la raíz (http://localhost:7146/)
});

app.UseAuthorization();
app.MapControllers();
app.Run();
