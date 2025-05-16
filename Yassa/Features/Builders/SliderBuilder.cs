using System;
using System.Runtime.Serialization;
using Exiled.API.Features;
using Yassa.Interfaces;
using Yassa.Models;

namespace Yassa.Features.Builders;

/// <summary>
/// Represents a builder for <see cref="SliderOption"/>. This class cannot be inherited.
/// </summary>
public sealed class SliderBuilder : BuilderBase<SliderOption>
{
    /// <inheritdoc />
    protected override SliderOption Product { get; } = new();

    /// <summary>
    /// Sets the Custom ID of an option.
    /// </summary>
    /// <param name="customId">The new Custom ID value.</param>
    /// <returns>An updated <see cref="SliderBuilder"/> instance.</returns>
    public SliderBuilder SetCustomId(string customId)
    {
        Product.CustomId = customId;
        return this;
    }

    /// <summary>
    /// Sets the label text of an option.
    /// </summary>
    /// <param name="label">The new label text value.</param>
    /// <returns>An updated <see cref="SliderBuilder"/> instance.</returns>
    public SliderBuilder SetLabel(string label)
    {
        Product.Label = label;
        return this;
    }

    /// <summary>
    /// Sets the hint text of an option.
    /// </summary>
    /// <param name="hint">The new hint text value.</param>
    /// <returns>An updated <see cref="SliderBuilder"/> instance.</returns>
    public SliderBuilder SetHint(string hint)
    {
        Product.Hint = hint;
        return this;
    }

    /// <summary>
    /// Sets the minimum value allowed by the slider.
    /// </summary>
    /// <param name="minValue">The new minimum value.</param>
    /// <returns>An updated <see cref="SliderBuilder"/> instance.</returns>
    public SliderBuilder SetMinValue(float minValue)
    {
        Product.MinValue = minValue;
        return this;
    }

    /// <summary>
    /// Sets the maximum value allowed by the slider.
    /// </summary>
    /// <param name="maxValue">The new maximum value.</param>
    /// <returns>An updated <see cref="SliderBuilder"/> instance.</returns>
    public SliderBuilder SetMaxValue(float maxValue)
    {
        Product.MaxValue = maxValue;
        return this;
    }

    /// <summary>
    /// Sets the default slider value.
    /// </summary>
    /// <param name="defaultValue">The new default value.</param>
    /// <returns>An updated <see cref="SliderBuilder"/> instance.</returns>
    public SliderBuilder SetDefaultValue(float defaultValue)
    {
        Product.DefaultValue = defaultValue;
        return this;
    }

    /// <summary>
    /// Determines whether the slider should allow only integer values.
    /// </summary>
    /// <param name="isInteger"><see langword="true"/> to restrict to integers.</param>
    /// <returns>An updated <see cref="SliderBuilder"/> instance.</returns>
    public SliderBuilder SetIsInteger(bool isInteger)
    {
        Product.IsInteger = isInteger;
        return this;
    }

    /// <summary>
    /// Sets the numeric format used for persistence.
    /// </summary>
    /// <param name="format">The new numeric format string.</param>
    /// <returns>An updated <see cref="SliderBuilder"/> instance.</returns>
    public SliderBuilder SetStringFormat(string format)
    {
        Product.StringFormat = format;
        return this;
    }

    /// <summary>
    /// Sets the format string used when the value is displayed.
    /// </summary>
    /// <param name="format">The new display format string.</param>
    /// <returns>An updated <see cref="SliderBuilder"/> instance.</returns>
    public SliderBuilder SetDisplayFormat(string format)
    {
        Product.DisplayFormat = format;
        return this;
    }

    /// <summary>
    /// Registers a callback that receives the slider value from the client.
    /// </summary>
    /// <param name="action">Callback to invoke.</param>
    /// <returns>An updated <see cref="SliderBuilder"/> instance.</returns>
    public SliderBuilder OnValueReceived(Action<Player, IOption> action)
    {
        Product.OnValueReceived = action;
        return this;
    }

    /// <inheritdoc />
    public override SliderOption Build()
    {
        if (!Product.Validate())
            throw new SerializationException("Slider option has an invalid structure.");
        return Product;
    }
}