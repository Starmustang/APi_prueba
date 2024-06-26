using Api_Prueba;
using Api_Prueba.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbcontex>(opt=> opt.UseSqlite("Data Source=baseprueba.db"));

//builder.Services.AddScoped<IHelloworldService, HelloworldService>();
builder.Services.AddScoped<IHelloworldService>(p=> new HelloworldService()); //esta forma me permite agregar parametros al constructor
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<ITareaService, TareaService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();


