using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBus : MonoBehaviour
{
    private readonly Dictionary<Type, List<IEventListener>> eventListeners = new();

    public void RegisterListener<T>(IEventListener listener) where T : IEventParameter
    {
        Type eventType = typeof(T);
        if (!eventListeners.TryGetValue(eventType, out List<IEventListener> listeners))
        {
            eventListeners.Add(eventType, new List<IEventListener>());
        }

        eventListeners[eventType].Add(listener);
    }

    public void UnregisterListener<T>(IEventListener listener) where T : IEventParameter
    {
        Type eventType = typeof(T);
        if (eventListeners.TryGetValue(eventType, out List<IEventListener> listeners))
        {
            listeners.Remove(listener);
        }
    }

    public void TriggerEvent<T>(T eventParams) where T : IEventParameter
    {
        Type eventType = typeof(T);
        if (eventListeners.TryGetValue(eventType, out List<IEventListener> listeners))
        {
            foreach (IEventListener listener in listeners)
            {
                listener.TriggerEvent(eventParams);
            }
        }
    }
}
