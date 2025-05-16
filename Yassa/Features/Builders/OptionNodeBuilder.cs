using System;
using System.Runtime.Serialization;
using Yassa.Models;

namespace Yassa.Features.Builders;

/// <summary>
/// Represents a builder for <see cref="OptionNode"/>. This class cannot be inherited.
/// </summary>
public sealed class OptionNodeBuilder : BuilderBase<OptionNode>
{
    /// <inheritdoc />
    protected override OptionNode Product { get; } = new();

    /// <summary>
    /// Sets the header text of an option node.
    /// </summary>
    /// <param name="header">The new header text value.</param>
    /// <returns>An updated <see cref="OptionNodeBuilder"/> instance.</returns>
    public OptionNodeBuilder SetHeader(string header)
    {
        Product.Header = header;
        return this;
    }

    /// <summary>
    /// Sets the hint text of an option node.
    /// </summary>
    /// <param name="hint">The new hint text value.</param>
    /// <returns>An updated <see cref="OptionNodeBuilder"/> instance.</returns>
    public OptionNodeBuilder SetHint(string hint)
    {
        Product.Hint = hint;
        return this;
    }

    /// <summary>
    /// Sets whether padding should be applied to the node.
    /// </summary>
    /// <param name="padding">The new padding value.</param>
    /// <returns>An updated <see cref="OptionNodeBuilder"/> instance.</returns>
    public OptionNodeBuilder SetPadding(bool padding)
    {
        Product.Padding = padding;
        return this;
    }

    /// <summary>
    /// Adds a new <see cref="SliderOption"/> configured through an inline builder.
    /// </summary>
    /// <param name="option">Delegate used to configure a temporary <see cref="SliderBuilder"/>.</param>
    /// <returns>An updated <see cref="OptionNodeBuilder"/> instance.</returns>
    public OptionNodeBuilder AddSliderOption(Action<SliderBuilder> option)
    {
        SliderBuilder builder = new();
        option(builder);
        Product.Options.Add(builder.Build());
        return this;
    }

    /// <summary>
    /// Adds an existing <see cref="SliderOption"/> instance.
    /// </summary>
    /// <param name="slider">The option to add.</param>
    /// <returns>An updated <see cref="OptionNodeBuilder"/> instance.</returns>
    public OptionNodeBuilder AddSliderOption(SliderOption slider)
    {
        Product.Options.Add(slider);
        return this;
    }

    /// <summary>
    /// Adds a new <see cref="DropdownOption"/> configured through an inline builder.
    /// </summary>
    /// <param name="option">Delegate used to configure a temporary <see cref="DropdownBuilder"/>.</param>
    /// <returns>An updated <see cref="OptionNodeBuilder"/> instance.</returns>
    public OptionNodeBuilder AddDropdownOption(Action<DropdownBuilder> option)
    {
        DropdownBuilder builder = new();
        option(builder);
        Product.Options.Add(builder.Build());
        return this;
    }

    /// <summary>
    /// Adds an existing <see cref="DropdownOption"/> instance.
    /// </summary>
    /// <param name="dropdownOption">The option to add.</param>
    /// <returns>An updated <see cref="OptionNodeBuilder"/> instance.</returns>
    public OptionNodeBuilder AddDropdownOption(DropdownOption dropdownOption)
    {
        Product.Options.Add(dropdownOption);
        return this;
    }

    /// <summary>
    /// Adds a new <see cref="ButtonOption"/> configured through an inline builder.
    /// </summary>
    /// <param name="option">Delegate used to configure a temporary <see cref="ButtonBuilder"/>.</param>
    /// <returns>An updated <see cref="OptionNodeBuilder"/> instance.</returns>
    public OptionNodeBuilder AddButtonOption(Action<ButtonBuilder> option)
    {
        ButtonBuilder builder = new();
        option(builder);
        Product.Options.Add(builder.Build());
        return this;
    }

    /// <summary>
    /// Adds an existing <see cref="ButtonOption"/> instance.
    /// </summary>
    /// <param name="buttonOption">The option to add.</param>
    /// <returns>An updated <see cref="OptionNodeBuilder"/> instance.</returns>
    public OptionNodeBuilder AddButtonOption(ButtonOption buttonOption)
    {
        Product.Options.Add(buttonOption);
        return this;
    }

