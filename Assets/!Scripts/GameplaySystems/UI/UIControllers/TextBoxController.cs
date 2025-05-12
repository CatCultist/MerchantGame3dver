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

    private void Awake()
    {
        _QuestManager = GameObject.Find("Player").GetComponent<QuestManager>();
    }

    public void StartDialogue()
    {
        _FirstLinePrinted = false;
        _TextStep = 0;
        _NpcObj = _NpcGameObject.GetComponent<TalkNPC>()._NpcObj;
        Debug.Log("Start dialogue");
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
        Debug.Log("End dialogue");
        foreach (Transform _Child in gameObject.transform)
        {
            _Child.gameObject.SetActive(false);
        }
        /*
        _NpcSprite.SetActive(false);
        _TextBack.SetActive(false);
        _TextScript.SetActive(false);
        */
        Debug.Log(_UiControl.GetComponent<uiController>()._TalkToNPC);
        _UiControl.GetComponent<uiController>().TalkUI();

    }

    public void WriteDialogue()
    {
        Debug.Log(_TextStep);
        Debug.Log(_TextPages);

        //this case will simply display a text box until the player progress through it
        if (_TextStep < _TextPages)
        {
            _DialogueField.text = _NpcObj._NpcDialogue[_TextStep];
            
        }
        else if (_TextStep >= _TextPages && !_NpcObj._TradeAvailable)
        {
            
            _QuestManager.SetQuestFlag(1, 1);
            EndDialogue();
            return;

            
        }

        else if (_TextStep <= _TextPages && _NpcObj._TradeAvailable) 
        { BeginTrading(); return; }

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
        Debug.Log("Begin trade");

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
