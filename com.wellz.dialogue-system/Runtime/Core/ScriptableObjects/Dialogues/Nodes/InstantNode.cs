using UnityEngine;

[CreateAssetMenu(fileName = "NewDialog", menuName = "Dialog/Nodes/Instant", order = 1)]
public class InstantNode : DialogueNode {
    public override DialogueType CreateBehaviour(DialogueUI ui) {
        return new InstantDialogueType(ui, this);
    }
}
