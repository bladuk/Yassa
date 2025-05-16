using System;
using Exiled.API.Features;

namespace Yassa.Interfaces;

/// <summary>
/// Supplies a callback that is invoked when a value is sent from the client to the server for this option.
/// </summary>
internal interface IValueReceiver
{
    /// <summary>
    /// Gets or sets the callback executed when the option’s value is received.
    /// </summary>
    Action<Player, IOption> OnValueReceived { get; set; }
}