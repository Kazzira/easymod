using Focus.Apps.EasyNpc.Cli;
using Spectre.Console.Cli;

var app = new CommandApp();
app.Configure(config =>
{
    config
        .AddCommand<ExplainCommand>("explain")
        .WithDescription("Provide details on how a specific NPC will be merged.")
        .WithExample("explain", "Skyrim.esm:013478")
        .WithExample("explain", "Delphine");
});
app.Run(args);
