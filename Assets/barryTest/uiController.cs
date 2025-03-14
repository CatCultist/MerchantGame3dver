using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using Unity.VisualScripting;
public class uiController : MonoBehaviour
{
    //game overlay
    private GameObject _MoneyUI;
    private TextMeshProUGUI _MoneyValueUI;

    //pause screen
    private GameObject _PauseUI;
    private TextMeshProUGUI _FishValue;
    private TextMeshProUGUI _WheatValue;
    private TextMeshProUGUI _MoneyValuePause;
    private TextMeshProUGUI _DebtValue;

    //player object to refer to public variables
    private GameObject _PlayerObj;
    private InventoryController _Inventory;
    

    void Start()
    {
        _PlayerObj = GameObject.Find("Player");
        _Inventory = _PlayerObj.GetComponent<InventoryController>();

        _MoneyUI = GameObject.Find("MoneyUIParent");
        _MoneyUI.SetActive(true);
        _MoneyValueUI = GameObject.Find("MoneyValueTextUI").GetComponent<TextMeshProUGUI>();

        _PauseUI = GameObject.Find("PauseUIParent");
        
        _WheatValue = GameObject.Find("WheatValueText").GetComponent<TextMeshProUGUI>();
        _FishValue = GameObject.Find("FishValueText").GetComponent<TextMeshProUGUI>();
        _MoneyValuePause = GameObject.Find("MoneyValueTextPause").GetComponent<TextMeshProUGUI>();
        _DebtValue = GameObject.Find("DebtValueText").GetComponent<TextMeshProUGUI>();

        _PauseUI.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
            if (_PlayerObj.GetComponent<PlayerControlScript>()._Pause.triggered)
            {
            PauseGame();
            }

        _MoneyValueUI.text = _Inventory.moneyCount.ToString();

    }

    void PauseGame()
    {
        if (_PauseUI.activeSelf == true)
        {   
            _MoneyUI.SetActive(true);
            _PauseUI.SetActive(false);

        }
        else
        {
            _MoneyValuePause.text = _Inventory.moneyCount.ToString();
            _DebtValue.text = "€1,000,000";
            _WheatValue.text = _Inventory.wheatCount.ToString();
            _FishValue.text = _Inventory.fishCount.ToString();

            _MoneyUI.SetActive(false);
            _PauseUI.SetActive(true);
        }
    }
}
