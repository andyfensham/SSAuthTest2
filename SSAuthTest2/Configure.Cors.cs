using ServiceStack;

[assembly: HostingStartup(typeof(SSAuthTest2.ConfigureCors))]

namespace SSAuthTest2
{
    public class ConfigureCors : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder) => builder
            .ConfigureAppHost(appHost => {
                appHost.Plugins.Add(new CorsFeature());
            });
    }
}