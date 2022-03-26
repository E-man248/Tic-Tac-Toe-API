using TicTacToeAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Custom Services:

/*  
 *  This scope allows for manipulation of the Game Repository used without
 *  needing to change the lower implementation of the code. This allows
 *  more flexibility and changeability in the API.
*/
builder.Services.AddScoped<IGameRepository, DefaultGameRepository>();

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
