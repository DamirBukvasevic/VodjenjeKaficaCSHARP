using VodjenjeKaficaCSHARP.Data;
using Microsoft.EntityFrameworkCore;
using VodjenjeKaficaCSHARP.Mapping;
using VodjenjeKaficaCSHARP.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddVodjenjeKaficaCSHARPSwaggerGen();
builder.Services.AddVodjenjeKaficaCORS();

//dodavanje baze podataka
builder.Services.AddDbContext<VodjenjeKaficaContext>(
    opcije =>
    {
        opcije.UseSqlServer(builder.Configuration.GetConnectionString("VodjenjeKaficaContext"));
    }
    );
builder.Services.AddCors(opcije =>
{
    opcije.AddPolicy("CorsPolicy",
        builder =>
            builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
    );

});

//automapper
builder.Services.AddAutoMapper(typeof(VodjenjeKaficaMappingProfile));

// SECURITY
builder.Services.AddVodjenjeKaficaSecurity();
builder.Services.AddAuthorization();
// END SECURITY

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI(opcije =>
    {
        opcije.ConfigObject.AdditionalItems.Add("requestSnippetsEnabled", true);
        opcije.EnableTryItOutByDefault();
    });
//}

app.UseHttpsRedirection();

// SECURITY
app.UseAuthentication();
app.UseAuthorization();
// ENDSECURITY

app.MapControllers();

// za potrebe produkcije
app.UseStaticFiles();
app.UseDefaultFiles();
app.MapFallbackToFile("index.html");

app.UseCors("CorsPolicy");
// zavr�io za potrebe produkcije

app.Run();
