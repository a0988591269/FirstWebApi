using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstWebApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;

namespace FirstWebApi
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
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                //將Json格式轉字首大寫，且空值不回傳
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                    options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                });

            //連結資料庫(appsettings.json設定)
            services.AddDbContext<PaymentDetailContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DevConnection")));

            //訊息視窗
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors(options =>
            options.WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader());

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
