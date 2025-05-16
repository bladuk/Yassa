using System;
using System.Runtime.Serialization;
using Exiled.API.Features;
using Exiled.API.Features.Core.UserSettings;
using TMPro;
using UserSettings.ServerSpecific;
using Yassa.Models;

namespace Yassa.Features.Builders;

/// <summary>
/// Represents a builder for <see cref="TextAreaOption"/>. This class cannot be inherited.
/// </summary>
public sealed class TextAreaBuilder : BuilderBase<TextAreaOption>
{
    /// <inheritdoc />
    protected override TextAreaOption Product { get; } = new();

    /// <summary>
    /// Sets the Custom ID of an option.
    /// </summary>
    /// <param name="customId">The new Custom ID value.</param>
    /// <returns>An updated <see cref="TextAreaBuilder"/> instance.</returns>
    public TextAreaBuilder SetCustomId(string customId)
    {
        Product.CustomId = customId;
        return this;
    }

    /// <summary>
    /// Sets the label text of an option.
    /// </summary>
    /// <param name="label">The new label text value.</param>
    /// <returns>An updated <see cref="TextAreaBuilder"/> instance.</returns>
    public TextAreaBuilder SetLabel(string label)
    {
        Product.Label = label;
        return this;
    }

    /// <summary>
    /// Sets the hint text of an option.
    /// </summary>
    /// <param name="hint">The new hint text value.</param>
    /// <returns>An updated <see cref="TextAreaBuilder"/> instance.</returns>
    public TextAreaBuilder SetHint(string hint)
    {
        Product.Hint = hint;
        return this;
    }

    /// <summary>
    /// Sets the fold-out behaviour of the text area.
    /// </summary>
    /// <param name="foldoutMode">The new foldout mode.</param>
    /// <returns>An updated <see cref="TextAreaBuilder"/> instance.</returns>
    public TextAreaBuilder SetFoldoutMode(SSTextArea.FoldoutMode foldoutMode)
    {
        Product.FoldoutMode = foldoutMode;
        return this;
    }

    /// <summary>
    /// Sets the text alignment inside the area.
    /// </summary>
    /// <param name="textAlignment">The new TMP alignment value.</param>
    /// <returns>An updated <see cref="TextAreaBuilder"/> instance.</returns>
    public TextAreaBuilder SetTextAlignment(TextAlignmentOptions textAlignment)
    {
        Product.TextAlignment = textAlignment;
        return this;
    }

    /// <summary>
    /// Sets the OnChanged callback of an option.
    /// </summary>
    /// <param name="action">The new OnChanged callback.</param>
    /// <returns>An updated <see cref="TextAreaBuilder"/> instance.</returns>
    public TextAreaBuilder OnChanged(Action<Player, SettingBase> action)
    {
        Product.OnChanged = action;
        return this;
    }

    /// <inheritdoc />
    public override TextAreaOption Build()
    {
        if (!Product.Validate())
            throw new SerializationException("Text input has an invalid structure.");
        return Product;
    }
}