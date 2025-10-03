using UnityEngine;

[CreateAssetMenu(fileName = "NewDialog", menuName = "Dialog/Nodes/Instant", order = 1)]
public class InstantNode : DialogueNode {
    public override DialogueType CreateBehaviour(DialogueUI ui) {
        // Passamos 'this' para que o comportamento tenha acesso aos dados específicos deste nó.
        return new InstantDialogueType(ui, this);
    }
}