    /// <summary>
    /// Adds a new <see cref="TextAreaOption"/> configured through an inline builder.
    /// </summary>
    /// <param name="option">Delegate used to configure a temporary <see cref="TextAreaBuilder"/>.</param>
    /// <returns>An updated <see cref="OptionNodeBuilder"/> instance.</returns>
    public OptionNodeBuilder AddTextAreaOption(Action<TextAreaBuilder> option)
    {
        TextAreaBuilder builder = new();
        option(builder);
        Product.Options.Add(builder.Build());
        return this;
    }

    /// <summary>
    /// Adds an existing <see cref="TextAreaOption"/> instance.
    /// </summary>
    /// <param name="textAreaOption">The option to add.</param>
    /// <returns>An updated <see cref="OptionNodeBuilder"/> instance.</returns>
    public OptionNodeBuilder AddTextAreaOption(TextAreaOption textAreaOption)
    {
        Product.Options.Add(textAreaOption);
        return this;
    }

    /// <summary>
    /// Adds a new <see cref="TextInputOption"/> configured through an inline builder.
    /// </summary>
    /// <param name="option">Delegate used to configure a temporary <see cref="TextInputBuilder"/>.</param>
    /// <returns>An updated <see cref="OptionNodeBuilder"/> instance.</returns>
    public OptionNodeBuilder AddTextInputOption(Action<TextInputBuilder> option)
    {
        TextInputBuilder builder = new();
        option(builder);
        Product.Options.Add(builder.Build());
        return this;
    }

    /// <summary>
    /// Adds an existing <see cref="TextInputOption"/> instance.
    /// </summary>
    /// <param name="textInputOption">The option to add.</param>
    /// <returns>An updated <see cref="OptionNodeBuilder"/> instance.</returns>
    public OptionNodeBuilder AddTextInputOption(TextInputOption textInputOption)
    {
        Product.Options.Add(textInputOption);
        return this;
    }

    /// <summary>
    /// Adds a new <see cref="TwoButtonsOption"/> configured through an inline builder.
    /// </summary>
    /// <param name="option">Delegate used to configure a temporary <see cref="TwoButtonsBuilder"/>.</param>
    /// <returns>An updated <see cref="OptionNodeBuilder"/> instance.</returns>
    public OptionNodeBuilder AddTwoButtonsOption(Action<TwoButtonsBuilder> option)
    {
        TwoButtonsBuilder builder = new();
        option(builder);
        Product.Options.Add(builder.Build());
        return this;
    }

    /// <summary>
    /// Adds an existing <see cref="TwoButtonsOption"/> instance.
    /// </summary>
    /// <param name="twoButtonsOption">The option to add.</param>
    /// <returns>An updated <see cref="OptionNodeBuilder"/> instance.</returns>
    public OptionNodeBuilder AddTwoButtonsOption(TwoButtonsOption twoButtonsOption)
    {
        Product.Options.Add(twoButtonsOption);
        return this;
    }

    /// <summary>
    /// Adds a new <see cref="KeybindOption"/> configured through an inline builder.
    /// </summary>
    /// <param name="option">Delegate used to configure a temporary <see cref="KeybindBuilder"/>.</param>
    /// <returns>An updated <see cref="OptionNodeBuilder"/> instance.</returns>
    public OptionNodeBuilder AddKeybindOption(Action<KeybindBuilder> option)
    {
        KeybindBuilder builder = new();
        option(builder);
        Product.Options.Add(builder.Build());
        return this;
    }

    /// <summary>
    /// Adds an existing <see cref="KeybindOption"/> instance.
    /// </summary>
    /// <param name="twoButtonsOption">The option to add.</param>
    /// <returns>An updated <see cref="OptionNodeBuilder"/> instance.</returns>
    public OptionNodeBuilder AddKeybindOption(KeybindOption twoButtonsOption)
    {
        Product.Options.Add(twoButtonsOption);
        return this;
    }

    /// <inheritdoc />
    public override OptionNode Build()
    {
        if (!Product.Validate())
            throw new SerializationException("Option node has an invalid structure.");
        return Product;
    }
}