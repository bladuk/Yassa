namespace Yassa.Interfaces;

/// <summary>
/// Contract for an entity that can validate its own internal state.
/// </summary>
internal interface IValidatable
{
    /// <summary>
    /// Validates the current instance.
    /// </summary>
    /// <returns><see langword="true"/> if valid; otherwise, <see langword="false"/>.</returns>
    bool Validate();
}