using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using OrderWritenew.Repository;
using OrderWritenew.Models;
using OrderWritenew.Commands;
using OrderWritenew.Services;
using OrderWritenew.Events;
using OrderWritenew.Infra;

namespace OrderWritenew
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
            services.AddDbContext<OrderDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("orderWriteCs")));
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<ICommandHandlers, CommandHandlers>();

            services.AddSingleton<IServiceBusSender, ServiceBusSender>(
                aa => new ServiceBusSender(
                    Configuration.GetConnectionString("serviceBusCs"), Configuration.GetValue<string>("TopicName")));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
