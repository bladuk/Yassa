namespace Yassa.Enums;

/// <summary>
/// Indicates the runtime data type returned by an option.
/// </summary>
public enum OptionValueType : byte
{
    /// <summary>No value is sent back.</summary>
    None,

    /// <summary>A string value.</summary>
    String,

    /// <summary>A float number.</summary>
    Number,

    /// <summary>A boolean value.</summary>
    Boolean
}