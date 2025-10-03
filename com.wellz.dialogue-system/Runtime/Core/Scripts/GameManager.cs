using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField] private GameEvent _dialogueEnterEvent;
    [SerializeField] private GameEvent _dialogueExitEvent;
    public void PauseGame() {
        Debug.Log("Game Paused");
    }
    public void ResumeGame() {
        Debug.Log("Game resumed");
    }

    private void OnEnable() {
        #region Enter Event

        _dialogueEnterEvent.RegisterListener(PauseGame);

        #endregion

        #region Exit Event

        _dialogueExitEvent.RegisterListener(ResumeGame);

        #endregion
    }
    private void OnDisable() {
        #region Enter Event

        _dialogueEnterEvent.UnregisterListener(PauseGame);

        #endregion

        #region Exit Event

        _dialogueExitEvent.UnregisterListener(ResumeGame);

        #endregion
    }
}
