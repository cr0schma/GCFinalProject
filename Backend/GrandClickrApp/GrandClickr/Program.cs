using GrandClickr.Services;
using GrandClickr.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<AzBlobService>();
builder.Services.AddScoped<GrandClickrContext>();

// Add Cors policy
builder.Services.AddCors(
    options =>
    {
        options.AddPolicy(
            name: "AllowAny",
            builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
            );
    }
);

// Let's add our DbContext that creates the connection to our SQL Server
builder.Services.AddDbContext<GrandClickrContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration["ConnectionStrings:GrandClickrContextConnection"]); // <----- Make sure you are using the correct connection string. See your appsettings.json
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<AzBlobService>();

builder.Services.AddCors(
    options =>
    {
        options.AddPolicy(
            name: "AllowAny",
            builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
            );
    }
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAny");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
