using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Globalization;
namespace AgendaWS
{
    using AgendaWS.Domain.Models;
    using AgendaWS.Domain.Repositories;
    using AgendaWS.Domain.Services;
    using AgendaWS.Middlewares;
    using AgendaWS.Persistence.Config;
    using AgendaWS.Persistence.Repositories;
    using AgendaWS.Service;
    using AgendaWS.Validators;


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

            services.AddControllers().AddFluentValidation();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AgendaWS", Version = "v1" });
            });

            services.AddSingleton(_ => Configuration);
            services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
            services.AddDbContext<AgentaContext>(options => options.UseSqlServer(Configuration.GetConnectionString("AgendaWS")));
            AddIoCRepositories(services);
            AddIoCServices(services);
            AddIocValidations(services);
            services.AddHttpContextAccessor();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AgendaWS v1"));
            
            var supportedCultures = new[] { new CultureInfo("pt-BR") };
            app.UseRequestLocalization(new RequestLocalizationOptions()
            {
                DefaultRequestCulture = new RequestCulture(culture: "pt-BR", uiCulture: "pt-BR"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseNotOkResponseMiddleware();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void AddIoCRepositories(IServiceCollection services)
        {
            services.AddTransient<IAgendaRepository, AgendaRepository>();
        }
        private void AddIocValidations(IServiceCollection services)
        {
            services.AddTransient<IValidator<Agenda>, AgendaValidator>();
        }
        private void AddIoCServices(IServiceCollection services)
        {
            services.AddTransient<IAgendaService, AgendaService>();
        }
    }
}
