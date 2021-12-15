using UnityEngine;
using UnityEngine.Events;

public class NewBlockListener : GameActionListener
{
    [SerializeField] UnityEvent OnBlockSpawned;
    public override void OnEventRaised()
    {
        OnBlockSpawned.Invoke();
    }
}