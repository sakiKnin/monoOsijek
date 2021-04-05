using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Microsoft.OpenApi.Models;
using Npgsql.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Backend.Data;

namespace Backend
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
            services.AddDbContext<ApplicationDbContext>(options =>
		{
			var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
			string connectionString;

			if(env == "Development")
			{
					connectionString = Configuration.GetConnectionString("DefaultConnection");

			}
			else
			{
					var connUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
        				// Parse connection URL to connection string for Npgsql
        				connUrl = connUrl.Replace("postgres://", string.Empty);
        				var pgUserPass = connUrl.Split("@")[0];
        				var pgHostPortDb = connUrl.Split("@")[1];
        				var pgHostPort = pgHostPortDb.Split("/")[0];
        				var pgDb = pgHostPortDb.Split("/")[1];
        				var pgUser = pgUserPass.Split(":")[0];
        				var pgPass = pgUserPass.Split(":")[1];
        				var pgHost = pgHostPort.Split(":")[0];
        				var pgPort = pgHostPort.Split(":")[1];
        				connectionString = $"Server={pgHost};Port={pgPort};User Id={pgUser};Password={pgPass};Database={pgDb};sslmode=Require;Trust Server Certificate=true";
			}
				 
					options.UseNpgsql(connectionString);
    			 
     		});
            services.AddControllers();

	    services.AddSwaggerGen(options =>
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Conference Planner API", Version = "v1" })
);
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();

	    app.UseSwaggerUI(options =>
   			 options.SwaggerEndpoint("/swagger/v1/swagger.json", "Conference Planner API v1")
		);

            app.UseEndpoints(endpoints =>
 		{
     		   endpoints.MapGet("/", context => { 
         		context.Response.Redirect("/swagger/");
         		return Task.CompletedTask;
     			});
     		   endpoints.MapControllers();
 		});
        }
    }
}
