using System;
using UnityEngine;

public class PlayerInputReader : MonoBehaviour {
    [Header("Dialogue Input Events")]
    [SerializeField] private GameEvent _nextDialogueEvent;
    [SerializeField] private GameEvent _skipStartedEvent;
    [SerializeField] private GameEvent _skipCanceledEvent;

    private PlayerControls _controls;

    private void Awake() {
        _controls = new PlayerControls();

        _controls.UI.NextDialogueNode.performed += ctx => {
            if (_nextDialogueEvent != null) _nextDialogueEvent.Raise();
        };

        _controls.UI.SkipDialogueNode.performed += ctx => {
            if (_skipStartedEvent != null) _skipStartedEvent.Raise();
        };

        _controls.UI.SkipDialogueNode.canceled += ctx => {
            if (_skipCanceledEvent != null) _skipCanceledEvent.Raise();
        };
    }

    private void OnEnable() {
        _controls.UI.Enable();
    }

    private void OnDisable() {
        _controls.UI.Disable();
    }
}