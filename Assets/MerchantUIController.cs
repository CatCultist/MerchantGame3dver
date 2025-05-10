using UnityEngine;
using TMPro;
using GameplaySystems.Merchant;
using GameplaySystems.TradeGoods;
using UnityEngine.UI;
using Unity.VisualScripting;

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

    private void Awake()
    {
        _PlayerObj = GameObject.Find("Player");
        _PlayerInv = _PlayerObj.GetComponent<InventoryController>();

        _PlayerMoney.SetActive(false);
        _ShopPanels.SetActive(false);
        _NpcUI.SetActive(false);
        _ButtonManager.SetActive(false);


    }

    public void StartTrading()
    {
        _NpcObj = _NpcGameObject.GetComponent<TalkNPC>()._NpcObj;
        _PlayerMoneyField.text = _PlayerInv._PlayerMoney.ToString();

        NpcResponse(4);

        _PlayerMoney.SetActive(true);
        _ShopPanels.SetActive(true);
        _NpcUI.SetActive(true);
        _ButtonManager.SetActive(true);

        //Initialize buttons

    }

    public void TradeItem()
    {
        try
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

    
        public void NpcResponse(int _ReactionType)
        {
        switch (_ReactionType)
        {
                case 0:
                _NpcScriptField.text = _NpcObj._ReactionDialogue[0];
                _NpcFace.sprite = _NpcObj._NpcTalkSprite[0];

                break;


                case 1:
                _NpcScriptField.text = _NpcObj._ReactionDialogue[1];
                _NpcFace.sprite = _NpcObj._NpcTalkSprite[0];

                break;


                case 2:
                _NpcScriptField.text = _NpcObj._ReactionDialogue[2];
                _NpcFace.sprite = _NpcObj._NpcTalkSprite[1];

                break;


                case 3:
                _NpcScriptField.text = _NpcObj._ReactionDialogue[3];
                _NpcFace.sprite = _NpcObj._NpcTalkSprite[2];

                break;

                case 4:
                _NpcScriptField.text = _NpcObj._ReactionDialogue[4];
                _NpcFace.sprite = _NpcObj._NpcTalkSprite[0];
                break;
        }
        }

}
