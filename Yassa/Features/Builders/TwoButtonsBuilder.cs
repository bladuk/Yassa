using System;
using System.Runtime.Serialization;
using Exiled.API.Features;
using Yassa.Interfaces;
using Yassa.Models;

namespace Yassa.Features.Builders;

/// <summary>
/// Represents a builder for <see cref="TwoButtonsOption"/>. This class cannot be inherited.
/// </summary>
public sealed class TwoButtonsBuilder : BuilderBase<TwoButtonsOption>
{
    /// <inheritdoc />
    protected override TwoButtonsOption Product { get; } = new();

    /// <summary>
    /// Sets the Custom ID of an option.
    /// </summary>
    /// <param name="customId">The new Custom ID value.</param>
    /// <returns>An updated <see cref="TwoButtonsBuilder"/> instance.</returns>
    public TwoButtonsBuilder SetCustomId(string customId)
    {
        Product.CustomId = customId;
        return this;
    }

    /// <summary>
    /// Sets the label text of an option.
    /// </summary>
    /// <param name="label">The new label text value.</param>
    /// <returns>An updated <see cref="TwoButtonsBuilder"/> instance.</returns>
    public TwoButtonsBuilder SetLabel(string label)
    {
        Product.Label = label;
        return this;
    }

    /// <summary>
    /// Sets the hint text of an option.
    /// </summary>
    /// <param name="hint">The new hint text value.</param>
    /// <returns>An updated <see cref="TwoButtonsBuilder"/> instance.</returns>
    public TwoButtonsBuilder SetHint(string hint)
    {
        Product.Hint = hint;
        return this;
    }

    /// <summary>
    /// Sets the caption of the first button.
    /// </summary>
    /// <param name="firstOption">Text shown on the first button.</param>
    /// <returns>An updated <see cref="TwoButtonsBuilder"/> instance.</returns>
    public TwoButtonsBuilder SetFirstOption(string firstOption)
    {
        Product.FirstOption = firstOption;
        return this;
    }

    /// <summary>
    /// Sets the caption of the second button.
    /// </summary>
    /// <param name="secondOption">Text shown on the second button.</param>
    /// <returns>An updated <see cref="TwoButtonsBuilder"/> instance.</returns>
    public TwoButtonsBuilder SetSecondOption(string secondOption)
    {
        Product.SecondOption = secondOption;
        return this;
    }

    /// <summary>
    /// Determines whether the second button is the default choice.
    /// </summary>
    /// <param name="isSecondDefault">A new value.</param>
    /// <returns>An updated <see cref="TwoButtonsBuilder"/> instance.</returns>
    public TwoButtonsBuilder SetIsSecondDefault(bool isSecondDefault)
    {
        Product.IsSecondDefault = isSecondDefault;
        return this;
    }

    /// <summary>
    /// Registers a callback fired when either button is clicked.
    /// </summary>
    /// <param name="onClicked">Callback to invoke (second argument is <see langword="true"/> when first button is chosen).</param>
    /// <returns>An updated <see cref="TwoButtonsBuilder"/> instance.</returns>
    public TwoButtonsBuilder OnClicked(Action<Player, bool> onClicked)
    {
        Product.OnClicked = onClicked;
        return this;
    }

    /// <summary>
    /// Registers a callback that receives the chosen value from the client.
    /// </summary>
    /// <param name="onValueReceived">Callback to invoke.</param>
    /// <returns>An updated <see cref="TwoButtonsBuilder"/> instance.</returns>
    public TwoButtonsBuilder OnValueReceived(Action<Player, IOption> onValueReceived)
    {
        Product.OnValueReceived = onValueReceived;
        return this;
    }

    /// <inheritdoc />
    public override TwoButtonsOption Build()
    {
        if (!Product.Validate())
            throw new SerializationException("Two buttons option has an invalid structure");
        return Product;
    }
}