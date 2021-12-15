using UnityEngine;

public abstract class GameFunctionListener<T> : MonoBehaviour
{
    [Tooltip("Event to register with")]
    public GameFunction<T> Event;

    private void OnEnable() => Event.RegisterListener(this);

    private void OnDisable() => Event.UnregisterListener(this);

    public abstract void OnEventRaised(T updateContent);
}
