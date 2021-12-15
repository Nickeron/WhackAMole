using System.Collections.Generic;

using UnityEngine;

public class GameFunction<T> : ScriptableObject
{
    protected readonly List<GameFunctionListener<T>> eventListeners = new();

    public void Raise(T updateContent)
    {
        for (int i = eventListeners.Count - 1; i >= 0; i--)
        {
            eventListeners[i].OnEventRaised(updateContent);
        }
    }

    public void RegisterListener(GameFunctionListener<T> listener)
    {
        //Debug.Log($"Subscribing listener {listener.name} to {name}");
        if (eventListeners.Contains(listener)) return;

        eventListeners.Add(listener);
    }

    public void UnregisterListener(GameFunctionListener<T> listener)
    {
        if (!eventListeners.Contains(listener)) return;

        eventListeners.Remove(listener);
    }
}

public class RandomFunc<T> : GameFunction<T>
{
    public new void Raise(T updateContent) => eventListeners[Random.Range(0, eventListeners.Count)].OnEventRaised(updateContent);
}
