using EventPoint.Business.Extensions;
using EventPoint.Business.Middlewares;
using EventPoint.Core.Extensions;
using EventPoint.DataAccess.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,policy =>
        {
            policy.WithOrigins("http://localhost:3002","http://localhost:3001", "http://localhost:3000");
        });
});

builder.Services.
    AddDataAccesLayer(builder.Configuration)
    .AddBusinessLayer()
    .AddAuthenticationConfig(builder.Configuration)
    .AddRedisCache(builder.Configuration);
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfig();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<GlobalErrorHandlerMiddleware>();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.UseCors(MyAllowSpecificOrigins);

app.Run();