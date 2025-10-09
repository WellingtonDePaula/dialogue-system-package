using UnityEngine;

[CreateAssetMenu(fileName = "NewTDialog", menuName = "Dialogue/Nodes/Typing", order = 1)]
public class TypingNode : DialogueNode {
    [Tooltip("Text typing speed (characters per second)")]
    [Min(0)] public float typingSpeed = 0.1f;
    [Tooltip("Skip text typing speed (characters per second).")]
    [Min(0)]public float skipSpeed = 0.01f;

    public override DialogueType CreateBehaviour(DialogueUI ui) {
        return new TypingDialogueType(ui, this);
    }
}
