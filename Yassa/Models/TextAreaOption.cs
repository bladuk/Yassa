// ReSharper disable MemberCanBePrivate.Global

using System;
using Exiled.API.Features;
using Exiled.API.Features.Core.UserSettings;
using TMPro;
using UserSettings.ServerSpecific;
using Yassa.Enums;
using Yassa.Interfaces;

namespace Yassa.Models;

/// <summary>
/// Represents a multi-line text area in the settings menu without user input. This class cannot be inherited.
/// </summary>
public sealed class TextAreaOption : OptionBase<TextInputSetting>, IValidatable
{
    /// <summary>
    /// Initializes a new instance with default values.
    /// </summary>
    public TextAreaOption() : this("", "Default string") {}

    /// <summary>
    /// Initializes a new instance of the <see cref="TextAreaOption"/> class.
    /// </summary>
    /// <param name="customId">Custom string identifier for the option.</param>
    /// <param name="label">The text label shown left to the option.</param>
    /// <param name="hint">Optional hint text.</param>
    /// <param name="foldoutMode">Whether the area is collapsible.</param>
    /// <param name="textAlignment">TMP alignment for the text box.</param>
    /// <param name="onChanged">Callback fired when the text area is changed.</param>
    public TextAreaOption(
        string customId,
        string label,
        string hint = null,
        SSTextArea.FoldoutMode foldoutMode = SSTextArea.FoldoutMode.NotCollapsable,
        TextAlignmentOptions textAlignment = TextAlignmentOptions.TopLeft,
        Action<Player, SettingBase> onChanged = null)
    {
        CustomId = customId;
        Label = label;
        Hint = hint;
        FoldoutMode = foldoutMode;
        TextAlignment = textAlignment;
        OnChanged = onChanged;
    }

    /// <inheritdoc/>
    public override TextInputSetting Base { get; internal set; }

    /// <inheritdoc/>
    public override string CustomId { get; set; }

    /// <inheritdoc/>
    public override string Label { get; set; }

    /// <inheritdoc/>
    public override string Hint { get; set; }

    /// <inheritdoc/>
    public override OptionValueType ReturnableType => OptionValueType.None;

    /// <summary>
    /// Gets or sets whether the control can be collapsed.
    /// </summary>
    public SSTextArea.FoldoutMode FoldoutMode { get; set; }

    /// <summary>
    /// Gets or sets the text alignment inside the field.
    /// </summary>
    public TextAlignmentOptions TextAlignment { get; set; }

    /// <summary>
    /// Gets or sets the callback invoked when the text area is changed.
    /// </summary>
    public Action<Player, SettingBase> OnChanged { get; set; }

    /// <inheritdoc/>
    protected override TextInputSetting BuildBase() =>
        new(Id, Label, FoldoutMode, TextAlignment, Hint, onChanged: OnChanged);

    /// <inheritdoc/>
    public bool Validate() =>
        !string.IsNullOrWhiteSpace(CustomId) &&
        !string.IsNullOrWhiteSpace(Label);
}