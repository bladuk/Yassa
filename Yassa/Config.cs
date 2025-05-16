using System.ComponentModel;
using Exiled.API.Interfaces;

namespace Yassa;

internal sealed class Config : IConfig
{
    [Description("Is the plugin enabled?")]
    public bool IsEnabled { get; set; } = true;

    [Description("Should debug messages be printed in the server console?")]
    public bool Debug { get; set; } = false;
}