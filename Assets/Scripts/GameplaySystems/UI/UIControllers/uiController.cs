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
    //--


    //player object to refer to public variables
     private GameObject _PlayerObj;
     private InventoryController _Inventory;
    //--

    //text boxes
    [SerializeField] private GameObject _TextBoxUI;
    [HideInInspector]public GameObject _NpcGameObject;
    [HideInInspector]public bool _TalkToNPC;

    //trading vars
    [HideInInspector] public bool _IsTrading;
    [SerializeField] private GameObject _TradeUI;



    //to ensure only 1 UI is ever created
    private static uiController instance = null;
    //--

    //lockout interaction
    private float _InteractLockout;
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

        _PlayerObj = GameObject.Find("Player");
        //--
    }

    void Start()
    { 
        _Inventory = _PlayerObj.GetComponent<InventoryController>();
        _NpcGameObject = null;
        _MoneyValueUI = GameObject.Find("MoneyValueTextUI").GetComponent<TextMeshProUGUI>();

        

        _PauseUI.SetActive(false);
        _PauseOverlay.SetActive(false);

        //_TextBoxUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (_PlayerObj.GetComponent<PlayerControls>()._Pause.triggered)
            {
            if (!_IsTrading || !_TalkToNPC) { PauseGame(); }
            else if (_IsTrading)
            {
                _TradeUI.GetComponent<MerchantUIController>().EndTrade();
                _PlayerObj.GetComponent<PlayerControls>()._Paused = false;
                _PauseOverlay.SetActive(false);
            }
            }

        if(_TalkToNPC && _PlayerObj.GetComponent<PlayerControls>()._Interact.triggered)
        {
            _TextBoxUI.GetComponent<TextBoxController>().AdvanceOnInput();
        }

        if(_InteractLockout >= 0)
        {
            _InteractLockout -= 1 * Time.deltaTime;
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

            _MoneyUI.SetActive(false);
            _PauseUI.SetActive(true);
            _PauseOverlay.SetActive(true);
        }
    }

    public void TalkUI()
    {
        _TextBoxUI.GetComponent<TextBoxController>()._NpcGameObject = _NpcGameObject;
        if (!_TalkToNPC && _InteractLockout <= 0)
        {
            _TextBoxUI.GetComponent<TextBoxController>().StartDialogue();
            _PauseOverlay.SetActive(true);
            _PlayerObj.GetComponent<PlayerControls>()._Paused = true;
            Debug.Log("Begin dialogue");
            _TalkToNPC = true;
            
        }
        else if (_TalkToNPC)
        {
            _InteractLockout = 1;
        
            _PauseOverlay.SetActive(false);
            _PlayerObj.GetComponent<PlayerControls>()._Paused = false;


            _TalkToNPC = false;
        }
    }
}
