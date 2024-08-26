using Focus.Apps.EasyNpc.Analysis;
using Focus.Apps.EasyNpc.ModManagers.ModOrganizer;
using Newtonsoft.Json;
using Serilog;
using Spectre.Console;
using Spectre.Console.Cli;
using Spectre.Console.Json;

namespace Focus.Apps.EasyNpc.Cli.Commands;

public class ScanCommand(IAnsiConsole console, ProfileSelector profileSelector, ILogger logger)
    : AsyncCommand<ScanCommand.Settings>
{
    public class Settings : CommonSettings { }

    public override async Task<int> ExecuteAsync(CommandContext context, Settings settings)
    {
        await profileSelector.ScanAsync(settings.ProfileName);
        var profile = profileSelector.ActiveProfile;
        if (profile is null)
        {
            logger.Fatal("No profile selected; exiting.");
            return -1;
        }
        return await console
            .Status()
            .AutoRefresh(true)
            .Spinner(Spinner.Known.Dots)
            .StartAsync(
                "Scanning mods...",
                async ctx =>
                {
                    logger.Information(
                        "Starting search of mod directory: {ModDirectory}",
                        profile.ModDirectoryPath
                    );
                    var modRepository = new ModOrganizerModRepository(profile.ModDirectoryPath);
                    var registryBuilder = new ModRegistryBuilder(modRepository);
                    var registryData = await registryBuilder.BuildAsync();
                    logger.Information("Mod indexing completed.");
                    var json = JsonConvert.SerializeObject(registryData);
                    console.Write(
                        new Panel(new JsonText(json)).Header("Available Mods").Collapse()
                    );
                    return 0;
                }
            );
    }
}
