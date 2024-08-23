using System.ComponentModel;
using Focus.Apps.EasyNpc.Data;
using Spectre.Console;
using Spectre.Console.Cli;
using VYaml.Serialization;

namespace Focus.Apps.EasyNpc.Cli;

public class ExplainCommand : AsyncCommand<ExplainCommand.Settings>
{
    public class Settings : CommonSettings
    {
        [CommandArgument(0, "<npc>")]
        [Description(
            "The NPC ID, as either a form key (\"Skyrim.esm:013478\") or Editor ID (\"Delphine\")."
        )]
        public required string NpcId { get; set; }
    }

    public override async Task<int> ExecuteAsync(CommandContext context, Settings settings)
    {
        using var fs = File.OpenRead(
            Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "EasyNPC",
                "profiles",
                "SkyrimSE.yaml"
            )
        );
        var profile = await YamlSerializer.DeserializeAsync<ProfileData>(fs);
        AnsiConsole.MarkupLine($"NPC ID: {settings.NpcId}");
        return 0;
    }
}
