using ServiceStack;
using ServiceStack.Redis;

[assembly: HostingStartup(typeof(SSAuthTest2.ConfigureRedis))]

namespace SSAuthTest2
{
    public class ConfigureRedis : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder) => builder
            .ConfigureServices((context, services) => {
                services.AddSingleton<IRedisClientsManager>(
                    new RedisManagerPool(context.Configuration.GetConnectionString("Redis") ?? "localhost:6379"));
            })
            .ConfigureAppHost(afterConfigure:appHost => {
                appHost.ScriptContext.ScriptMethods.Add(new RedisScripts());
            });
    }
}