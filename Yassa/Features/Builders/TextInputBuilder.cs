using System;
using System.Runtime.Serialization;
using Exiled.API.Features;
using TMPro;
using Yassa.Interfaces;
using Yassa.Models;

namespace Yassa.Features.Builders;

/// <summary>
/// Represents a builder for <see cref="TextInputOption"/>. This class cannot be inherited.
/// </summary>
public sealed class TextInputBuilder : BuilderBase<TextInputOption>
{
    /// <inheritdoc />
    protected override TextInputOption Product { get; } = new();

    /// <summary>
    /// Sets the Custom ID of an option.
    /// </summary>
    /// <param name="customId">The new Custom ID value.</param>
    /// <returns>An updated <see cref="TextInputBuilder"/> instance.</returns>
    public TextInputBuilder SetCustomId(string customId)
    {
        Product.CustomId = customId;
        return this;
    }

    /// <summary>
    /// Sets the label text of an option.
    /// </summary>
    /// <param name="label">The new label text value.</param>
    /// <returns>An updated <see cref="TextInputBuilder"/> instance.</returns>
    public TextInputBuilder SetLabel(string label)
    {
        Product.Label = label;
        return this;
    }

    /// <summary>
    /// Sets the hint text of an option.
    /// </summary>
    /// <param name="hint">The new hint text value.</param>
    /// <returns>An updated <see cref="TextInputBuilder"/> instance.</returns>
    public TextInputBuilder SetHint(string hint)
    {
        Product.Hint = hint;
        return this;
    }

    /// <summary>
    /// Sets the placeholder text shown in the input field.
    /// </summary>
    /// <param name="placeholder">A new placeholder value.</param>
    /// <returns>An updated <see cref="TextInputBuilder"/> instance.</returns>
    public TextInputBuilder SetPlaceholder(string placeholder)
    {
        Product.Placeholder = placeholder;
        return this;
    }

    /// <summary>
    /// Sets the maximum number of characters allowed.
    /// </summary>
    /// <param name="characterLimit">A new character limit value.</param>
    /// <returns>An updated <see cref="TextInputBuilder"/> instance.</returns>
    public TextInputBuilder SetCharacterLimit(int characterLimit)
    {
        Product.CharacterLimit = characterLimit;
        return this;
    }

    /// <summary>
    /// Sets the content type of input field.
    /// </summary>
    /// <param name="contentType">A new content type value.</param>
    /// <returns>An updated <see cref="TextInputBuilder"/> instance.</returns>
    public TextInputBuilder SetContentType(TMP_InputField.ContentType contentType)
    {
        Product.ContentType = contentType;
        return this;
    }

    /// <summary>
    /// Registers a callback that receives the text from the client.
    /// </summary>
    /// <param name="onValueReceived">Callback to invoke.</param>
    /// <returns>An updated <see cref="TextInputBuilder"/> instance.</returns>
    public TextInputBuilder OnValueReceived(Action<Player, IOption> onValueReceived)
    {
        Product.OnValueReceived = onValueReceived;
        return this;
    }

    /// <inheritdoc />
    public override TextInputOption Build()
    {
        if (!Product.Validate())
            throw new SerializationException("Text input option has an invalid structure");
        return Product;
    }
}