using UnityEngine;
using Unity.VisualScripting;
using TMPro;

public class DialogueTextScript : MonoBehaviour
{
    public string _DialogueText;
    public int _SpeakerID;


    private int _DialogueTextLength;

    private TextMeshProUGUI _DialogueField;

    private void Awake()
    {
        _DialogueField = gameObject.GetComponent<TextMeshProUGUI>();
    }

    public void WriteDialogue()
    {

    }

}
