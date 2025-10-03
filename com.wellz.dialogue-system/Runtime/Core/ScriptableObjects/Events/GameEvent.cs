using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Game Event", menuName = "Events/Game Event (Void)")]
public class GameEvent : ScriptableObject {
    private UnityAction onEventRaised;

    public void Raise() {
        onEventRaised?.Invoke();
    }

    public void RegisterListener(UnityAction action) {
        onEventRaised += action;
    }

    public void UnregisterListener(UnityAction action) {
        onEventRaised -= action;
    }
}