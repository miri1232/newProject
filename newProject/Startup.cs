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
            services.AddScoped<IExpenseBL, ExpenseBL>();
            services.AddScoped<IExpenseDAL, ExpenseDAL>();
            services.AddScoped<IMessageBL, MessageBL>();
            services.AddScoped<IMessageDAL, MessageDAL>();
            services.AddScoped<IMessagesForUserBL, MessagesForUserBL>();
            services.AddScoped<IMessagesForUserDAL, MessagesForUserDAL>();
            services.AddScoped<INumberPaymentsBL, NumberPaymentsBL>();
            services.AddScoped<INumberPaymentsDAL, NumberPaymentsDAL>();
            services.AddScoped<IIncomeBL, IncomeBL>();
            services.AddScoped<IIncomeDAL, IncomeDAL>();
            services.AddScoped<IUserBL, UserBL>();
            services.AddScoped<IUserDAL, UserDAL>();
            services.AddScoped<ICategoryBL, CategoryBL>();
            services.AddScoped<ICategoryDAL, CategoryDAL>();
            services.AddScoped<ISubcategoryBL, SubcategoryBL>();
            services.AddScoped<ISubcategoryDAL, SubcategoryDAL>();
            services.AddScoped<ISourceOfIncomeBL, SourceOfIncomeBL>();
            services.AddScoped<ISourceOfIncomeDAL, SourceOfIncomeDAL>();
            services.AddScoped<IPermissionBL, PermissionBL>();
            services.AddScoped<IPermissionDAL, PermissionDAL>();
            services.AddScoped<ICategoryIncomeBL, CategoryIncomeBL>();
            services.AddScoped<ICategoryIncomeDAL, CategoryIncomeDAL>();
            services.AddScoped<ILookupBL, LookupBL>();
            services.AddScoped<ILookupDAL, LookupDAL>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "newProject", Version = "v1" });
            });

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", policyBuilder => policyBuilder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        );

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
