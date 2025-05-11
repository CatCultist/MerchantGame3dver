using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class TextBoxController : MonoBehaviour
{
    [SerializeField] MerchantUIController _MerchantUI;

    [HideInInspector] public GameObject _NpcGameObject;
    [HideInInspector] public NpcObj _NpcObj;





    [SerializeField] private GameObject _DialogueBox;
    [SerializeField] private Image _DialogueSprite;
    [SerializeField] private TextMeshProUGUI _DialogueField;
    [SerializeField] private GameObject _UiControl;

    private int _TextStep = 0;
    private int _TextPages = 0;

    [SerializeField] private GameObject _NpcSprite;

    [SerializeField] private GameObject _TextScript;

    private bool _FirstLinePrinted;

    private QuestManager _QuestManager;


    public void StartDialogue()
    {
        _NpcObj = _NpcGameObject.GetComponent<TalkNPC>()._NpcObj;

        foreach(Transform _Child in gameObject.transform)
        {
            _Child.gameObject.SetActive(true);
        }
        _NpcSprite.GetComponent<Image>().sprite = _NpcObj._NpcTalkSprite[0];

        _TextPages = _NpcObj._NpcDialogue.Length;
        WriteDialogue();
    }

    public void EndDialogue()
    {

        foreach (Transform _Child in gameObject.transform)
        {
            _Child.gameObject.SetActive(false);
        }
        /*
        _NpcSprite.SetActive(false);
        _TextBack.SetActive(false);
        _TextScript.SetActive(false);
        */
        _UiControl.GetComponent<uiController>().TalkUI();
        _FirstLinePrinted = false;
        _TextStep = 0;
    }

    public void WriteDialogue()
    {
        Debug.Log(_TextStep);
        Debug.Log(_TextPages);

        //this case will simply display a text box until the player progress through it
        if (_TextStep < _TextPages)
        {
            _DialogueField.text = _NpcObj._NpcDialogue[_TextStep];
            _QuestManager.SetQuestFlag(1, 1);
        }
        else if (_TextStep <= _TextPages && !_NpcObj._TradeAvailable)
        {
            EndDialogue();



            return;
        }

        else if (_TextStep <= _TextPages && _NpcObj._TradeAvailable) { BeginTrading(); return; }

        else
        {
            Debug.Log("Something broke; Text step error");
            gameObject.SetActive(false);
        }



    }


    public void BeginTrading()
    {
        foreach (Transform _Child in gameObject.transform)
        {
            _Child.gameObject.SetActive(false);
        }

        _MerchantUI._NpcGameObject = _NpcGameObject;
        /*
        _NpcSprite.SetActive(false);
        _TextBack.SetActive(false);
        _TextScript.SetActive(false);
        */
        _MerchantUI.StartTrading();
        _TextStep = 0;
        _FirstLinePrinted = false;

    }
    public void AdvanceOnInput()
    {
        if (_FirstLinePrinted && _TextStep < _TextPages)
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
