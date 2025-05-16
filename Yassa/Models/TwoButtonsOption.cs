// ReSharper disable MemberCanBePrivate.Global

using System;
using Exiled.API.Features;
using Exiled.API.Features.Core.UserSettings;
using Yassa.Enums;
using Yassa.Interfaces;

namespace Yassa.Models;

/// <summary>
/// Represents a control with two mutually-exclusive buttons in the settings menu. This class cannot be inherited.
/// </summary>
public sealed class TwoButtonsOption : OptionBase<TwoButtonsSetting>, IValidatable, IValueReceiver
{
    /// <summary>
    /// Initialises a new instance with default values.
    /// </summary>
    public TwoButtonsOption() : this("", "Default string", "Default string", "Default string") {}

    /// <summary>
    /// Initializes a new instance of the <see cref="TwoButtonsSetting"/> class.
    /// </summary>
    /// <param name="customId">Custom string identifier for the option.</param>
    /// <param name="label">The text label shown left to the option.</param>
    /// <param name="firstOption">Text on the first button.</param>
    /// <param name="secondOption">Text on the second button.</param>
    /// <param name="isSecondDefault">
    /// <see langword="true"/> if the second button is selected by default; otherwise the first is selected.
    /// </param>
    /// <param name="hint">Optional hint text.</param>
    public TwoButtonsOption(
        string customId,
        string label,
        string firstOption,
        string secondOption,
        bool isSecondDefault = false,
        string hint = null)
    {
        CustomId = customId;
        Label = label;
        Hint = hint;
        FirstOption = firstOption;
        SecondOption = secondOption;
        IsSecondDefault = isSecondDefault;
    }

    /// <inheritdoc/>
    public override TwoButtonsSetting Base { get; internal set; }

    /// <inheritdoc/>
    public override string CustomId { get; set; }

    /// <inheritdoc/>
    public override string Label { get; set; }

    /// <inheritdoc/>
    public override string Hint { get; set; }

    /// <inheritdoc/>
    public override OptionValueType ReturnableType => OptionValueType.Boolean;

    /// <summary>
    /// Gets or sets the text on the first button.
    /// </summary>
    public string FirstOption { get; set; }

    /// <summary>
    /// Gets or sets the text on the second button.
    /// </summary>
    public string SecondOption { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the second button is the default choice.
    /// </summary>
    public bool IsSecondDefault { get; set; }

    /// <summary>
    /// Gets or sets the callback invoked when either button is clicked.
    /// <remarks>The boolean argument is <see langword="true"/> when the first button is chosen.</remarks>
    /// </summary>
    public Action<Player, bool> OnClicked { get; set; }

    /// <inheritdoc/>
    public Action<Player, IOption> OnValueReceived { get; set; }

    /// <inheritdoc/>
    protected override TwoButtonsSetting BuildBase() =>
        new(Id, Label, FirstOption, SecondOption, IsSecondDefault, Hint,
            onChanged: (player, setting) =>
                OnClicked?.Invoke(player, ((TwoButtonsSetting)setting).IsFirst));

    /// <inheritdoc/>
    public bool Validate() =>
        !string.IsNullOrWhiteSpace(CustomId) &&
        !string.IsNullOrWhiteSpace(Label) &&
        !string.IsNullOrWhiteSpace(FirstOption) &&
        !string.IsNullOrWhiteSpace(SecondOption);
}