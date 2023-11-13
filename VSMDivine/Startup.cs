using Serilog;
using VSMDivine.Infrastructure;

namespace VSMDivine
{
    public class Startup
    {
        string CORSOpenPolicy = "OpenCORSPolicy";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(
                  name: CORSOpenPolicy,
                  builder =>
                  {
                      builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                  });
            });
            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = null;
                });

            services.RegisterServices();
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseSerilogRequestLogging();

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(CORSOpenPolicy);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
