using System;
using System.Runtime.Serialization;
using Exiled.API.Features;
using UnityEngine;
using Yassa.Models;

namespace Yassa.Features.Builders;

/// <summary>
/// Represents a builder for <see cref="KeybindOption"/>. This class cannot be inherited.
/// </summary>
public sealed class KeybindBuilder : BuilderBase<KeybindOption>
{
    /// <inheritdoc />
    protected override KeybindOption Product { get; } = new();
    
    /// <summary>
    /// Sets the Custom ID of an option.
    /// </summary>
    /// <param name="customId">The new Custom ID value.</param>
    /// <returns>An updated <see cref="KeybindBuilder"/> instance.</returns>
    public KeybindBuilder SetCustomId(string customId)
    {
        Product.CustomId = customId;

        return this;
    }

    /// <summary>
    /// Sets the label text of an option.
    /// </summary>
    /// <param name="label">The new label text value.</param>
    /// <returns>An updated <see cref="KeybindBuilder"/> instance.</returns>
    public KeybindBuilder SetLabel(string label)
    {
        Product.Label = label;
        
        return this;
    }

    /// <summary>
    /// Sets the hint text of an option.
    /// </summary>
    /// <param name="hint">The new hint text value.</param>
    /// <returns>An updated <see cref="KeybindBuilder"/> instance.</returns>
    public KeybindBuilder SetHint(string hint)
    {
        Product.Hint = hint;
        
        return this;
    }

    /// <summary>
    /// Sets the suggested key code of an option.
    /// </summary>
    /// <param name="keyCode">The new suggested key code value.</param>
    /// <returns>An updated <see cref="KeybindBuilder"/> instance.</returns>
    public KeybindBuilder SetKeyCode(KeyCode keyCode)
    {
        Product.SuggestedKey = keyCode;

        return this;
    }

    /// <summary>
    /// Determines whether normal interaction is blocked when another GUI is open.
    /// </summary>
    /// <param name="isInteractionPreventedOnGui">The new value.</param>
    /// <returns>An updated <see cref="KeybindBuilder"/> instance.</returns>
    public KeybindBuilder SetIsInteractionPreventedOnGui(bool isInteractionPreventedOnGui)
    {
        Product.IsInteractionPreventedOnGui = isInteractionPreventedOnGui;
        
        return this;
    }

    /// <summary>
    /// Sets the OnPressed behavior of an option.
    /// </summary>
    /// <param name="onPressed">The new OnPressed behavior.</param>
    /// <returns>An updated instance of KeybindBuilder.</returns>
    public KeybindBuilder OnPressed(Action<Player, KeybindOption> onPressed)
    {
        Product.OnPressed = onPressed;
        
        return this;
    }
    
    /// <inheritdoc />
    public override KeybindOption Build()
    {
        if (!Product.Validate())
            throw new SerializationException("Keybind option has an invalid structure");

        return Product;
    }
}