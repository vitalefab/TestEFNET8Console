using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Solr.Engine.Data;
using Solr.Engine.Services;

var builder = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        // Configurazione della stringa di connessione dal file appsettings.json
        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        string connectionString = configuration.GetConnectionString("SqlConnection");

        services.AddDbContext<EngineDbContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddScoped<SolrVoiceCommandService>();

        services.AddHostedService<Worker>(); // Un esempio di background worker
    })
    .Build();

await builder.RunAsync();
