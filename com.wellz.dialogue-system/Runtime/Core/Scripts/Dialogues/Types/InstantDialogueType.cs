using UnityEngine;

public class InstantDialogueType : DialogueType {
    InstantNode _node;
    public InstantDialogueType(DialogueUI ui, InstantNode node) : base(ui) {
        _node = node;
        StartNode();
    }

    public override void Update() {}

    public override void RefreshUI() {
        string dialogueContent = _node.dialogueContent;
        string speakerName = _node.speakerName;
        Sprite speakerIcon = _node.speakerIcon;

        _ui.Setup(dialogueContent, speakerName, speakerIcon);

        _canPass = true;
    }

    public override void StartNode() {
        RefreshUI();
    }
}
