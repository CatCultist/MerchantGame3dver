using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using Unity.VisualScripting;
public class uiController : MonoBehaviour
{
    //game overlay
    [SerializeField] private GameObject _MoneyUI;
    private TextMeshProUGUI _MoneyValueUI;
    //--


    //pause screen
    [SerializeField] private GameObject _PauseOverlay;
    [SerializeField] private GameObject _PauseUI;
    private TextMeshProUGUI _FishValue;
    private TextMeshProUGUI _WheatValue;
    private TextMeshProUGUI _MoneyValuePause;
    private TextMeshProUGUI _DebtValue;
    //--


    //player object to refer to public variables
    [SerializeField] private GameObject _PlayerObj;
    [SerializeField] private InventoryController _Inventory;
    //--

    //text boxes
    [SerializeField] private GameObject _TextBoxUI;
    [HideInInspector]public GameObject _NpcGameObject;
    [HideInInspector]public bool _TalkToNPC;



    //to ensure only 1 UI is ever created
    private static uiController instance = null;
    //--

    private void Awake()
    {
        //avoid creating duplicates of UI object across scenes
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        //--
    }

    void Start()
    { 
        _Inventory = _PlayerObj.GetComponent<InventoryController>();
        _NpcGameObject = null;
        _MoneyValueUI = GameObject.Find("MoneyValueTextUI").GetComponent<TextMeshProUGUI>();

        
        _WheatValue = GameObject.Find("WheatValueText").GetComponent<TextMeshProUGUI>();
        _FishValue = GameObject.Find("FishValueText").GetComponent<TextMeshProUGUI>();
        _MoneyValuePause = GameObject.Find("MoneyValueTextPause").GetComponent<TextMeshProUGUI>();
        _DebtValue = GameObject.Find("DebtValueText").GetComponent<TextMeshProUGUI>();

        _PauseUI.SetActive(false);
        _PauseOverlay.SetActive(false);

        //_TextBoxUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (_PlayerObj.GetComponent<PlayerControls>()._Pause.triggered)
            {
            PauseGame();
            }

        if(_TalkToNPC && _PlayerObj.GetComponent<PlayerControls>()._Interact.triggered)
        {
            _TextBoxUI.GetComponent<TextBoxController>().AdvanceOnInput();
        }


        _MoneyValueUI.text = _Inventory._PlayerMoney.ToString();

    }

    void PauseGame()
    {
        if (_PauseUI.activeSelf == true)
        {   
            _MoneyUI.SetActive(true);
            _PauseOverlay.SetActive(false);
            _PauseUI.SetActive(false);

        }
        else
        {
            _MoneyValuePause.text = _Inventory._PlayerMoney.ToString();
            _DebtValue.text = "€1,000,000";

            _MoneyUI.SetActive(false);
            _PauseUI.SetActive(true);
            _PauseOverlay.SetActive(true);
        }
    }

    public void TalkUI()
    {
        _TextBoxUI.GetComponent<TextBoxController>()._NpcGameObject = _NpcGameObject;
        if (_TalkToNPC)
        {

            _PauseOverlay.SetActive(false);
            _PlayerObj.GetComponent<PlayerControls>()._Paused = false;

            _TalkToNPC = false;
        }
        else if (!_TalkToNPC)
        {
            
            _TextBoxUI.GetComponent<TextBoxController>().StartDialogue();
            _PauseOverlay.SetActive(true);
            _PlayerObj.GetComponent<PlayerControls>()._Paused = true;

            _TalkToNPC = true;
        }
    }
}
