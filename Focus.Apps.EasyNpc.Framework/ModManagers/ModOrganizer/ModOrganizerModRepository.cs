using System.Diagnostics;
using System.Text.RegularExpressions;
using Focus.Apps.EasyNpc.Data;

namespace Focus.Apps.EasyNpc.ModManagers.ModOrganizer;

public partial class ModOrganizerModRepository(string instanceDirectoryPath) : IModRepository
{
    private static readonly string REPOSITORY_LOCAL = "Local";

    private readonly Lazy<Task<ConfigIni>> configTask =
        new(
            () => ConfigIni.LoadFromFile(Path.Combine(instanceDirectoryPath, "ModOrganizer.ini")),
            true
        );

    public async Task<ModRegistryData> GetModRegistryAsync()
    {
        var config = await configTask.Value;
        var componentDirectories = Directory.GetDirectories(config.Settings.ModsDirectory);
        var modsById = new Dictionary<string, ModManifest>();
        await Parallel.ForEachAsync(
            componentDirectories,
            async (directory, cancellationToken) =>
            {
                cancellationToken.ThrowIfCancellationRequested();
                var componentPath = new DirectoryInfo(directory).Name;
                if (BackupRegex().IsMatch(componentPath) || componentPath.EndsWith("_separator"))
                {
                    return;
                }
                var metaPath = Path.Combine(directory, "meta.ini");
                var metaIni = await MetaIni.LoadFromFile(metaPath);
                var modId = metaIni.General.ModId ?? "0";
                var repository = metaIni.General.Repository ?? "";
                if (modId == "0" || modId == "-1")
                {
                    modId = componentPath;
                    repository = "";
                }
                if (string.IsNullOrEmpty(repository))
                {
                    repository = REPOSITORY_LOCAL;
                }
                var fileId = metaIni.InstalledFiles.FirstFileId;
                var component = new ModComponent()
                {
                    Key = !string.IsNullOrEmpty(fileId)
                        ? $"{repository}:{fileId}"
                        : $"{REPOSITORY_LOCAL}:{componentPath}",
                    Name = metaIni.General.InstallationFile ?? "",
                    Path = componentPath,
                };
                if (!string.IsNullOrEmpty(fileId) && repository == "Nexus")
                {
                    component.Sources.Add(
                        new() { Id = fileId, Type = ModComponentSourceType.NexusFile }
                    );
                }
                if (string.IsNullOrEmpty(fileId))
                {
                    fileId = componentPath;
                }
                lock (modsById)
                {
                    var mod = modsById.GetOrAdd(
                        modId,
                        () =>
                            new ModManifest()
                            {
                                Key = $"{repository}:{modId}",
                                // We'll try to get the "real" name from one of the Sources later, but there's
                                // no guarantee that's possible, so start with the as-installed name.
                                Name = componentPath,
                                Sources =
                                    repository == "Nexus"
                                        ?
                                        [
                                            new ModSource()
                                            {
                                                Id = modId,
                                                Type = ModSourceType.NexusMod,
                                            },
                                        ]
                                        : [],
                            }
                    );
                    mod.Components.Add(component);
                }
            }
        );
        var mods = modsById.Values.ToList();
        var componentKeysByPath = mods.SelectMany(mod => mod.Components)
            .ToDictionary(c => c.Path, c => c.Key);
        var order = await GetOrder(componentKeysByPath).ToListAsync();
        order.Reverse();
        return new() { Mods = mods, Order = order };
    }

    private async IAsyncEnumerable<ModOrderEntry> GetOrder(
        IReadOnlyDictionary<string, string> componentKeysByPath
    )
    {
        var config = await configTask.Value;
        if (string.IsNullOrEmpty(config.General.SelectedProfile))
        {
            yield break;
        }
        var modListPath = Path.Combine(
            config.Settings.ProfilesDirectory,
            config.General.SelectedProfile,
            "modlist.txt"
        );
        if (!File.Exists(modListPath))
        {
            yield break;
        }
        using var stream = File.OpenRead(modListPath);
        using var reader = new StreamReader(stream);
        string? nextLine;
        while ((nextLine = await reader.ReadLineAsync()) is not null)
        {
            bool isEnabled = nextLine.StartsWith('+');
            var componentPath = isEnabled ? nextLine[1..] : nextLine;
            if (componentKeysByPath.TryGetValue(componentPath, out var componentKey))
            {
                yield return new() { ComponentKey = componentKey, IsEnabled = isEnabled };
            }
            else
            {
                Debugger.Break();
            }
        }
    }

    [GeneratedRegex("backup[0-9]*$", RegexOptions.Compiled)]
    private static partial Regex BackupRegex();
}
