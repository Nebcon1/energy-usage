using API;
using API.Models;
using API.Repository;

var LocalAllowedOrigins = "_localAllowedOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: LocalAllowedOrigins,
                      policy  =>
                      {
                          policy.WithOrigins("http://localhost:3000");
                      });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IFileParser<UsageData>, UsageFileParser>();
builder.Services.AddScoped<IFileParser<Anomaly>, AnomalyFileParser>();
builder.Services.AddScoped<IUsageDataProvider, UsageDataProvider>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(LocalAllowedOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
