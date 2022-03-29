using Microsoft.EntityFrameworkCore;
using TicTacToeAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Custom Services:

/*  
 *  These scope allows automatic mapping to Data Transfer Objects
 *  to their respective models.
*/
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

/*  
 *  These scopes allow manipulation of the Game Repository used without
 *  needing to change the lower implementation of the code. This allows
 *  more flexibility and changeability in the API.
*/
builder.Services.AddScoped<GameDatabaseContext, GameDatabaseContext>();
builder.Services.AddScoped<IGameRepository, SQLiteGameRepository>();

/*  
 *  This configuration sets up the sqlite database connection with the project
*/
IConfiguration Configuration = builder.Configuration;
IWebHostEnvironment environment = builder.Environment;

builder.Services.AddDbContext<GameDatabaseContext>(options =>
options.UseSqlite(Configuration.GetConnectionString("TicTacToeDBConnection")));

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

// Run Application
app.Run();
