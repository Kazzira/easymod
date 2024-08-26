using Focus.Apps.EasyNpc.Data;
using Focus.Apps.EasyNpc.ModManagers;

namespace Focus.Apps.EasyNpc.Analysis;

public class ModRegistryBuilder(IModRepository modRepository)
{
    public async Task<ModRegistryData> BuildAsync()
    {
        return new() { Mods = await modRepository.GetMods().ToListAsync() };
    }
}
