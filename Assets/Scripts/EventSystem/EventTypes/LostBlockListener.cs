using UnityEngine;
using UnityEngine.Events;

public class LostBlockListener : GameActionListener
{
    [SerializeField] UnityEvent OnBlockDestroyed;
    public override void OnEventRaised()
    {
        OnBlockDestroyed.Invoke();
    }
}
