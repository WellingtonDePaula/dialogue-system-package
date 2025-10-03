using UnityEngine;

public class SoundManager : MonoBehaviour {
    [SerializeField] private GameEvent _onNodeEntrySound;

    public void PlaySound() {
        Debug.Log("Som tocado");
    }

    private void OnEnable() {
        #region Node Enter Event

        _onNodeEntrySound.RegisterListener(PlaySound);

        #endregion
    }
    private void OnDisable() {
        #region Node Enter Event

        _onNodeEntrySound.UnregisterListener(PlaySound);

        #endregion
    }
}
