using Amazon.Lambda.Annotations;
using ApiPelisAWSAnita.Data;
using ApiPelisAWSAnita.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApiPelisAWSAnita;

[LambdaStartup]
public class Startup
{
    
    public void ConfigureServices(IServiceCollection services)
    {
        var builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json", true);

        var configuration = builder.Build();
        services.AddSingleton<IConfiguration>(configuration);

        services.AddTransient<RepositoryPelis>();
        string connectionString =
            configuration.GetConnectionString("MySql");
        services.AddDbContext<PelisContext>
            (options => options.UseMySql(connectionString
            , ServerVersion.AutoDetect(connectionString)));
    }
}

