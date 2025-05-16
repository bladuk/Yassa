// ReSharper disable MemberCanBePrivate.Global

using System;
using System.Collections.Generic;
using Exiled.API.Features;
using Exiled.API.Features.Core.UserSettings;
using UserSettings.ServerSpecific;
using Yassa.Enums;
using Yassa.Interfaces;

namespace Yassa.Models;

/// <summary>
/// Represents a dropdown list option in the settings menu. This class cannot be inherited.
/// </summary>
public sealed class DropdownOption : OptionBase<DropdownSetting>, IValidatable, IValueReceiver
{
    /// <summary>
    /// Initializes a new instance with default values.
    /// </summary>
    public DropdownOption() : this("", "Default string") { }

    /// <summary>
    /// Initializes a new instance of the <see cref="DropdownOption"/> class.
    /// </summary>
    /// <param name="customId">Custom string identifier for the option.</param>
    /// <param name="label">The text label shown left to the option.</param>
    /// <param name="hint">Optional hint text.</param>
    /// <param name="defaultOptionIndex">Zero-based index of the initially selected entry.</param>
    /// <param name="entryType">Type of the dropdown entry.</param>
    /// <param name="onChanged">Callback executed when the player changes the selection.</param>
    public DropdownOption(
        string customId,
        string label,
        string hint = null,
        int defaultOptionIndex = 0,
        SSDropdownSetting.DropdownEntryType entryType = SSDropdownSetting.DropdownEntryType.Regular,
        Action<Player, SettingBase> onChanged = null)
    {
        CustomId = customId;
        Label = label;
        Hint = hint;
        DefaultOptionIndex = defaultOptionIndex;
        EntryType = entryType;
        OnChanged = onChanged;
    }

    /// <inheritdoc/>
    public override DropdownSetting Base { get; internal set; }

    /// <inheritdoc/>
    public override string CustomId { get; set; }

    /// <inheritdoc/>
    public override string Label { get; set; }

    /// <inheritdoc/>
    public override string Hint { get; set; }

    /// <inheritdoc/>
    public override OptionValueType ReturnableType => OptionValueType.String;

    /// <summary>
    /// Gets or sets the list of selectable options shown in the dropdown.
    /// </summary>
    public List<string> Options { get; set; } = new();

    /// <summary>
    /// Gets or sets the zero-based index of the option that is selected by default.
    /// </summary>
    public int DefaultOptionIndex { get; set; }

    /// <summary>
    /// Gets or sets the entries type.
    /// </summary>
    public SSDropdownSetting.DropdownEntryType EntryType { get; set; }

    /// <summary>
    /// Gets or sets the callback invoked when the player changes the selection.
    /// </summary>
    public Action<Player, SettingBase> OnChanged { get; set; }

    /// <inheritdoc/>
    public Action<Player, IOption> OnValueReceived { get; set; }

    /// <inheritdoc/>
    protected override DropdownSetting BuildBase() =>
        new(Id, Label, Options, DefaultOptionIndex, EntryType, Hint, null, OnChanged);

    /// <inheritdoc/>
    public bool Validate() =>
        !string.IsNullOrWhiteSpace(CustomId)
        && !string.IsNullOrWhiteSpace(Label)
        && Options.Count > 0
        && DefaultOptionIndex >= 0
        && DefaultOptionIndex < Options.Count;
}