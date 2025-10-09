using System.Collections.Generic;
using UnityEngine;

public abstract class DialogueNode : ScriptableObject {
    [Header("Action Events (Optional)")]
    [SerializeField] private List<GameEvent> _onEnterEvent;
    [SerializeField] private List<GameEvent> _onExitEvent;

    [Header("Main dialogue content")]
    [TextArea(3, 10)] public string dialogueContent;
    [Tooltip("Name of the speech actor")]
    public string speakerName;
    [Tooltip("Image of the speech actor")]
    public Sprite speakerIcon;

    public abstract DialogueType CreateBehaviour(DialogueUI ui);

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