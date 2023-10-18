using ApiIBGE.Data;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

SQLitePCL.Batteries.Init();
SQLitePCL.raw.FreezeProvider();
SQLitePCL.raw.SetProvider(new SQLite3Provider_e_sqlite3());

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("IbgeConnection");

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(connectionString));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>();

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
