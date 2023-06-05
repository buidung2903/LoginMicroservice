using LoginMicroservice.Services.Interfaces;
using LoginMicroservice.Services.Services;
using LoginMicroservice.Helpers.Config;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.OpenApi.Models;
using System.Configuration;

namespace LoginMicroservice
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var services = builder.Services;
            var configuration = builder.Configuration;

            // Add services to the container.
            builder.Services.Configure<FacebookConfig>(builder.Configuration.GetSection("Facebook"));
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            services.AddSingleton<IAuthService, AuthService>();
            services.AddCors(o => o.AddPolicy("AllowAnyOrigin", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            var app = builder.Build();
            
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseAuthorization();
            // IMPORTANT: Make sure UseCors() is called BEFORE this
            app.UseCors("AllowAnyOrigin");
            app.UseCors(options => options.AllowAnyOrigin());
            app.MapControllers();

            app.Run();
        }
    }
}