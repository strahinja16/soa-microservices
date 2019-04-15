using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ApiMicroservice.DbContexts;
using ApiMicroservice.Repository;
using ApiMicroservice.Repository.Interfaces;
using ApiMicroservice.Services;
using ApiMicroservice.Services.DataService;

namespace ApiMicroservice
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddHostedService<BackgroundService>();
            services.AddDbContext<AppDbContext>(o => o.UseSqlServer(Configuration.GetConnectionString("SqlServer")));
            services.AddHttpClient();

            services.AddTransient<IApplicationRepository, ApplicationRepository>();
            services.AddTransient<IBluetoothRepository, BluetoothRepository>();
            services.AddTransient<ICallRepository, CallRepository>();
            services.AddTransient<ILocationRepository, LocationRepository>();
            services.AddTransient<ISMSRepository, SMSRepository>();
            services.AddTransient<IWifiRepository, WifiRepository>();

            services.AddScoped<ApplicationDataService>();
            services.AddScoped<BluetoothDataService>();
            services.AddScoped<CallDataService>();
            services.AddScoped<LocationDataService>();
            services.AddScoped<SMSDataService>();
            services.AddScoped<WiFiDataService>();
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
