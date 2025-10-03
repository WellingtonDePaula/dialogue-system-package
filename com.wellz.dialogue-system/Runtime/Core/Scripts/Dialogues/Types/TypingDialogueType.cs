using Unity.VisualScripting;
using UnityEngine;

public class TypingDialogueType : DialogueType {
    private string _currentContent;
    private int _lastIndex = 0;

    private float _cooldown = 0;

    private float _currentVelocity = 0;

    TypingNode _node;
     
    public TypingDialogueType(DialogueUI ui, TypingNode node) : base(ui) {
        _node = node;
        _currentVelocity = _node.typingSpeed;
        StartNode();
    }

    public override void RefreshUI() {
        if (_lastIndex == _node.dialogueContent.Length) {
            _currentContent = _node.dialogueContent.Substring(0, _lastIndex);
            _ui.Setup(_currentContent);
            _canPass = true;
            return;
        }

        _currentContent = _node.dialogueContent.Substring(0, _lastIndex);
        _ui.Setup(_currentContent);

        _lastIndex = Mathf.Min(_lastIndex + 1, _node.dialogueContent.Length);
        
        _canPass = false;
    }

    public override void StartNode() {
        _lastIndex = 0;

        _currentContent = "";
        string speakerName = _node.speakerName;
        Sprite speakerIcon = _node.speakerIcon;

        _ui.Setup(_currentContent, speakerName, speakerIcon);
        _canPass = false;

        //_cooldown = _node.typingSpeed;

        _cooldown = _currentVelocity;
    }

    public override void Update() {
        if (!_canPass) {
            if (_cooldown <= 0) {
                RefreshUI();
                _cooldown = _currentVelocity;
            } else {
                _cooldown -= Time.deltaTime;
            }
        }
    }

    public void SetTypingSpeed(bool isSkipping) {
        _currentVelocity = isSkipping ? _node.skipSpeed : _node.typingSpeed;
    }
}
