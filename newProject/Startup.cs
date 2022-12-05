using BL;
using DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;
using AutoMapper;

namespace newProject
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

           //  services.AutoMapper(typeof(Startup));
            services.AddAutoMapper(typeof(Startup));

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", policyBuilder =>
                policyBuilder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        //.AllowCredentials()
                        );
            });
        

            services.AddScoped<IBudgetBL, BudgetBL>();
            services.AddScoped<IBudgetDAL, BudgetDAL>();
            services.AddScoped<IExpensesBL, ExpensesBL>();
            services.AddScoped<IExpensesDAL, ExpensesDAL>();
            services.AddScoped<IMessagesBL, MessagesBL>();
            services.AddScoped<IMessagesDAL, MessagesDAL>();
            services.AddScoped<IMessagesForUserBL, MessagesForUserBL>();
            services.AddScoped<IMessagesForUserDAL, MessagesForUserDAL>();
            services.AddScoped<INumberPaymentsBL, NumberPaymentsBL>();
            services.AddScoped<INumberPaymentsDAL, NumberPaymentsDAL>();
            services.AddScoped<IIncomesBL, IncomesBL>();
            services.AddScoped<IIncomesDAL, IncomesDAL>();
            services.AddScoped<IUsersBL, UsersBL>();
            services.AddScoped<IUsersDAL, UsersDAL>();
            //  services.AddScoped<ILookupBL, LookupBL>();
            //  services.AddScoped<ILookupDAL, LookupDAL>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "newProject", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "newProject.API v1"));

            }

            app.UseCors("CorsPolicy");

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
