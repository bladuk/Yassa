using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Exiled.API.Features;

namespace Yassa.Features;

/// <summary>
/// Persists a one-to-one mapping between custom IDs and numeric IDs. This class cannot be inherited.
/// </summary>
public static class OptionIdentifiersRegistry
{
    /// <summary>
    /// Path of the text file that stores the mapping.
    /// </summary>
    private static readonly string _registryPath =
        Path.Combine(Paths.Configs, "YassaCache", $"CustomIdRegistry-{Server.Port}.txt");

    /// <summary>
    /// In-memory CustomID to ID lookup table.
    /// </summary>
    private static readonly Dictionary<string, int> _map =
        new(StringComparer.Ordinal);

    /// <inheritdoc cref="OptionIdentifiersRegistry" />
    static OptionIdentifiersRegistry()
    {
        Log.Debug("[OptionIdentifiersRegistry] Initialising.");

        Directory.CreateDirectory(Path.GetDirectoryName(_registryPath)!);

        if (!File.Exists(_registryPath))
            File.Create(_registryPath).Dispose();

        foreach (var line in File.ReadAllLines(_registryPath))
        {
            if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#"))
                continue;

            string[] parts = line.Split('=');
            
            if (parts.Length != 2 || !int.TryParse(parts[1], out int id))
            {
                Log.Warn($"[OptionIdentifiersRegistry] Skipping malformed line \"{line}\".");
                continue;
            }

            _map[parts[0]] = id;
        }

        Log.Debug($"[OptionIdentifiersRegistry] Loaded {_map.Count} custom IDs.");
    }

    /// <summary>
    /// Returns the numeric ID for <paramref name="customId"/> if already known;
    /// otherwise creates and stores a new one.
    /// </summary>
    /// <param name="customId">Unique string identifier of the option.</param>
    internal static int Register(string customId)
    {
        if (_map.TryGetValue(customId, out int existing))
            return existing;

        int numericId = Yassa.Singleton.Nonce.GenerateNew();

        // Ensure uniqueness among previously stored IDs.
        while (_map.ContainsValue(numericId))
            numericId = Yassa.Singleton.Nonce.GenerateNew();

        _map[customId] = numericId;
        Write();
        return numericId;
    }

    /// <summary>
    /// Retrieves the numeric ID for a given <paramref name="customId"/>.
    /// </summary>
    /// <param name="customId">The string custom ID of an option.</param>
    public static int Get(string customId) => _map[customId];

    /// <summary>
    /// Attempts to get the numeric ID for <paramref name="customId"/>.
    /// </summary>
    /// <param name="customId">Custom ID of an option.</param>
    /// <param name="id">Found numeric ID of an option.</param>
    /// <returns>True if option is found; otherwise false.</returns>
    public static bool TryGet(string customId, out int id) =>
        _map.TryGetValue(customId, out id);

    /// <summary>
    /// Retrieves the custom string ID for a given numeric <paramref name="id"/>.
    /// </summary>
    /// <exception cref="KeyNotFoundException">Thrown when no matching entry exists.</exception>
    public static string Get(int id)
    {
        foreach (var kvp in _map.Where(kvp => kvp.Value == id))
            return kvp.Key;

        throw new KeyNotFoundException($"No custom ID found for numeric ID {id}");
    }

    /// <summary>
    /// Attempts to retrieve the custom string ID that corresponds to
    /// <paramref name="id"/>.
    /// </summary>
    public static bool TryGet(int id, out string customId)
    {
        foreach (var kvp in _map.Where(kvp => kvp.Value == id))
        {
            customId = kvp.Key;
            return true;
        }

        customId = string.Empty;
        return false;
    }

    /// <summary>
    /// Writes the current mapping in <c>key=value</c> format.
    /// </summary>
    private static void Write() =>
        File.WriteAllLines(_registryPath, _map.Select(kvp => $"{kvp.Key}={kvp.Value}"));
}