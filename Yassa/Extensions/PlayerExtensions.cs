using Exiled.API.Features;
using Yassa.Features;

namespace Yassa.Extensions;

/// <summary>
/// Represents a set of extensions for <see cref="Player"/>. This class cannot be inherited.
/// </summary>
public static class PlayerExtensions
{
    /// <inheritdoc cref="OptionsService.GetStringValue"/>
    public static string GetStringValue(this Player player, string customId) =>
        OptionsService.GetStringValue(player, customId);
    
    /// <inheritdoc cref="OptionsService.GetNumberValue"/>
    public static float GetNumberValue(this Player player, string customId) =>
        OptionsService.GetNumberValue(player, customId);
    
    /// <inheritdoc cref="OptionsService.GetNumberValue"/>
    public static bool GetBooleanValue(this Player player, string customId) =>
        OptionsService.GetBooleanValue(player, customId);
}