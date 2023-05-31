using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Facebook;
using System.Configuration;

namespace LoginMicroservice
{
    public class Program
    {
        static string MyAllowSpecificOrigins = "AllowAll";

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var services = builder.Services;
            var configuration = builder.Configuration;

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            services.AddAuthentication().AddFacebook(facebookOptions =>
            {
                IConfigurationSection facebookAuthNSection = configuration.GetSection("Authentication:Facebook");
                facebookOptions.AppId = facebookAuthNSection["AppId"] ?? "1079338452912062";
                facebookOptions.AppSecret = facebookAuthNSection["AppSecret"] ?? "5a7c8fc35b300adbd53559b4fe6c7297";
            }).AddCookie();
            var app = builder.Build();
            
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseCors(MyAllowSpecificOrigins);
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}