// ReSharper disable MemberCanBePrivate.Global

using System;
using Exiled.API.Features;
using Exiled.API.Features.Core.UserSettings;
using Yassa.Enums;
using Yassa.Interfaces;

namespace Yassa.Models;

/// <summary>
/// Represents a button displayed in the settings menu. This class cannot be inherited.
/// </summary>
public sealed class ButtonOption : OptionBase<ButtonSetting>, IValidatable
{
    /// <summary>
    /// Initializes a new instance with default values.
    /// </summary>
    public ButtonOption() : this("", "Default string", "Default string") { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ButtonOption"/> class.
    /// </summary>
    /// <param name="customId">Custom string identifier for the option.</param>
    /// <param name="label">The text label shown left to the option.</param>
    /// <param name="text">The text on the button itself.</param>
    /// <param name="hint">Optional hint text.</param>
    /// <param name="holdTime">Hold time in seconds.</param>
    /// <param name="onClicked">Callback invoked when the button is pressed.</param>
    public ButtonOption(
        string customId,
        string label,
        string text,
        string hint = null,
        float holdTime = 0f,
        Action<Player, ButtonOption> onClicked = null)
    {
        CustomId = customId;
        Label = label;
        Hint = hint;
        Text = text;
        HoldTime = holdTime;
        OnClicked = onClicked;
    }

    /// <inheritdoc/>
    public override ButtonSetting Base { get; internal set; }

    /// <inheritdoc/>
    public override string CustomId { get; set; }

    /// <inheritdoc/>
    public override string Label { get; set; }

    /// <inheritdoc/>
    public override string Hint { get; set; }

    /// <inheritdoc/>
    public override OptionValueType ReturnableType => OptionValueType.None;

    /// <summary>
    /// Gets or sets the text displayed on the button.
    /// </summary>
    public string Text { get; set; }

    /// <summary>
    /// Gets or sets the hold time in seconds.
    /// </summary>
    public float HoldTime { get; set; }

    /// <summary>
    /// Gets or sets the callback invoked when the button is clicked.
    /// </summary>
    public Action<Player, ButtonOption> OnClicked { get; set; }

    /// <inheritdoc/>
    protected override ButtonSetting BuildBase() =>
        new(Id, Label, Text, HoldTime, Hint, onChanged: (player, _) => OnClicked?.Invoke(player, this));

    /// <inheritdoc/>
    public bool Validate() =>
        !string.IsNullOrWhiteSpace(CustomId)
        && !string.IsNullOrWhiteSpace(Label)
        && !string.IsNullOrWhiteSpace(Text)
        && HoldTime >= 0f;
}