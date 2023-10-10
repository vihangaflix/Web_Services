using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Web_Services.Models;
using Web_Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<TicketStoreDatabaseSettings>(builder.Configuration.GetSection(nameof(TicketStoreDatabaseSettings)));
builder.Services.Configure<UserStoreDatabaseSettings>(builder.Configuration.GetSection(nameof(UserStoreDatabaseSettings)));
builder.Services.Configure<TrainStoreDatabaseSettings>(builder.Configuration.GetSection(nameof(TrainStoreDatabaseSettings)));


builder.Services.AddSingleton<ITicketStoreDatabaseSettings>(sp => sp.GetRequiredService<IOptions<TicketStoreDatabaseSettings>>().Value);
builder.Services.AddSingleton<IUserStoreDatabaseSettings>(sp => sp.GetRequiredService<IOptions<UserStoreDatabaseSettings>>().Value);
builder.Services.AddSingleton<ITrainStoreDatabaseSettings>(sp => sp.GetRequiredService<IOptions<TrainStoreDatabaseSettings>>().Value);


builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(builder.Configuration.GetValue<string>("TicketStoreDatabaseSettings:ConnectionString")));
builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(builder.Configuration.GetValue<string>("UserStoreDatabaseSettings:ConnectionString")));
builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(builder.Configuration.GetValue<string>("TrainStoreDatabaseSettings:ConnectionString")));


builder.Services.AddScoped<ITicketService, TicketService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITrainService, TrainService>();



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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();