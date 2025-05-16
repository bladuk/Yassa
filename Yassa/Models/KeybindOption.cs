// ReSharper disable MemberCanBePrivate.Global

using System;
using Exiled.API.Features;
using Exiled.API.Features.Core.UserSettings;
using UnityEngine;
using Yassa.Enums;
using Yassa.Interfaces;

namespace Yassa.Models;

/// <summary>
/// Represents a keybind option in the settings menu. This class cannot be inherited.
/// </summary>
public sealed class KeybindOption : OptionBase<KeybindSetting>, IValidatable
{
    /// <summary>
    /// Initializes a new instance with default values.
    /// </summary>
    public KeybindOption() : this("", "Default string", KeyCode.None) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="KeybindOption"/> class.
    /// </summary>
    /// <param name="customId">Custom string identifier for the option.</param>
    /// <param name="label">The text label shown left to the option.</param>
    /// <param name="suggestedKey">Key suggested to the player by default.</param>
    /// <param name="hint">Optional hint text.</param>
    /// <param name="isInteractionPreventedOnGui">If <see langword="true"/>, prevents interaction when another GUI (Settings, RA, etc.) is open.</param>
    /// <param name="onPressed">Callback invoked when the bound key is pressed.</param>
    public KeybindOption(
        string customId,
        string label,
        KeyCode suggestedKey,
        string hint = null,
        bool isInteractionPreventedOnGui = false,
        Action<Player, KeybindOption> onPressed = null)
    {
        CustomId = customId;
        Label = label;
        Hint = hint;
        SuggestedKey = suggestedKey;
        IsInteractionPreventedOnGui = isInteractionPreventedOnGui;
        OnPressed = onPressed;
    }

    /// <inheritdoc/>
    public override KeybindSetting Base { get; internal set; }

    /// <inheritdoc/>
    public override string CustomId { get; set; }

    /// <inheritdoc/>
    public override string Label { get; set; }

    /// <inheritdoc/>
    public override string Hint { get; set; }

    /// <inheritdoc/>
    public override OptionValueType ReturnableType => OptionValueType.None;

    /// <summary>
    /// Gets or sets the key that is suggested to player by default.
    /// </summary>
    public KeyCode SuggestedKey { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether interaction is blocked when the GUI is open.
    /// </summary>
    public bool IsInteractionPreventedOnGui { get; set; }

    /// <summary>
    /// Gets or sets the callback invoked when the key is pressed.
    /// </summary>
    public Action<Player, KeybindOption> OnPressed { get; set; }

    /// <inheritdoc/>
    protected override KeybindSetting BuildBase() =>
        new(Id, Label, SuggestedKey, IsInteractionPreventedOnGui, Hint, onChanged: (player, _) => OnPressed?.Invoke(player, this));

    /// <inheritdoc/>
    public bool Validate() =>
        !string.IsNullOrWhiteSpace(CustomId)
        && !string.IsNullOrWhiteSpace(Label);
}