using System;
using UnityEngine;

public abstract class DialogueType {
    protected int _currentNode;

    protected DialogueUI _ui;

    protected bool _canPass = false;

    public bool CanPass { get => _canPass; }

    public DialogueType(DialogueUI ui) {
        _ui = ui;
    }

    public abstract void Update();

    public abstract void RefreshUI();

    public abstract void StartNode();
}
