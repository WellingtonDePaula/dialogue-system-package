using UnityEngine;
using UnityEngine.Events;

public abstract class GameEventGeneric<T> : ScriptableObject {
    private UnityAction<T> onEventRaised;

    public void Raise(T data) {
        onEventRaised?.Invoke(data);
    }

    public void RegisterListener(UnityAction<T> action) {
        onEventRaised += action;
    }

    public void UnregisterListener(UnityAction<T> action) {
        onEventRaised -= action;
    }
}