using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Event bus that allows for event registration, unregistration, and triggering.
/// </summary>
public class EventBus : MonoBehaviour
{
    private readonly Dictionary<Type, HashSet<Delegate>> eventListeners = new();

    /// <inheritdoc/>
    public void RegisterListener<T>(Action<T> listener) where T : IEventParameter
    {
        Type eventType = typeof(T);
        if (!eventListeners.TryGetValue(eventType, out HashSet<Delegate> listeners))
        {
            listeners = new HashSet<Delegate>();
            eventListeners.Add(eventType, listeners);
        }

        listeners.Add(listener);
    }

    /// <inheritdoc/>
    public void UnregisterListener<T>(Action<T> listener) where T : IEventParameter
    {
        Type eventType = typeof(T);
        if (eventListeners.TryGetValue(eventType, out HashSet<Delegate> listeners))
        {
            listeners.Remove(listener);
        }
    }

    /// <inheritdoc/>
    public void TriggerEvent<T>(T eventParams) where T : IEventParameter
    {
        Type eventType = typeof(T);
        if (eventListeners.TryGetValue(eventType, out HashSet<Delegate> listeners))
        {
            foreach (var listener in listeners)
            {
                ((Action<T>)listener)?.Invoke(eventParams);
            }
        }
    }
}
