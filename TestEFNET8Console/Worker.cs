using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Solr.Engine.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

public class Worker : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;

    public Worker(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var scope = _serviceProvider.CreateScope();
        var service = scope.ServiceProvider.GetRequiredService<SolrVoiceCommandService>();

        var commands = await service.GetVoiceCommandsAsync();
        foreach (var command in commands)
        {
            Console.WriteLine($"Command: {command.key}");
        }
    }
}
