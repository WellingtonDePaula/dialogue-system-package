using UnityEngine;

public class DialogueManager : MonoBehaviour {
    public static DialogueManager Instance;

    [SerializeField] GameObject _dialogueUIPrefab;
    [Tooltip("Canvas reference to instantiate the DialogueUI")]
    [SerializeField] Canvas _canvas;

    [Header("Input Listener Events")]
    [SerializeField] private GameEvent _onNextDialogueEvent;
    [SerializeField] private GameEvent _onSkipStartedEvent;
    [SerializeField] private GameEvent _onSkipCanceledEvent;

    DialogueType _dialogueType;
    DialogueUI _ui;

    DialogueContainer _currentContainer;
    int _currentNode = 0;

    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
        } else {
            Instance = this;
        }
    }

    private void OnEnable() {
        // Registra os listeners quando o objeto � ativado
        if (_onNextDialogueEvent != null) _onNextDialogueEvent.RegisterListener(HandleNextNodeInput);
        if (_onSkipStartedEvent != null) _onSkipStartedEvent.RegisterListener(HandleSkipStarted);
        if (_onSkipCanceledEvent != null) _onSkipCanceledEvent.RegisterListener(HandleSkipCanceled);
    }

    private void OnDisable() {
        // Remove os listeners para evitar memory leaks
        if (_onNextDialogueEvent != null) _onNextDialogueEvent.UnregisterListener(HandleNextNodeInput);
        if (_onSkipStartedEvent != null) _onSkipStartedEvent.UnregisterListener(HandleSkipStarted);
        if (_onSkipCanceledEvent != null) _onSkipCanceledEvent.UnregisterListener(HandleSkipCanceled);
    }

    private void Update() {
        if (_ui == null || _currentContainer == null || _dialogueType == null) { return; }
        _dialogueType.Update();
    }

    private void HandleNextNodeInput() {
        if (_ui == null || _currentContainer == null) { return; }

        if (_dialogueType.CanPass) {
            NextNode();
        }
    }

    private void NextNode() {
        DialogueNode node = _currentContainer.allDialogs[_currentNode];

        // Chamando os m�todos de sa�da do node
        node.OnExitEvent();

        // Acrescenta-se em 1 o node, avan�ando para o pr�ximo dialogo do container
        _currentNode += 1;

        // Fecha o dialogo caso todos os nodes tenham sido executados
        if (_currentNode >= _currentContainer.allDialogs.Count) {
            CloseDialogue();
            return;
        }
        node = _currentContainer.allDialogs[_currentNode];

        // Atribui o Type atual do node
        _dialogueType = node.CreateBehaviour(_ui);

        // Chamando os m�todos de entrada do node
        node.OnEnterEvent();
    }

    public void StartDialogue(DialogueContainer dialogue) {
        // Tenta fechar um di�logo existente para poder iniciar outro
        CloseDialogue();

        _currentContainer = dialogue;

        // Executa o evento de entrada de Di�logo (Container)
        _currentContainer.OnEnterEvent();

        _ui = Instantiate(_dialogueUIPrefab, _canvas.transform).GetComponent<DialogueUI>();

        DialogueNode node = _currentContainer.allDialogs[_currentNode];

        // Atribui o Type atual do node
        _dialogueType = node.CreateBehaviour(_ui);

        // Executa o evento de entrada de Node
        node.OnEnterEvent();
    }

    // Fecha o di�logo resetando tudo para o estado padr�o caso exista algum di�logo rodando
    private void CloseDialogue() {
        if (_ui != null) {
            // Executa o evento de sa�da de Di�logo (Container)
            _currentContainer.OnExitEvent();

            Destroy(_ui.gameObject);
        }

        _ui = null;
        _currentContainer = null;
        _currentNode = 0;
        _dialogueType = null;
    }

    private void HandleSkipStarted() {
        if (_dialogueType is TypingDialogueType typingDialogue) {
            typingDialogue.SetTypingSpeed(true);
        }
    }

    private void HandleSkipCanceled() {
        if (_dialogueType is TypingDialogueType typingDialogue) {
            typingDialogue.SetTypingSpeed(false);
        }
    }
}
