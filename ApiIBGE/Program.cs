using ApiIBGE.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SQLitePCL;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;

SQLitePCL.Batteries.Init();
SQLitePCL.raw.FreezeProvider();
SQLitePCL.raw.SetProvider(new SQLite3Provider_e_sqlite3());

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("IbgeConnection");

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(connectionString));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{

    c.SwaggerDoc(name: "v1", info: new OpenApiInfo
    {
        Version = "v1",
        Title = "ApiIBGE",
        Description = "API focada em apresentar dados do IBGE.",
        TermsOfService = new Uri(uriString: "https://github.com/Zezao1224/ApiIBGE")
    });

    var xmlApiPath = Path.Combine(AppContext.BaseDirectory, path2: $"{typeof(Program).Assembly.GetName().Name}.xml");

    c.IncludeXmlComments(xmlApiPath);

}
    );
builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                 .AddJwtBearer(options =>
                 {
                     options.TokenValidationParameters = new TokenValidationParameters
                     {
                         ValidateIssuer = false,
                         ValidateAudience = false,
                         ValidateLifetime = true,
                         ValidateIssuerSigningKey = true,
                         IssuerSigningKey = new SymmetricSecurityKey
                        (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
                     };
                 });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwagger();
app.UseSwaggerUI(setup =>
{
    setup.RoutePrefix = "swagger";
    setup.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "Api Documentation");
});

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
