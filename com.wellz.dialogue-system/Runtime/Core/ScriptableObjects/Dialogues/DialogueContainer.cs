using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewContainer", menuName = "Dialogue/Container", order = 1)]
public class DialogueContainer : ScriptableObject {
    [Header("Action Events (Optional)")]
    [SerializeField] private List<GameEvent> _onEnterEvent;
    [SerializeField] private List<GameEvent> _onExitEvent;

    [Header("All dialogues nodes")]
    public List<DialogueNode> allDialogs;

    public void OnEnterEvent() {
        foreach (GameEvent e in _onEnterEvent) {
            e.Raise();
        }
    }
    public void OnExitEvent() {
        foreach (GameEvent e in _onExitEvent) {
            e.Raise();
        }
    }
}
