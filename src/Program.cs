using Blog_API.Context;
using Blog_API.Models.Enums;
using Blog_API.Repositories.Implementation;
using Blog_API.Repositories.Interfaces;
using Blog_API.Services.Implementations;
using Blog_API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BlogContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Add services to the container.

builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.MapType<EnumUser>(() => new OpenApiSchema
    {
        Type = "string",
        Enum = Enum.GetNames(typeof(EnumUser)).Select(name => new OpenApiString(name)).ToArray(),
        Default = new OpenApiString(EnumUser.Subscriber.ToString())
    });
});
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