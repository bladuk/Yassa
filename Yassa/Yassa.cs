using System;
using Exiled.API.Enums;
using Exiled.API.Features;
using HarmonyLib;
using UserSettings.ServerSpecific;
using Yassa.Features;

namespace Yassa;

internal class Yassa : Plugin<Config>
{
    public override string Prefix => "yassa";
    
    public override string Name => "Yassa";
    
    public override string Author => "bladuk.";
    
    public override Version Version { get; } = new(1, 0, 1);
    
    public override Version RequiredExiledVersion { get; } = new(9, 6, 0);

    public override PluginPriority Priority => PluginPriority.First;

    public static Yassa Singleton = new();

    internal Nonce Nonce;

    private Harmony _harmony;

    private EventHandlers _eventHandlers;
    
    public override void OnEnabled()
    {
        Singleton = this;
        _harmony = new($"{Author}.{Name}-{DateTime.Now.Ticks}");
        _harmony.PatchAll();
        _eventHandlers = new();
        Nonce = new();

        if (ServerSpecificSettingsSync.DefinedSettings != null)
        {
            foreach (var setting in ServerSpecificSettingsSync.DefinedSettings)
            {
                Nonce.UsedNumbers.Add(setting.SettingId);
                Log.Debug($"Added existing SSS with ID {setting.SettingId} ({setting.Label})");
            }
        }
        else
        {
            Log.Debug("No generic SSS found.");
        }
        
        RegisterEvents();
            
        base.OnEnabled();
    }

    public override void OnDisabled()
    {
        UnregisterEvents();
            
        base.OnDisabled();
    }

    private void RegisterEvents()
    {
        ServerSpecificSettingsSync.ServerOnSettingValueReceived += _eventHandlers.OnServerSettingValueReceived;
    }

    private void UnregisterEvents()
    {
        ServerSpecificSettingsSync.ServerOnSettingValueReceived -= _eventHandlers.OnServerSettingValueReceived;
    }
}