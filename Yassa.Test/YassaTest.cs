using System;
using Exiled.API.Features;
using UnityEngine;
using UserSettings.ServerSpecific;
using Yassa.Enums;
using Yassa.Features;
using Yassa.Features.Builders;
using Yassa.Interfaces;
using Yassa.Models;

namespace Yassa.Test;

internal class YassaTest : Plugin<Config>
{
    public override string Prefix => "yassa_test";
    
    public override string Name => "YassaTest";
    
    public override string Author => "bladuk.";
    
    public override Version Version { get; } = new(1, 0, 0);
    
    public override Version RequiredExiledVersion { get; } = new(9, 6, 0);
    
    public override void OnEnabled()
    {
        OptionNode node = new OptionNodeBuilder()
            .SetHeader("Test Option Node")
            .SetHint("Test option node hint")
            .SetPadding(true)
            .AddDropdownOption(o => o
                .SetCustomId("TestDropdown")
                .SetLabel("Test Dropdown")
                .SetHint("Test dropdown hint")
                .AppendOption("Option 1")
                .AppendOption("Option 2")
                .AppendOption("Option 3")
                .SetDefaultOption(1)
                .OnValueReceived(OnValueReceivedGeneric))
            .AddKeybindOption(o => o
                .SetCustomId("TestKeybind")
                .SetLabel("Test Keybind")
                .SetHint("Test keybind hint")
                .SetKeyCode(KeyCode.RightAlt)
                .SetIsInteractionPreventedOnGui(true)
                .OnPressed(OnClickedGeneric))
            .AddSliderOption(o => o
                .SetCustomId("TestSlider")
                .SetLabel("Test Slider")
                .SetHint("Test slider hint")
                .SetMinValue(0)
                .SetMaxValue(100)
                .SetDefaultValue(15)
                .SetDisplayFormat("{0}%")
                .OnValueReceived(OnValueReceivedGeneric))
            .AddTextAreaOption(o => o
                .SetCustomId("TestTextArea")
                .SetLabel("Test Text Area")
                .SetHint("Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. " +
                         "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor " +
                         "in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in " +
                         "culpa qui officia deserunt mollit anim id est laborum.")
                .SetFoldoutMode(SSTextArea.FoldoutMode.ExtendedByDefault))
            .AddTextInputOption(o => o
                .SetCustomId("TestTextInput")
                .SetLabel("Test Text Input")
                .SetHint("Test text input hint")
                .SetCharacterLimit(20)
                .SetPlaceholder("Me when...")
                .OnValueReceived(OnValueReceivedGeneric))
            .AddTwoButtonsOption(o => o
                .SetCustomId("TestTwoButtons")
                .SetLabel("Test Two Buttons")
                .SetHint("Test two buttons hint")
                .SetFirstOption("A")
                .SetSecondOption("B")
                .SetIsSecondDefault(true)
                .OnValueReceived(OnValueReceivedGeneric))
            .AddButtonOption(o => o
                .SetCustomId("TestButton")
                .SetLabel("Test Button")
                .SetHint("Test button hint")
                .SetText("Submit")
                .OnClicked(OnSubmitButtonClicked))
            .Build();
        
        OptionsService.Register(node);
        
        base.OnEnabled();
    }

    private void OnClickedGeneric(Player player, IOption clickable)
    {
        Log.Info($"Clickable option {clickable.CustomId} ({clickable.Id}) clicked by {player.Nickname}!");
    }

    private void OnValueReceivedGeneric(Player player, IOption receiver)
    {
        Log.Info($"Value for option {receiver.CustomId} ({receiver.Id}) has been received for {player.Nickname}!");

        switch (receiver.ReturnableType)
        {
            case OptionValueType.Number:
                Log.Info($"Number value is {OptionsService.GetNumberValue(player, receiver.CustomId)}");
                break;
            case OptionValueType.String:
                Log.Info($"String value is {OptionsService.GetStringValue(player, receiver.CustomId)}");
                break;
            case OptionValueType.Boolean:
                Log.Info($"Boolean value is {OptionsService.GetBooleanValue(player, receiver.CustomId)}");
                break;
        }
    }
    
    private void OnSubmitButtonClicked(Player player, ButtonOption button)
    {
        Log.Info($"Button {button.CustomId} ({button.Id}) clicked by {player.Nickname}!");
        
        Log.Info($"Values:\n" +
                 $"TestDropdown: {OptionsService.GetStringValue(player, "TestDropdown")}\n" +
                 $"TestSlider: {OptionsService.GetNumberValue(player, "TestSlider")}\n" +
                 $"TestTextInput: {OptionsService.GetStringValue(player, "TestTextInput")}\n" +
                 $"TestTwoButtons: {OptionsService.GetBooleanValue(player, "TestTwoButtons")}");
    }
}