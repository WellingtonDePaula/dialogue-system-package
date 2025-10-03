using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour {
    [SerializeField] TMP_Text _dialogueContent;
    [SerializeField] TMP_Text _speakerName;
    [SerializeField] Image _speakerIcon;

    public void Setup(string dialogueContent, string speakerName, Sprite speakerIcon) {
        _dialogueContent.text = dialogueContent;
        _speakerName.text = speakerName;
        _speakerIcon.sprite = speakerIcon;
    }
    public void Setup(string dialogueContent) {
        _dialogueContent.text = dialogueContent;
    }
}
