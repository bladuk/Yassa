// ReSharper disable MemberCanBePrivate.Global

using System;
using Exiled.API.Features;
using Exiled.API.Features.Core.UserSettings;
using Yassa.Enums;
using Yassa.Interfaces;

namespace Yassa.Models;

/// <summary>
/// Represents a slider option in the settings menu. This class cannot be inherited.
/// </summary> 
public sealed class SliderOption : OptionBase<SliderSetting>, IValidatable, IValueReceiver
{
    /// <summary>
    /// Initializes a new instance with default values.
    /// </summary>
    public SliderOption() : this("", "Default string", 0f, 10f, 0f) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="SliderOption"/> class.
    /// </summary>
    /// <param name="customId">Custom string identifier for the option.</param>
    /// <param name="label">The text label shown left to the option.</param>
    /// <param name="minValue">Minimum value selectable on the slider.</param>
    /// <param name="maxValue">Maximum value selectable on the slider.</param>
    /// <param name="defaultValue">Value that the slider starts at.</param>
    /// <param name="hint">Optional hint text.</param>
    /// <param name="isInteger">
    /// <see langword="true"/> to restrict the slider to whole numbers only; otherwise <see langword="false"/>.
    /// </param>
    /// <param name="stringFormat">Numeric format string used for persistence.</param>
    /// <param name="displayFormat">Format string used when showing the value to the player.</param>
    public SliderOption(
        string customId,
        string label,
        float minValue,
        float maxValue,
        float defaultValue,
        string hint = null,
        bool isInteger = false,
        string stringFormat = "0.##",
        string displayFormat = "{0}")
    {
        CustomId = customId;
        Label = label;
        Hint = hint;
        MinValue = minValue;
        MaxValue = maxValue;
        DefaultValue = defaultValue;
        IsInteger = isInteger;
        StringFormat = stringFormat;
        DisplayFormat = displayFormat;
    }

    /// <inheritdoc/>
    public override SliderSetting Base { get; internal set; }

    /// <inheritdoc/>
    public override string CustomId { get; set; }

    /// <inheritdoc/>
    public override string Label { get; set; }

    /// <inheritdoc/>
    public override string Hint { get; set; }

    /// <inheritdoc/>
    public override OptionValueType ReturnableType => OptionValueType.Number;

    /// <summary>
    /// Gets or sets the minimum value allowed by the slider.
    /// </summary>
    public float MinValue { get; set; }

    /// <summary>
    /// Gets or sets the maximum value allowed by the slider.
    /// </summary>
    public float MaxValue { get; set; }

    /// <summary>
    /// Gets or sets the default value.
    /// </summary>
    public float DefaultValue { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the slider should only allow integers.
    /// </summary>
    public bool IsInteger { get; set; }

    /// <summary>
    /// Gets or sets the numeric format used to display the value to the player.
    /// </summary>
    public string StringFormat { get; set; }

    /// <summary>
    /// Gets or sets the string format used to display the value to the player.
    /// </summary>
    public string DisplayFormat { get; set; }

    /// <inheritdoc/>
    public Action<Player, IOption> OnValueReceived { get; set; }

    /// <inheritdoc/>
    protected override SliderSetting BuildBase() =>
        new(Id, Label, MinValue, MaxValue, DefaultValue, IsInteger, StringFormat, DisplayFormat, Hint);

    /// <inheritdoc/>
    public bool Validate() =>
        !string.IsNullOrWhiteSpace(CustomId)
        && !string.IsNullOrWhiteSpace(Label)
        && MaxValue >= MinValue
        && DefaultValue >= MinValue
        && DefaultValue <= MaxValue;
}