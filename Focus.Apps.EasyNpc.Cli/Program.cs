using Focus.Apps.EasyNpc.Cli;
using Focus.Apps.EasyNpc.Cli.Commands;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Sinks.Spectre;
using Spectre.Console;
using Spectre.Console.Cli;
using Spectre.Console.Cli.Extensions.DependencyInjection;

var logger = Log.Logger = new LoggerConfiguration()
    .WriteTo.Spectre()
    .MinimumLevel.Verbose()
    .CreateLogger();
var services = new ServiceCollection();
using var registrar = new DependencyInjectionRegistrar(services);
registrar.RegisterInstance(typeof(ILogger), logger);
registrar.RegisterInstance(
    typeof(ProfileSelector),
    new ProfileSelector(AnsiConsole.Console, Environment.SpecialFolder.LocalApplicationData, logger)
);
var app = new CommandApp(registrar);
app.Configure(config =>
{
    config
        .AddCommand<ExplainCommand>("explain")
        .WithDescription("Provide details on how a specific NPC will be merged.")
        .WithExample("explain", "Skyrim.esm:013478")
        .WithExample("explain", "Delphine");
    config
        .AddCommand<ScanCommand>("scan")
        .WithDescription("Re-scan the mod directory and update mod information.")
        .WithExample("scan");
});
app.Run(args);
