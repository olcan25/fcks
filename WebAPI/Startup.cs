using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Core.DependencyResolvers;
using Core.Extensions;
using Core.Utilities.IoC;
using Core.Utilities.Security.Encyption;
using Core.Utilities.Security.Jwt;
using DataAccess.Concrete.EntityFramework.Context;
using LinqToDB.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Core.Utilities.CustomMiddleware;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddSingleton(Configuration);

            services.AddControllers().AddNewtonsoftJson(options => { options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore; });



            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //Net6 ile gelecek bir ozellik
            //services.AddHttpLogging(logging =>
            //{
            //    // Customize HTTP logging here.
            //    logging.LoggingFields = HttpLoggingFields.All;
            //    logging.RequestHeaders.Add("My-Request-Header");
            //    logging.ResponseHeaders.Add("My-Response-Header");
            //    logging.MediaTypeOptions.AddText("application/javascript");
            //    logging.RequestBodyLogLimit = 4096;
            //    logging.ResponseBodyLogLimit = 4096;
            //});


            var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                    };
                });



            services.AddDependencyResolvers(new ICoreModule[]
            {
                new CoreModule(),new CorsModule(),
            });
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //else
            //{
            //    app.Use(async (context, next) =>
            //    {
            //        await next();
            //        if (context.Response.StatusCode == 404 && !Path.HasExtension(context.Request.Path.Value))
            //        {
            //            context.Request.Path = "/index.html";
            //            await next();
            //        }
            //    });
            //    app.UseHsts();
            //}

       //     app.ConfigureCustomExceptionMiddleware();

            app.UseCors("AllowAll");

            app.UseHttpsRedirection();

            //app.UseHttpLogging();//Net6 ile gelecek bir ozellik

            app.UseRouting();

            //app.UseMiddleware<RequestResponseLoggingMiddleware>();//Net6 dan sonra yukardakini kullan


            app.UseAuthentication();

            app.UseAuthorization();



            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
