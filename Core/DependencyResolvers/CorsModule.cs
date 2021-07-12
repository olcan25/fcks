using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DependencyResolvers
{
    public class CorsModule : ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("Angular",
                    builder => builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod());
                options.AddPolicy("Flutter",
                    builder => builder.WithOrigins("http://localhost:40958").AllowAnyHeader().AllowAnyMethod());
                options.AddPolicy("AllowAll",
                    builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
        }
    }
}
