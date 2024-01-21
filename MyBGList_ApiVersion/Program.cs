using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(cfg =>
    {
        cfg.WithOrigins(builder.Configuration["AllowedOrigins"]);
        cfg.AllowAnyHeader();
        cfg.AllowAnyMethod();
    });
    options.AddPolicy(name: "AnyOrigin",
        cfg =>
        {
            cfg.AllowAnyOrigin();
            cfg.AllowAnyHeader();
            cfg.AllowAnyMethod();
        });
});

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1",
        new OpenApiInfo { Title = "MyBGList", Version = "v1.0" });
    options.SwaggerDoc("v2",
        new OpenApiInfo { Title = "MyBGList", Version = "v2.0" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    //app.UseSwaggerUI();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint(
            $"/swagger/v1/swagger.json",
            $"MyBGList v1");
        options.SwaggerEndpoint(
            $"/swagger/v2/swagger.json",
            $"MyBGList v2");
    });

}
else
{
    app.UseExceptionHandler("/error"); 
}



//app.MapGet("/error",                    //Minimal API
//    [EnableCors("AnyOrigin")]
//    [ResponseCache(NoStore = true)] () =>  //Caching Header
//    Results.Problem());

//app.MapGet("/error/test",
//    [EnableCors("AnyOrigin")] 
//    [ResponseCache(NoStore = true)] () =>
//    { throw new Exception("test"); });

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapGet("/error", () => Results.Problem()); //Routing error with minimal API

app.MapControllers();

app.Run();
