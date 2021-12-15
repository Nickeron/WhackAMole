using System.Collections.Generic;

using UnityEngine;

public class GameAction : ScriptableObject
{
    protected readonly List<GameActionListener> eventListeners = new();

    public void Raise()
    {
        for (int i = eventListeners.Count - 1; i >= 0; i--)
        {
            eventListeners[i].OnEventRaised();
        }
    }

    public void RegisterListener(GameActionListener listener)
    {
        if (eventListeners.Contains(listener)) return;

        eventListeners.Add(listener);
    }

    public void UnregisterListener(GameActionListener listener)
    {
        if (!eventListeners.Contains(listener)) return;

        eventListeners.Remove(listener);
    }
}

public class RandomAction : GameAction
{
    public new void Raise() => eventListeners[Random.Range(0, eventListeners.Count)].OnEventRaised();
}
