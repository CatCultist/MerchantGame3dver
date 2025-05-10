using UnityEngine;
using TMPro;
using GameplaySystems.Merchant;
using GameplaySystems.TradeGoods;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEditor;

public class MerchantUIController : MonoBehaviour
{
    //game objects to be awakened
    [SerializeField] private GameObject _PlayerMoney;
    [SerializeField] private TextMeshProUGUI _PlayerMoneyField;
    [SerializeField] private GameObject _ShopPanels;
    [SerializeField] private GameObject _NpcUI;
    [SerializeField] private GameObject _ButtonManager;


    //initialize buttons for each good




    private GameObject _PlayerObj;
    private InventoryController _PlayerInv;
    private GameObject _UiControl;
    [HideInInspector] public GameObject _NpcGameObject;
    private NpcObj _NpcObj;

    [HideInInspector] public int _TradeType = 0;
    [HideInInspector] public TradeGoods _TradeGood;
    [HideInInspector] public int _Quantity;
    [HideInInspector] public float _PlayerOffer;
    [SerializeField] private GameObject _OfferField;

    //Npc text box + sprite
    [SerializeField] private Image _NpcFace;
    [SerializeField] private TextMeshProUGUI _NpcScriptField;

    [SerializeField] private Transform _PlayerInvScreen;
    [SerializeField] private Transform _NpcInvScreen;
    [SerializeField] private GameObject _ItemSlotPrefab;

    private void Awake()
    {
        _PlayerObj = GameObject.Find("Player");
        _PlayerInv = _PlayerObj.GetComponent<InventoryController>();
        _UiControl = GameObject.Find("UI");

        _PlayerMoney.SetActive(false);
        _ShopPanels.SetActive(false);
        _NpcUI.SetActive(false);
        _ButtonManager.SetActive(false);


    }

    public void EndTrade() //Called to end trading
    {
        _UiControl.GetComponent<uiController>()._IsTrading = false;

        //delete inv slots instantiated
        foreach (Transform _Slot in _PlayerInvScreen)
        {
            Destroy(_Slot.gameObject);
        }

        _PlayerMoney.SetActive(false);
        _ShopPanels.SetActive(false);
        _NpcUI.SetActive(false);
        _ButtonManager.SetActive(false);

        
        
    }

    public void StartTrading() //Called to start trading
    {
        _UiControl.GetComponent<uiController>()._IsTrading = true;
        _NpcObj = _NpcGameObject.GetComponent<TalkNPC>()._NpcObj;
        _PlayerMoneyField.text = _PlayerInv._PlayerMoney.ToString();

        NpcResponse(4);

        _PlayerMoney.SetActive(true);
        _ShopPanels.SetActive(true);
        _NpcUI.SetActive(true);
        _ButtonManager.SetActive(true);

        //Initialize buttons
        foreach (var _Item in _PlayerInv._ItemList)
        {
            var _ItemInstance = Instantiate(_ItemSlotPrefab);
            _ItemInstance.transform.SetParent(_PlayerInvScreen, true);
            _ItemInstance.GetComponent<ItemHolderInv>().SetGood(_Item);

        }

    }

    public void TradeItem() // Called to trade item selected by player
    {
        try //Use price player input; default to 0
        {
            _PlayerOffer = float.Parse(_OfferField.GetComponent<TMP_InputField>().text);
        }
        catch
        {
            _PlayerOffer = 0;
        }
        if (_PlayerOffer == 0)
        {
            NpcResponse(3);
            return;
        }
            //check if item offered is from the player or npc
            switch (_TradeType)
            {
                case 0:
                    Debug.Log("Cannot buy/sell nothing!");
                    break;

                case 1:
                    _NpcGameObject.GetComponent<IMerchantInteract>().OnItemPurchase(_TradeGood.tradeGoodID, _Quantity, _TradeGood.tradeGoodBasePrice, _PlayerOffer);
                    break;

                case 2:
                    _NpcGameObject.GetComponent<IMerchantInteract>().OnItemSold(_TradeGood.tradeGoodID, _Quantity, _TradeGood.tradeGoodBasePrice, _PlayerOffer);
                    break;
            }
        }

    
        public void NpcResponse(int _ReactionType) // Gives NPC Reaction to trade
        {
        switch (_ReactionType)
        {
                case 0: // neutral
                _NpcScriptField.text = _NpcObj._ReactionDialogue[0];
                _NpcFace.sprite = _NpcObj._NpcTalkSprite[0];

                break;


                case 1: // Happy
                _NpcScriptField.text = _NpcObj._ReactionDialogue[1];
                _NpcFace.sprite = _NpcObj._NpcTalkSprite[0];

                break;


                case 2: // rejected
                _NpcScriptField.text = _NpcObj._ReactionDialogue[2];
                _NpcFace.sprite = _NpcObj._NpcTalkSprite[1];

                break;


                case 3: // Confused, called when 0 money is offered
                _NpcScriptField.text = _NpcObj._ReactionDialogue[3];
                _NpcFace.sprite = _NpcObj._NpcTalkSprite[2];

                break;

                case 4: // text at start of trade
                _NpcScriptField.text = _NpcObj._ReactionDialogue[4];
                _NpcFace.sprite = _NpcObj._NpcTalkSprite[0];
                break;
        }
        }

}
