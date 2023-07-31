using TariffComparison.API.Services;
using TariffComparison.Data.Mock;
using TariffComparison.Domain;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IExternalTariffProvider, MockExternalTariffProvider>();
builder.Services.AddSingleton<TariffCalculatorFactory>();
builder.Services.AddScoped<TariffService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(policy =>
    policy.WithOrigins(builder.Configuration["WEB_APP_ORIGIN"]!)
    .AllowAnyMethod()
    .AllowAnyHeader());

app.MapControllers();

app.Run();
