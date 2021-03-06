using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceStack;
using ServiceStack.Data;
using ServiceStack.DataAnnotations;
using ServiceStack.OrmLite;
using SSAuthTest2.ServiceModel.Types;

[assembly: HostingStartup(typeof(SSAuthTest2.ConfigureDb))]

namespace SSAuthTest2
{
    // Example Data Model
   

    public class ConfigureDb : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder) => builder
            .ConfigureServices((context, services) => {
                services.AddSingleton<IDbConnectionFactory>(new OrmLiteConnectionFactory(
                    context.Configuration.GetConnectionString("DefaultConnection")
                    ?? "andy.sqlite",
                    SqliteDialect.Provider));
            })
            .ConfigureAppHost(afterConfigure:appHost => {
                appHost.ScriptContext.ScriptMethods.Add(new DbScriptsAsync());

                // Create non-existing Table and add Seed Data Example
                using var db = appHost.Resolve<IDbConnectionFactory>().Open();
                if (db.CreateTableIfNotExists<MyTable>())
                {
                    db.Insert(new MyTable { FirstName = "Seed Data for new MyTable" });
                }
            });
    }
}
