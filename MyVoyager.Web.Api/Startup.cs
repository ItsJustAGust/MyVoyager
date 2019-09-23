using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;

namespace MyVoyager.Web.Api
{
	public class Startup
	{

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}
		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{


			services.AddMvc()

			.AddJsonOptions(options =>
			{
				options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
			}).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);


			services.AddCors(options =>
			{
				options.AddPolicy("CorsPolicy",
					builder => builder.AllowAnyOrigin()
						.AllowAnyMethod()
						.AllowAnyHeader()
						.AllowCredentials());
			});


			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new Info { Title = "Voyager API", Version = "v1" });
			});


			services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = "JwtBearer";
				options.DefaultChallengeScheme = "JwtBearer";
			}
			).AddJwtBearer("JwtBearer", options =>
			{

				options.TokenValidationParameters = new TokenValidationParameters
				{

					ValidateIssuer = true,

					ValidateAudience = true,

					ValidateLifetime = true,

					IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("voyager-chave-autenticacao")),

					ClockSkew = TimeSpan.FromMinutes(30),

					ValidIssuer = "Voyager.WebApi",

					ValidAudience = "Voyager.WebApi"
				};
			});
		}


		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseSwagger();

			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "Voyager");
			});

			app.UseAuthentication();


			app.UseCors("CorsPolicy");

			app.UseMvc();

		}
	}
}
