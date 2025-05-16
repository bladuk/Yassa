using HarmonyLib;
using UserSettings.ServerSpecific;

namespace Yassa.Patches;

[HarmonyPatch(typeof(ServerSpecificSettingsSync), nameof(ServerSpecificSettingsSync.DefinedSettings), MethodType.Setter)]
public static class DefinedSettingsUpdatedPatch
{
    private static void Prefix(ServerSpecificSettingBase[] value)
    {
        foreach (var setting in value)
        {
            Yassa.Singleton.Nonce.UsedNumbers.Add(setting.SettingId);
        }
    }
}