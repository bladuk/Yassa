using Exiled.API.Features;
using UserSettings.ServerSpecific;
using Yassa.Features;
using Yassa.Interfaces;

namespace Yassa;

internal sealed class EventHandlers
{
    internal void OnServerSettingValueReceived(ReferenceHub hub, ServerSpecificSettingBase setting)
    {
        IOption option = OptionsService.Get(setting.SettingId);

        if (option is not IValueReceiver receiver)
            return;

        receiver.OnValueReceived?.Invoke(Player.Get(hub), option);
    }
}