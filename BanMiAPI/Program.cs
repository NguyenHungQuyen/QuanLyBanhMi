using BanMiAPI.Data;
using BanMiAPI.Repositories;
using BanMiAPI.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<DbContext>();
builder.Services.AddScoped<INguyenLieuRepository, NguyenLieuRepository>(); // <-- dòng mới
builder.Services.AddScoped<BanhMiRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();
app.MapControllers();
app.Run();
