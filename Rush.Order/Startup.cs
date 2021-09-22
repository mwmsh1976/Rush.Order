using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Rush.Api.Core.Client;
using Rush.Api.Core.Client.Interfaces;
using Rush.Order.Mappers;
using Rush.Order.Mappers.Interfaces;
using Rush.Order.Models;
using Rush.Order.Models.Interfaces;
using Rush.Order.Repositories;
using Rush.Order.Repositories.Interfaces;
using Rush.Order.Services;
using Rush.Order.Services.Interfaces;
using Rush.Order.Validators;
using System;
using System.Net.Http;

namespace Rush.Order
{
    public class Startup
    {
        private const string ClientFactoryName = "RushAPIClient";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            services.AddDbContext<OrderContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("OrderContext")));

            services.AddHttpClient(ClientFactoryName, client =>
            {
                client.BaseAddress = new Uri("https://api.rush.logging.com"); 
            });

            services.AddSingleton<IServiceClient, ServiceClient>(s =>
                         new ServiceClient(s.GetService<IHttpClientFactory>(), ClientFactoryName)
                         );

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Rush.Order", Version = "v1" });
            });

            services.AddTransient<StatusValidatorAttribute, StatusValidatorAttribute>();
            services.AddTransient<OrderExistsAttribute, OrderExistsAttribute>();

            services.AddTransient<IOrder, Models.Order>();
            services.AddTransient<IOrderListRequest, OrderListRequest>();
            services.AddTransient<IUpdateOrderRequest, UpdateOrderRequest>();

            services.AddTransient<Domain.Interfaces.IOrder, Domain.Order>();
            services.AddTransient<Domain.Interfaces.IOrderListRequest, Domain.OrderListRequest>();
            services.AddTransient<Domain.Interfaces.IUpdateOrderRequest, Domain.UpdateOrderRequest>();

            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IOrderMapper, OrderMapper>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Rush.Order v1"));
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
