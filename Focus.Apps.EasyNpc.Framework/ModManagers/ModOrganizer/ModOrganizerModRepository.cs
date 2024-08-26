using System.Text.RegularExpressions;
using Focus.Apps.EasyNpc.Data;

namespace Focus.Apps.EasyNpc.ModManagers.ModOrganizer;

public partial class ModOrganizerModRepository(string directoryPath) : IModRepository
{
    private static readonly string REPOSITORY_LOCAL = "Local";

    private readonly string directoryPath = directoryPath;

    public async IAsyncEnumerable<ModManifest> GetMods()
    {
        var componentDirectories = Directory.GetDirectories(directoryPath);
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
        foreach (var mod in modsById.Values)
        {
            yield return mod;
        }
    }

    [GeneratedRegex("backup[0-9]*$", RegexOptions.Compiled)]
    private static partial Regex BackupRegex();
}
