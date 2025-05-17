# Yassa ![Downloads](https://img.shields.io/github/downloads/bladuk/Yassa/total.svg)
Yet another server-specific settings API wrapper for EXILED.

## Key Features
- Fluent builders for all option types enables declarative configuration through method chaining, making settings definitions both readable and maintainable.
- Numeric IDs have been replaced with human-readable string IDs to eliminate the magic numbers. The `OptionIdentifiersRegistry` ensures that persistent numeric IDs are mapped correctly, maintaining stability across server restarts.
- Seamless integration with other EXILED plugins that using SSS.

## Usage Example
Here's an example of how to register settings using Yassa

```csharp
OptionNode node = new OptionNodeBuilder()
    .SetHeader("My honest option node")
    .SetHint("Option node hint")
    .AddTextInputOption(o => o
        .SetCustomId("YourPlugin.NicknameContent")
        .SetLabel("Custom Nickname")
        .SetCharacterLimit(50)
        .SetPlaceholder("Your nickname here..."))
    .AddButtonOption(o => o
        .SetCustomId("YourPlugin.Confirm")
        .SetLabel("Save Changes")
        .SetText("Confirm")
        .OnClicked(OnConfirmButtonClicked))
    .Build();

OptionsService.Register(node);

private void OnConfirmButtonClicked(Player player, ButtonOption button)
{
    player.CustomName = OptionsService.GetStringValue(player, "YourPlugin.NicknameContent");
}
```

Check out `Yassa.Test` for complete implementation examples.
