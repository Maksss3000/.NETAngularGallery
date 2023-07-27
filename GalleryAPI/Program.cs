using GalleryAPI.Core;
using GalleryAPI.Core.Repositories;
using GalleryAPI.Data;
using GalleryAPI.SignalR;

var builder = WebApplication.CreateBuilder(args);
IConfiguration config = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Adding signalR service.
builder.Services.AddSignalR();

//Registering our Repository.
builder.Services.AddScoped<IPictureRepository,PictureRepository>();

//Adding CORS permission for Client side.
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder
            .WithOrigins(config["CORS:Frontend"])
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//By First Running we initialize our Hardcoded Picture Gallery.
//Of course in Real Life Scenario we was using Database.
PictureManager.GeneratePictureGallery();

//Our SignalR
app.MapHub<ChatHub>("/chat");

app.Run();
