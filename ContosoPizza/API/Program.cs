using ContosoPizza.Services;
using ContosoPizza.Data;
using ContosoPizza.Models;
using ContosoPizza.Controllers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var isRunningInDocker = Environment.GetEnvironmentVariable("DOCKER_CONTAINER") == "true";
var keyString = isRunningInDocker ? "ServerDB_Docker" : "ServerDB_Local";
var connectionString = builder.Configuration.GetConnectionString(keyString);

builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ContosoPizzaAppContext>(options =>
    options.UseSqlServer(connectionString));

//Pedidos
builder.Services.AddScoped<PedidosService>();
builder.Services.AddScoped<IPedidosData, PedidosEfrData>();

//Ingredientes
builder.Services.AddScoped<IngredientesService>();
builder.Services.AddScoped<IIngredientesData, IngredientesEfrData>();
//Pizza
builder.Services.AddScoped<PizzaService>();
builder.Services.AddScoped<IPizzaData, PizzaEfrData>();


var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
//app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();


        //SQL CONECTION

// var connectionString = builder.Configuration.GetConnectionString("ServerDB");
// builder.Services.AddScoped<IPizzaData,PizzaSqlData>(serviceProvider =>
// new PizzaSqlData(connectionString));

// builder.Services.AddScoped<PedidoController>();
// builder.Services.AddScoped<PedidoService>();
// builder.Services.AddScoped<IPedidosData, PedidosSqlData>(serviceProvider =>
// new PedidosSqlData(connectionString));

// builder.Services.AddControllers();

// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();


// builder.Services.AddScoped<PedidoController>();
// builder.Services.AddScoped <PedidoService>();
// builder.Services.AddSingleton<IPedidosData, PedidoData>();

// builder.Services.AddScoped<PizzaController>();
// builder.Services.AddScoped< PizzaService>();

// builder.Services.AddScoped<UsuarioController>();
// builder.Services.AddScoped<UsuarioService>();
// builder.Services.AddSingleton<IUsuariosData, UsuariosData>();


// var app = builder.Build();

// app.UseSwagger();
// app.UseSwaggerUI();

// //app.UseHttpsRedirection();
// app.UseAuthorization();

// app.MapControllers();

// app.Run();