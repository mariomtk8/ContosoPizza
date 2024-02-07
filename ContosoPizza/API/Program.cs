using ContosoPizza.Services;
using ContosoPizza.Data;
using ContosoPizza.Controllers;
using TetePizza.Data;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("ServerDB");
builder.Services.AddScoped<IPizzaData,PizzaSqlData>(serviceProvider =>
new PizzaSqlData(connectionString));

builder.Services.AddScoped<PedidoController>();
builder.Services.AddScoped<PedidoService>();
builder.Services.AddScoped<IPedidosData, PedidosSqlData>(serviceProvider =>
new PedidosSqlData(connectionString));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// builder.Services.AddScoped<PedidoController>();
// builder.Services.AddScoped <PedidoService>();
// builder.Services.AddSingleton<IPedidosData, PedidoData>();

builder.Services.AddScoped<PizzaController>();
builder.Services.AddScoped< PizzaService>();

builder.Services.AddScoped<UsuarioController>();
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddSingleton<IUsuariosData, UsuariosData>();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

//app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();