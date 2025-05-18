// ReSharper disable MemberCanBePrivate.Global

using System.Collections.Generic;
using Exiled.API.Features.Core.UserSettings;
using Yassa.Interfaces;

namespace Yassa.Models;

/// <summary>
/// Represents a container that groups several options under a header. This class cannot be inherited.
/// </summary>
public sealed class OptionNode : IValidatable
{
    /// <summary>
    /// Initializes a new instance with default values.
    /// </summary>
    public OptionNode() : this("Default string") { }

    /// <summary>
    /// Initializes a new instance of the <see cref="OptionNode"/> class.
    /// </summary>
    /// <param name="header">Text header displayed above the group.</param>
    /// <param name="hint">Optional explanatory text shown right to the header.</param>
    /// <param name="padding">Whether to reduce padding.</param>
    public OptionNode(string header, string hint = null, bool padding = false)
    {
        Header = header;
        Hint = hint;
        Padding = padding;
    }
    
    /// <summary>
    /// Gets the cached <see cref="HeaderSetting"/> instance once built.
    /// </summary>
    public HeaderSetting Base { get; internal set; }

    /// <summary>
    /// Gets or sets the header text.
    /// </summary>
    public string Header { get; set; }

    /// <summary>
    /// Gets or sets an optional hint text.
    /// </summary>
    public string Hint { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to reduce padding.
    /// </summary>
    public bool Padding { get; set; }

    /// <summary>
    /// Gets or sets the list of child options contained in this node.
    /// </summary>
    public List<IOption> Options { get; set; } = new();
    
    /// <summary>
    /// Converts <see cref="OptionNode"/> into <see cref="HeaderSetting"/>.
    /// </summary>
    public HeaderSetting ToBase() =>
        Base ??= new HeaderSetting(Header, Hint, Padding);

    /// <inheritdoc/>
    public bool Validate() =>
        !string.IsNullOrWhiteSpace(Header);
}