// ReSharper disable MemberCanBePrivate.Global

using System;
using Exiled.API.Features;
using Exiled.API.Features.Core.UserSettings;
using TMPro;
using Yassa.Enums;
using Yassa.Interfaces;

namespace Yassa.Models;

/// <summary>
/// Represents a single-line text input field in the settings menu. This class cannot be inherited.
/// </summary>
public sealed class TextInputOption : OptionBase<UserTextInputSetting>, IValidatable, IValueReceiver
{
    /// <summary>
    /// Initialises a new instance with default values.
    /// </summary>
    public TextInputOption() : this("", "Default string") {}

    /// <summary>
    /// Initializes a new instance of the <see cref="TextInputOption"/> class.
    /// </summary>
    /// <param name="customId">Custom string identifier for the option.</param>
    /// <param name="label">The text label shown left to the option.</param>
    /// <param name="hint">Optional hint text.</param>
    /// <param name="placeholder">Placeholder text shown when the field is empty.</param>
    /// <param name="characterLimit">Maximum number of characters the player may enter.</param>
    /// <param name="contentType">Input field content type.</param>
    public TextInputOption(
        string customId,
        string label,
        string hint = null,
        string placeholder = "",
        int characterLimit = 64,
        TMP_InputField.ContentType contentType = TMP_InputField.ContentType.Standard)
    {
        CustomId = customId;
        Label = label;
        Hint = hint;
        Placeholder = placeholder;
        CharacterLimit = characterLimit;
        ContentType = contentType;
    }

    /// <inheritdoc/>
    public override UserTextInputSetting Base { get; internal set; }

    /// <inheritdoc/>
    public override string CustomId { get; set; }

    /// <inheritdoc/>
    public override string Label { get; set; }

    /// <inheritdoc/>
    public override string Hint { get; set; }

    /// <inheritdoc/>
    public override OptionValueType ReturnableType => OptionValueType.String;

    /// <summary>
    /// Gets or sets the placeholder text.
    /// </summary>
    public string Placeholder { get; set; }

    /// <summary>
    /// Gets or sets the maximum number of characters allowed.
    /// </summary>
    public int CharacterLimit { get; set; }

    /// <summary>
    /// Gets or sets the content type of string.
    /// </summary>
    public TMP_InputField.ContentType ContentType { get; set; }

    /// <inheritdoc/>
    public Action<Player, IOption> OnValueReceived { get; set; }

    /// <inheritdoc/>
    protected override UserTextInputSetting BuildBase() =>
        new(Id, Label, Placeholder, CharacterLimit, ContentType, Hint);

    /// <inheritdoc/>
    public bool Validate() =>
        !string.IsNullOrWhiteSpace(CustomId) &&
        !string.IsNullOrWhiteSpace(Label) &&
        CharacterLimit >= 0;
}