using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace VodjenjeKaficaCSHARP.Extensions
{
    public static class VodjenjeKaficaExtensions
    {

        public static void AddVodjenjeKaficaCORS(this IServiceCollection Services)
        {
            // Svi se od svuda na sve moguće načine mogu spojitina naš API
            // Čitati https://code-maze.com/aspnetcore-webapi-best-practices/

            Services.AddCors(opcije =>
            {
                opcije.AddPolicy("CorsPolicy",
                    builder =>
                        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
                );

            });

        }

        public static void AddVodjenjeKaficaSecurity(this IServiceCollection Services)
        {
            // https://www.youtube.com/watch?v=mgeuh8k3I4g&ab_channel=NickChapsas
            Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MojKljucKojijeJakoTajan i dovoljno dugačak da se može koristiti")),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = false
                };
            });

        }

    }
}
