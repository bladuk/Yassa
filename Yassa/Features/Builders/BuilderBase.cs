namespace Yassa.Features.Builders;

/// <summary>
/// Base class for all builders.
/// </summary>
public abstract class BuilderBase<T> where T : class, new()
{
    /// <summary>
    /// Gets the instance being configured.
    /// </summary>
    protected abstract T Product { get; }

    /// <summary>
    /// Finalizes the configuration and returns the product.
    /// </summary>
    public abstract T Build();
}