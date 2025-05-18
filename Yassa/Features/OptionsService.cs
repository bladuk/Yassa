using System;
using System.Collections.Generic;
using System.Linq;
using Exiled.API.Features;
using Exiled.API.Features.Core.UserSettings;
using Utils.NonAllocLINQ;
using Yassa.Enums;
using Yassa.Interfaces;
using Yassa.Models;

namespace Yassa.Features;

/// <summary>
/// Central service that registers option nodes and later retrieves their values. This class cannot be inherited.
/// </summary>
public static class OptionsService
{
    /// <summary>
    /// Holds every option that has been registered for the current session.
    /// </summary>
    private static readonly List<IOption> _allOptions = new();
    
    /// <summary>
    /// Registers an <see cref="OptionNode"/>.
    /// </summary>
    /// <param name="node">Tree node with options.</param>
    /// <param name="predicate">A requirement to meet when sending settings to players.</param>
    /// <exception cref="ArgumentNullException">Thrown if the option node is null.</exception>
    public static void Register(OptionNode node, Func<Player, bool> predicate = null)
    {
        SettingBase.Register(BuildSettingsList(node), predicate);
    }

    /// <summary>
    /// Registers an <see cref="OptionNode"/> to player.
    /// </summary>
    /// <param name="node">Tree node with options.</param>
    /// <param name="player">A player that will receive options.</param>
    /// <exception cref="ArgumentNullException">Thrown if the option node is null.</exception>
    public static void Register(OptionNode node, Player player)
    {
        SettingBase.Register(player, BuildSettingsList(node));
    }

    /// <summary>
    /// Unregisters an <see cref="OptionNode"/>.
    /// </summary>
    /// <param name="node">Tree node with options.</param>
    /// <param name="predicate">A requirement to meet when sending update to players.</param>
    /// <exception cref="ArgumentNullException">Thrown if the option node is null.</exception>
    public static void Unregister(OptionNode node, Func<Player, bool> predicate = null)
    {
        SettingBase.Unregister(predicate, GetSettingsList(node));
    }

    /// <summary>
    /// Unregisters an <see cref="OptionNode"/> to player.
    /// </summary>
    /// <param name="node">Tree node with options.</param>
    /// <param name="player">A player that will receive update.</param>
    /// <exception cref="ArgumentNullException">Thrown if the option node is null.</exception>
    public static void Unregister(OptionNode node, Player player)
    {
        SettingBase.Unregister(player, GetSettingsList(node));
    }

    /// <summary>
    /// Tries to fetch an option by its custom ID.
    /// </summary>
    public static IOption Get(string customId) =>
        _allOptions.FirstOrDefault(o => o.CustomId == customId);

    /// <summary>
    /// Tries to fetch an option by its numeric ID.
    /// </summary>
    public static IOption Get(int id) =>
        _allOptions.FirstOrDefault(o => o.Id == id);

    /// <summary>
    /// Retrieves the current <see cref="string"/> value of an option.
    /// </summary>
    /// <param name="player">The target player.</param>
    /// <param name="customId">The custom ID of an option.</param>
    /// <exception cref="ArgumentException">
    /// Thrown if the option does not exist.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    /// Thrown when the requested option does not return <see cref="string"/>.
    /// </exception>
    public static string GetStringValue(Player player, string customId)
    {
        if (!_allOptions.TryGetFirst(o => o.CustomId == customId, out var option))
            throw new ArgumentException($"An option with custom id {customId} was not found.");

        if (option.ReturnableType != OptionValueType.String)
            throw new InvalidOperationException($"Option {customId} does not return a string.");

        return option switch
        {
            DropdownOption drop =>
                SettingBase.TryGetSetting(player, drop.Id, out DropdownSetting setting)
                    ? setting.SelectedOption
                    : throw new ArgumentException($"Option {customId} has no value selected."),
            TextInputOption text =>
                SettingBase.TryGetSetting(player, text.Id, out UserTextInputSetting setting)
                    ? setting.Text
                    : throw new Exception("Unexpected error while reading setting value."),
            _ => string.Empty
        };
    }

    /// <summary>
    /// Retrieves the current <see cref="float"/> value of an option.
    /// </summary>
    /// <param name="player">The target player.</param>
    /// <param name="customId">The custom ID of an option.</param>
    /// <exception cref="ArgumentException">
    /// Thrown if the option does not exist.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    /// Thrown when the requested option does not return <see cref="float"/>.
    /// </exception>
    public static float GetNumberValue(Player player, string customId)
    {
        if (!_allOptions.TryGetFirst(o => o.CustomId == customId, out var option))
            throw new ArgumentException($"An option with custom id {customId} was not found.");

        if (option.ReturnableType != OptionValueType.Number)
            throw new InvalidOperationException($"Option {customId} does not return a number.");

        return option switch
        {
            SliderOption slider =>
                SettingBase.TryGetSetting(player, slider.Id, out SliderSetting setting)
                    ? setting.SliderValue
                    : throw new Exception("Unexpected error while reading setting value."),
            _ => 0f
        };
    }

    /// <summary>
    /// Retrieves the current <see cref="bool"/> value of an option.
    /// </summary>
    /// <param name="player">The target player.</param>
    /// <param name="customId">The custom ID of an option.</param>
    /// <exception cref="ArgumentException">
    /// Thrown if the option does not exist.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    /// Thrown when the requested option does not return <see cref="bool"/>.
    /// </exception>
    public static bool GetBooleanValue(Player player, string customId)
    {
        if (!_allOptions.TryGetFirst(o => o.CustomId == customId, out var option))
            throw new ArgumentException($"An option with custom id {customId} was not found.");

        if (option.ReturnableType != OptionValueType.Boolean)
            throw new InvalidOperationException($"Option {customId} does not return a boolean.");

        return option switch
        {
            TwoButtonsOption twoButtons =>
                SettingBase.TryGetSetting(player, twoButtons.Id, out TwoButtonsSetting setting)
                    ? setting.IsFirst
                    : throw new Exception("Unexpected error while reading setting value."),
            _ => false
        };
    }
    
    /// <summary>
    /// Builds a list of <see cref="SettingBase"/> from an <see cref="OptionNode"/>.
    /// </summary>
    /// <param name="node">An option node.</param>
    /// <returns>Built <see cref="SettingBase"/> list.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the option node is null.</exception>
    private static IEnumerable<SettingBase> BuildSettingsList(OptionNode node)
    {
        if (node is null)
            throw new ArgumentNullException(nameof(node));

        List<SettingBase> settings = new() { node.ToBase() };

        foreach (IOption option in node.Options)
        {
            int id = OptionIdentifiersRegistry.Register(option.CustomId);
            option.Id = id;
            settings.Add(option.ToBase());
        }

        _allOptions.AddRange(node.Options);
        return settings;
    }

    /// <summary>
    /// Gets a list of <see cref="SettingBase"/> registered from an <see cref="OptionNode"/>.
    /// </summary>
    /// <param name="node">Tree node with options.</param>
    /// <returns>Built <see cref="SettingBase"/> list.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the option node is null.</exception>
    private static IEnumerable<SettingBase> GetSettingsList(OptionNode node)
    {
        if (node is null)
            throw new ArgumentNullException(nameof(node));

        return (from option in node.Options select _allOptions.Find(o => o.CustomId == option.CustomId)
            into found where found != null select found.ToBase()).Append(node.ToBase());
    }
}