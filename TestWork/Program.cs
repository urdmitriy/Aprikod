using TestWork.Data;
using TestWork.Model;
using TestWork.Model.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<GamesDbContext>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IRepositoryGames, RepositoryGames>();
builder.Services.AddScoped<IRepositoryGenre, RepositoryGenre>();
builder.Services.AddScoped<IRepositoryStudio, RepositoryStudio>();
builder.Services.AddScoped<GameManager>();
builder.Services.AddScoped<GenreManager>();

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

app.Run();