using Focus.Apps.EasyNpc.Cli;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Sinks.Spectre;
using Spectre.Console.Cli;
using Spectre.Console.Cli.Extensions.DependencyInjection;

var logger = Log.Logger = new LoggerConfiguration()
    .WriteTo.Spectre()
    .MinimumLevel.Verbose()
    .CreateLogger();
var services = new ServiceCollection();
using var registrar = new DependencyInjectionRegistrar(services);
registrar.RegisterInstance(typeof(ILogger), logger);
var app = new CommandApp(registrar);
app.Configure(config =>
{
    config
        .AddCommand<ExplainCommand>("explain")
        .WithDescription("Provide details on how a specific NPC will be merged.")
        .WithExample("explain", "Skyrim.esm:013478")
        .WithExample("explain", "Delphine");
});
app.Run(args);
