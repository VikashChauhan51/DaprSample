
var builder = WebApplication.CreateBuilder(args);

var daprConfiguration = new DaprConfiguration();
builder.Configuration.GetSection(Constants.DaprConfig).Bind(daprConfiguration);
// Add services to the container.

builder.Services.AddSingleton(daprConfiguration);
builder.Services.AddControllers().AddDapr();
builder.Services.AddHealthChecks().AddCheck("self", () => HealthCheckResult.Healthy("A healthy result."));
 
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// k8s health check
app.MapHealthChecks("/healthz/startup");
app.MapHealthChecks("/healthz");
app.MapHealthChecks("/ready");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// Disabled the HTTPS redirect
//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
