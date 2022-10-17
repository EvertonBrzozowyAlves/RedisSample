using RedisCaching.Infrastructure.Caching;
using RedisCaching.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<TodoMockRepository>();
builder.Services.AddScoped<ICachingService, CachingService>();

builder.Services.AddStackExchangeRedisCache(o =>
{
    o.InstanceName = "todo";
    o.Configuration = "localhost:6379";
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
