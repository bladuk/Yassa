using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Exiled.API.Features;
using Exiled.API.Features.Core.UserSettings;
using UserSettings.ServerSpecific;
using Yassa.Interfaces;
using Yassa.Models;

namespace Yassa.Features.Builders;

/// <summary>
/// Represents a builder for <see cref="DropdownOption"/>. This class cannot be inherited.
/// </summary>
public sealed class DropdownBuilder : BuilderBase<DropdownOption>
{
    /// <inheritdoc />
    protected override DropdownOption Product { get; } = new();
    
    /// <summary>
    /// Sets the Custom ID of an option.
    /// </summary>
    /// <param name="customId">The new Custom ID value.</param>
    /// <returns>An updated <see cref="DropdownBuilder"/> instance.</returns>
    public DropdownBuilder SetCustomId(string customId)
    {
        Product.CustomId = customId;

        return this;
    }

    /// <summary>
    /// Sets the label text of an option.
    /// </summary>
    /// <param name="label">The new label text value.</param>
    /// <returns>An updated <see cref="DropdownBuilder"/> instance.</returns>
    public DropdownBuilder SetLabel(string label)
    {
        Product.Label = label;
        
        return this;
    }

    /// <summary>
    /// Sets the hint text of an option.
    /// </summary>
    /// <param name="hint">The new hint text value.</param>
    /// <returns>An updated <see cref="DropdownBuilder"/> instance.</returns>
    public DropdownBuilder SetHint(string hint)
    {
        Product.Hint = hint;
        
        return this;
    }

    /// <summary>
    /// Sets the options list of an option.
    /// </summary>
    /// <param name="options">The new options list value.</param>
    /// <returns>An updated <see cref="DropdownBuilder"/> instance.</returns>
    public DropdownBuilder SetOptions(List<string> options)
    {
        Product.Options = options;

        return this;
    }

    /// <summary>
    /// Appends an option to a dropdown.
    /// </summary>
    /// <param name="option">The new option.</param>
    /// <returns>An updated <see cref="DropdownBuilder"/> instance.</returns>
    public DropdownBuilder AppendOption(string option)
    {
        Product.Options.Add(option);

        return this;
    }

    /// <summary>
    /// Sets the default option by its index.
    /// </summary>
    /// <param name="index">Index of an option.</param>
    /// <returns>An updated <see cref="DropdownBuilder"/> instance.</returns>
    public DropdownBuilder SetDefaultOption(int index)
    {
        Product.DefaultOptionIndex = index;

        return this;
    }

    /// <summary>
    /// Sets the default option by its value.
    /// </summary>
    /// <param name="option">Value of an option.</param>
    /// <returns>An updated <see cref="DropdownBuilder"/> instance.</returns>
    /// <exception cref="ArgumentException">Thrown if the option does not exist.</exception>
    public DropdownBuilder SetDefaultOption(string option)
    {
        int index = Product.Options.IndexOf(option);

        if (index == -1)
            throw new ArgumentException($"Option {option} not found", nameof(option));
        
        Product.DefaultOptionIndex = index;

        return this;
    }

    /// <summary>
    /// Sets the entry type of an option.
    /// </summary>
    /// <param name="entryType">The new entry type value.</param>
    /// <returns>An updated <see cref="DropdownBuilder"/> instance.</returns>
    public DropdownBuilder SetEntryType(SSDropdownSetting.DropdownEntryType entryType)
    {
        Product.EntryType = entryType;

        return this;
    }

    /// <summary>
    /// Sets the OnChanged callback of an option.
    /// </summary>
    /// <param name="onChanged">The new OnChanged callback.</param>
    /// <returns>An updated instance of DropdownBuilder.</returns>
    public DropdownBuilder OnChanged(Action<Player, SettingBase> onChanged)
    {
        Product.OnChanged = onChanged;
        
        return this;
    }

    /// <summary>
    /// Sets the OnValueReceived behavior of an option.
    /// </summary>
    /// <param name="onValueReceived">The new OnValueReceived behavior.</param>
    /// <returns>An updated instance of DropdownBuilder.</returns>
    public DropdownBuilder OnValueReceived(Action<Player, IOption> onValueReceived)
    {
        Product.OnValueReceived = onValueReceived;

        return this;
    }
    
    /// <inheritdoc />
    public override DropdownOption Build()
    {
        if (!Product.Validate())
            throw new SerializationException("Dropdown options has an invalid structure");

        return Product;
    }
}