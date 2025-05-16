// ReSharper disable MemberCanBePrivate.Global

using Exiled.API.Features.Core.UserSettings;
using Yassa.Enums;
using Yassa.Interfaces;

namespace Yassa.Models;

/// <summary>
/// Base class for every concrete option wrapper.
/// </summary>
/// <typeparam name="T">
/// Concrete <see cref="SettingBase"/> type produced by <see cref="BuildBase"/>.
/// </typeparam>
public abstract class OptionBase<T> : IOption where T : SettingBase
{
    /// <summary>
    /// Gets the cached <typeparamref name="T"/> instance once built.
    /// </summary>
    public abstract T Base { get; internal set; }

    /// <inheritdoc/>
    public abstract string CustomId { get; set; }

    /// <inheritdoc/>
    public virtual int Id { get; set; } = 0;

    /// <inheritdoc/>
    public abstract OptionValueType ReturnableType { get; }

    /// <inheritdoc/>
    public abstract string Label { get; set; }

    /// <inheritdoc/>
    public abstract string Hint { get; set; }

    /// <summary>
    /// Builds the concrete <typeparamref name="T"/> instance.
    /// </summary>
    protected abstract T BuildBase();

    /// <inheritdoc/>
    public SettingBase ToBase() =>
        Base ??= BuildBase();
}