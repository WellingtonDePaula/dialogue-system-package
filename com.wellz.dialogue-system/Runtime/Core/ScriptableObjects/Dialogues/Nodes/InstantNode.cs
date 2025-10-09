using UnityEngine;

[CreateAssetMenu(fileName = "NewIDialog", menuName = "Dialogue/Nodes/Instant", order = 1)]
public class InstantNode : DialogueNode {
    public override DialogueType CreateBehaviour(DialogueUI ui) {
        return new InstantDialogueType(ui, this);
    }
}
