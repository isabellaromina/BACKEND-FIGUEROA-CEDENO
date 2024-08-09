

using Microsoft.EntityFrameworkCore;
using ProyectoFerreteria.Entidades;
using ProyectoFerreteria.Repositorio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//add Cors
builder.Services.AddCors(options => options.AddPolicy("AllowWebApp",
                                builder => builder.AllowAnyOrigin()
                                .AllowAnyHeader()
                                .AllowAnyMethod()));

// Agrega la conexion de la BD
builder.Services.AddDbContext<ApplicationDbContext>(opciones =>
    opciones.UseSqlServer("name=DefaultConnection"));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registra un servicio en el contenedor de dependencias con un tiempo de vida "scoped"
// La instancia del servicio ser� creada una vez por solicitud HTTP y
// ser� compartida en todos los lugares donde sea inyectada durante esa solicitud
builder.Services.AddScoped<IRepositorioCliente, RepositorioCliente>();
builder.Services.AddScoped<IRepositorioContactos, RepositorioContactos>();
builder.Services.AddScoped<IRepositorioSolicitudCompra, RepositorioSolicitudCompra>();
builder.Services.AddScoped<IRepositorioOrdenCompra, RepositorioOrdenCompra>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowWebApp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
