using UnityEngine;
using UnityEngine.Events;

public class GameOverListener : GameFunctionListener<bool>
{
    [SerializeField] UnityEvent<bool> OnGameOver;
    public override void OnEventRaised(bool updateContent)
    {
        OnGameOver.Invoke(updateContent);
    }
}
