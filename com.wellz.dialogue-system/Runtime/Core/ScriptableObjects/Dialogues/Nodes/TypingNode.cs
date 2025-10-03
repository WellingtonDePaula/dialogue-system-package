using UnityEngine;

[CreateAssetMenu(fileName = "NewDialog", menuName = "Dialog/Nodes/Typing", order = 1)]
public class TypingNode : DialogueNode {
    [Tooltip("Velocidade de digitação do texto (caracteres por segundo).")]
    [Min(0)] public float typingSpeed = 0.1f;
    [Tooltip("Velocidade de digitação do texto em skip (caracteres por segundo).")]
    [Min(0)]public float skipSpeed = 0.01f;

    public override DialogueType CreateBehaviour(DialogueUI ui) {
        return new TypingDialogueType(ui, this);
    }
}
