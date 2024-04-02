using GettingStartedWithConfigurationConcepts;
using GettingStartedWithConfigurationConcepts.Helpers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

#region Using Named Options with IOptionsSnapshot and IOptionsMonitor
builder.Services.Configure<ExternalServicesConfiguration>(Constants.WeatherApi, builder.Configuration.GetSection("ExternalServices:WeatherApi"));
builder.Services.Configure<ExternalServicesConfiguration>(Constants.ProductsApi, builder.Configuration.GetSection("ExternalServices:ProductsApi"));

#endregion

#region Validate Options Using Data Annotations
builder.Services.AddOptions<AppSettings>()
    .Bind(builder.Configuration.GetSection("AppSettings"))
    .ValidateDataAnnotations();
#endregion

builder.Services.AddHttpClient();

#region Implemented ValidationOptionsBackgroundService To Handle Our Validation Options
builder.Services.AddHostedService<ValidationOptionsBackgroundService>();
#endregion


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
