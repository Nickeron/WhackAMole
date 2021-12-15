using UnityEngine;

public abstract class GameActionListener : MonoBehaviour
{
    [Tooltip("Event to register with")]
    public GameAction Event;

    private void OnEnable() => Event.RegisterListener(this);

    private void OnDisable() => Event.UnregisterListener(this);

    public abstract void OnEventRaised();
}
