using FastShop.Business;
using FastShop.Business.MapperProfile;
using FastShop.DataAccess;
using FastShop.DataAccess.Data;
using FastShop.DataAccess.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastShop.API
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FastShop.API", Version = "v1" });
            });

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, EfProductRepository>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICategoryRepository, EfCategoryRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, EfUserRepository>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<ICommentRepository, EfCommentRepository>();

            var connectionString = Configuration.GetConnectionString("SqlDb");
            services.AddDbContext<FastShopDbContext>(opt =>opt.UseSqlServer(connectionString));
            services.AddAutoMapper(typeof(MapProfile));


            services.AddCors(opt => opt.AddPolicy("Allow", builder =>
             {
                 builder.AllowAnyOrigin();
                 builder.AllowAnyMethod();
                 builder.AllowAnyHeader();
             }));

            services.AddMemoryCache();  
            services.AddResponseCaching();
            //services.AddDistributedSqlServerCache(options =>
            //{
            //    options.ConnectionString =
            //        _config["DistCache_ConnectionString"];
            //    options.SchemaName = "dbo";
            //    options.TableName = "TestCache";
            //});

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Sisteme giriþ yapacaðýnýz key alanýdýr."));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateActor = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,

                    ValidIssuer = "fastShop.com.tr",
                    ValidAudience = "fastShop.com.tr",
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = key

                };
            });

            

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FastShop.API v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("Allow");
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
