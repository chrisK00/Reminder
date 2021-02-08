using Coravel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Reminder.api.Data;
using Reminder.api.Invocables;
using Reminder.api.Models;
using Reminder.api.Repositories;
using Reminder.api.Services;
using Serilog;

namespace Reminder.api
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
            services.AddSingleton(Log.Logger);
            services.AddTransient<CheckReminders>();
            services.AddSingleton<MailService>();
            services.AddScheduler();
            services.AddTransient<IReminderRepository, ReminderRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.Configure<MailSettings>(Configuration.GetSection(nameof(MailSettings)));

            services.AddDbContext<DataContext>(options => options.UseSqlite(
                Configuration.GetConnectionString("Default")));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Reminder.api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Reminder.api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            var provider = app.ApplicationServices;
            provider.UseScheduler(scheduler =>
          scheduler
          .Schedule<CheckReminders>()
          .EveryFiveSeconds()
        );

        }
    }
}