using SampleAPI;
using SampleAPI.Configurations;

var builder = WebApplication.CreateBuilder(args);

var daprConfiguration = new DaprConfiguration();
builder.Configuration.GetSection(Constants.DaprConfig).Bind(daprConfiguration);
// Add services to the container.

builder.Services.AddSingleton(daprConfiguration);
builder.Services.AddControllers();
builder.Services.AddDaprClient();
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
