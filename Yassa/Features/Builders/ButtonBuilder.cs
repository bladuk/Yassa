using System;
using System.Runtime.Serialization;
using Exiled.API.Features;
using Yassa.Models;

namespace Yassa.Features.Builders;

/// <summary>
/// Represents a builder for <see cref="ButtonOption"/>. This class cannot be inherited.
/// </summary>
public sealed class ButtonBuilder : BuilderBase<ButtonOption>
{
    /// <inheritdoc />
    protected override ButtonOption Product { get; } = new();
    
    /// <summary>
    /// Sets the Custom ID of an option.
    /// </summary>
    /// <param name="customId">The new Custom ID value.</param>
    /// <returns>An updated <see cref="ButtonBuilder"/> instance.</returns>
    public ButtonBuilder SetCustomId(string customId)
    {
        Product.CustomId = customId;

        return this;
    }

    /// <summary>
    /// Sets the label text of an option.
    /// </summary>
    /// <param name="label">The new label text value.</param>
    /// <returns>An updated <see cref="ButtonBuilder"/> instance.</returns>
    public ButtonBuilder SetLabel(string label)
    {
        Product.Label = label;
        
        return this;
    }

    /// <summary>
    /// Sets the hint text of an option.
    /// </summary>
    /// <param name="hint">The new hint text value.</param>
    /// <returns>An updated <see cref="ButtonBuilder"/> instance.</returns>
    public ButtonBuilder SetHint(string hint)
    {
        Product.Hint = hint;
        
        return this;
    }

    /// <summary>
    /// Sets the button text of an option.
    /// </summary>
    /// <param name="text">The new button text value.</param>
    /// <returns>An updated <see cref="ButtonBuilder"/> instance.</returns>
    public ButtonBuilder SetText(string text)
    {
        Product.Text = text;
        
        return this;
    }

    /// <summary>
    /// Sets the hold time of an option.
    /// </summary>
    /// <param name="holdTime">The new hold time value.</param>
    /// <returns>An updated <see cref="ButtonBuilder"/> instance.</returns>
    public ButtonBuilder SetHoldTime(float holdTime)
    {
        Product.HoldTime = holdTime;
        
        return this;
    }

    /// <summary>
    /// Sets the OnClicked behavior of an option.
    /// </summary>
    /// <param name="onClicked">The new OnClicked behavior.</param>
    /// <returns>An updated <see cref="ButtonBuilder"/> instance.</returns>
    public ButtonBuilder OnClicked(Action<Player, ButtonOption> onClicked)
    {
        Product.OnClicked = onClicked;

        return this;
    }
    
    /// <inheritdoc />
    public override ButtonOption Build()
    {
        if (!Product.Validate())
            throw new SerializationException("Button option has an invalid structure");

        return Product;
    }
}