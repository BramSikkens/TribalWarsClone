namespace TribalWarsCloneServer
{
    public class Startup
    {

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseEndpoints(configure => configure.MapControllers());
            
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        }
    }
}
