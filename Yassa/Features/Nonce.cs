using System.Collections.Generic;
using UnityEngine;

namespace Yassa.Features;

/// <summary>
/// Generates random 32-bit integers while guaranteeing no duplicates during the lifetime. This class cannot be inherited.
/// </summary>
internal sealed class Nonce
{
    /// <summary>
    /// Gets the set of numbers generated so far.
    /// </summary>
    internal readonly HashSet<int> UsedNumbers = new();

    /// <summary>
    /// Generates a new unique number.
    /// </summary>
    internal int GenerateNew()
    {
        int nonce = Random.Range(0, int.MaxValue);
        return !UsedNumbers.Add(nonce) ? GenerateNew() : nonce;
    }
}