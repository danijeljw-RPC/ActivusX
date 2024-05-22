using System.Reflection;
using System.Text.Json.Serialization;
using ActivusX.API.Data;
using ActivusX.API.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace ActivusX.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.Configure<ApiKeySettings>(builder.Configuration.GetSection("ApiKeySettings"));

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(connectionString));

            builder.Services.AddControllers();
            builder.Services.ConfigureHttpJsonOptions(options =>
            {
                options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
            });

            // Add Swagger services
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ActivusX API", Version = "v1" });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ActivusX API V1");
                    c.RoutePrefix = string.Empty; // This will make Swagger UI available at the root URL
                });
            }

            //app.UseHttpsRedirection();
            app.UseMiddleware<ApiKeyMiddleware>(); // Add the API key middleware here
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }

    [JsonSerializable(typeof(object[]))]
    internal partial class AppJsonSerializerContext : JsonSerializerContext
    {
    }
}
