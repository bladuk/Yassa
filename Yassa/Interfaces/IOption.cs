using Exiled.API.Features.Core.UserSettings;
using Yassa.Enums;

namespace Yassa.Interfaces;

/// <summary>
/// Common abstraction for every option that can appear in a settings menu.
/// </summary>
public interface IOption
{
    /// <summary>
    /// Custom unique identifier that can be used to reference the option at runtime.
    /// </summary>
    string CustomId { get; set; }

    /// <summary>
    /// Gets or sets the numeric identifier used by the game code.
    /// </summary>
    int Id { get; set; }

    /// <summary>
    /// Gets or sets the human-readable label shown in the menu.
    /// </summary>
    string Label { get; set; }

    /// <summary>
    /// Gets or sets an optional hint text.
    /// </summary>
    string Hint { get; set; }

    /// <summary>
    /// Gets the data type that this option returns when read.
    /// </summary>
    OptionValueType ReturnableType { get; }

    /// <summary>
    /// Converts the strongly-typed option into an EXILED <see cref="SettingBase"/>.
    /// </summary>
    SettingBase ToBase();
}