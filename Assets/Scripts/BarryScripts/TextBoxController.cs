using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class TextBoxController : MonoBehaviour
{
    public NpcObj _NpcObj;
    

    [SerializeField] private GameObject _DialogueBox;
    [SerializeField] private Image _DialogueSprite;
    [SerializeField] private TextMeshProUGUI _DialogueField;
    [SerializeField] private GameObject _UiControl;

    private int _TextStep = 0;
    private int _TextPages = 0;

    [SerializeField] private GameObject _NpcSprite;
    [SerializeField] private GameObject _TextBack;
    [SerializeField] private GameObject _TextScript;

    private bool _FirstLinePrinted;


    public void StartDialogue()
    {
        _NpcSprite.SetActive(true);
        _TextBack.SetActive(true);
        _TextScript.SetActive(true);
        
        _NpcSprite.GetComponent<Image>().sprite = _NpcObj._NpcTalkSprite[0];
        
        _TextPages = _NpcObj._NpcDialogue.Length;
        WriteDialogue();
    }

    public void EndDialogue()
    {
        _NpcSprite.SetActive(false);
        _TextBack.SetActive(false);
        _TextScript.SetActive(false);
        _UiControl.GetComponent<uiController>().TalkUI();
        _FirstLinePrinted = false;
        _TextStep = 0;
    }

    public void WriteDialogue()
    {
        Debug.Log(_TextStep);
        Debug.Log(_TextPages);
        //switch case to determine what type of text the npc is about to give you
        switch (_NpcObj._DialogueType)
        {
            //Case for ambient dialogue
            case 0:
                //this case will simply display a text box until the player progress through it **note; add gradual text reveal
                if (_TextStep < _TextPages)
                {
                    _DialogueField.text = _NpcObj._NpcDialogue[_TextStep];
                }
                else if (_TextStep <= _TextPages)
                {
                    EndDialogue();
                }
                else
                {
                    Debug.Log("Something broke; Text step error");
                    gameObject.SetActive(false);
                }


                break;

            //Case for dialogue that leads into trading
            case 1:
                //this case will display a text box and lead to a dialogue option to trade; then either bring up the trading screen or return to gameplay
                if (_TextStep <= _TextPages)
                {
                    _DialogueField.text = _NpcObj._NpcDialogue[_TextStep];
                }
                else if (_TextStep <= _TextPages)
                {
                    EndDialogue();
                }
                else
                {
                    Debug.Log("Something broke; Text step error");
                    gameObject.SetActive(false);
                }
                



                break;
            //Case for dialogue that sets a flag
            case 2:
                //this case is for npcs that will give the player a quest, or set other flags, when spoken to
                if (_TextStep <= _TextPages)
                {
                    _DialogueField.text = _NpcObj._NpcDialogue[_TextStep];
                }
                else if (_TextStep <= _TextPages)
                {
                    EndDialogue();
                }
                else
                {
                    Debug.Log("Something broke; Text step error");
                    gameObject.SetActive(false);
                }


                break;

            //default case if the int is invalid
            default:
                Debug.Log("Something went wrong with NPC Dialogue Type");
                break;
        }
    }

    public void AdvanceOnInput()
    {
        if (_FirstLinePrinted)
        {
            _TextStep++;
            WriteDialogue();
        }
        else
        {
            _FirstLinePrinted = true;
        }
    }


}
