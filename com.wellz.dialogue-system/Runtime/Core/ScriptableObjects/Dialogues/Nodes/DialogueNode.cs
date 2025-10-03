using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class DialogueNode : ScriptableObject {
    [Header("Eventos de Ação (Opcional)")]
    [SerializeField] private List<GameEvent> _onEnterEvent;
    [SerializeField] private List<GameEvent> _onExitEvent;

    [Header("Conteúdo Principal")]
    [TextArea(3, 10)] public string dialogueContent;
    [Tooltip("Nome do ator da fala.")]
    public string speakerName;
    [Tooltip("Imagem do ator da fala.")]
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